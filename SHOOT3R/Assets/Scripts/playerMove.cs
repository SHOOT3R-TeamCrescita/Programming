using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMove : MonoBehaviour
{
    //발사 에임 관련
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    [SerializeField] private Transform debugTransform;

    //캐릭터 이동 관련
    [Header("Movement")]
    public float speed; //이동 속도
    public float maxspeed; //최대 속도
    public float jumpPower; //점프력
    public float gravity; //중력 설정

    public static int test;

    float h;
    float v;

    public Transform orientation;

    Vector3 moveDirection;

    //총알 관련
    public GameObject bullet;
    public Transform bulletspawn;

    public float shootDelay = 0.05f;
    public float shootTimer = 0f;


    //이중 점프 막기
    public bool isJump = false;
    public bool isDash = true;

    //사운드
    public SFX_Player SFXPlayer;


    //오브젝트
    Rigidbody rigid;
    public GameObject model;

    public GameObject Check;
    public GameObject DashUI;

    public Animator anim;

    [SerializeField]
    AudioSource shot;

    void Start()
    {
        Physics.gravity = new Vector3(0, gravity, 0);

        rigid = GetComponent<Rigidbody>();
        rigid.freezeRotation = true;

        anim = transform.GetChild(0).GetComponent<Animator>();

        SFXPlayer.GetComponents<SFX_Player>();

        //임시로 여기다 추가(에디터의 프레임 제한)
        Time.captureFramerate = 60;
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnBullet();
        PlayerMove();
    }

    void FixedUpdate()
    {

    }

    void SpawnBullet()
    {
        //마우스로 에임 설정
        Vector3 mouseWorldPosition = Vector3.zero;
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);

        //에임 테스터 설정
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {
            debugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
        }

        //발사 코드
        if (Input.GetMouseButtonDown(0)&&!GameManager.isStop)
        {
            //SFXPlayer.SfxPlay(SFX_Player.Sfx.shoot);
            //if (shootTimer > shootDelay)
            anim.SetTrigger("isAtta");

            if (NoteManager.isCheck && !NoteManager.isLong)
            {
                SFXPlayer.SfxPlay(SFX_Player.Sfx.shoot);
                //shot.Play();
                //Debug.Log("발사사사사사사사사사ㅏ사사사사사사사사사사사");
                Vector3 aimDir = (mouseWorldPosition - bulletspawn.position).normalized;
                Instantiate(bullet, bulletspawn.position, Quaternion.LookRotation(aimDir, Vector3.up));
                //Instantiate(bullet, orientation.position, Quaternion.LookRotation(aimDir, Vector3.up));

                // bullet bulletsc = bullet.GetComponent<bullet>();
                //bulletsc.isColor = NoteMove.isColor;

                shootTimer = 0f;
            }
            else if (!NoteManager.isCheck && !NoteManager.isLong)
                SFXPlayer.SfxPlay(SFX_Player.Sfx.miss);
        }

        if (Input.GetMouseButton(0) && !GameManager.isStop)
        {
            anim.SetTrigger("isAtta");

            if (NoteManager.isLong)
            {
                //NoteManager.isDamage = false;
                Vector3 aimDir = (mouseWorldPosition - bulletspawn.position).normalized;
                Instantiate(bullet, bulletspawn.position, Quaternion.LookRotation(aimDir, Vector3.up));

                // bullet bulletsc = bullet.GetComponent<bullet>();
                // bulletsc.isColor = NoteMove.isColor;
                //Instantiate(bullet, orientation.position, Quaternion.LookRotation(aimDir, Vector3.up));
            }
        }
        shootTimer += Time.deltaTime;
    }

    private void PlayerMove()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        //이동
        moveDirection = orientation.forward * v + orientation.right * h;

        if(NoteManager.noteCombo>=20)
            rigid.AddForce(moveDirection.normalized * Time.deltaTime * 1000 * 1.75f * speed, ForceMode.Force);
        else
            rigid.AddForce(moveDirection.normalized * Time.deltaTime * 1000 * speed, ForceMode.Force);


        anim.SetBool("isWalk", moveDirection != Vector3.zero);


        //최대 속도 제한
        if (rigid.velocity.x > maxspeed)
            rigid.velocity = new Vector3(maxspeed, rigid.velocity.y, rigid.velocity.z);
        else if (rigid.velocity.x < maxspeed * (-1))
            rigid.velocity = new Vector3(maxspeed * (-1), rigid.velocity.y, rigid.velocity.z);
        else if (rigid.velocity.z > maxspeed)
            rigid.velocity = new Vector3(rigid.velocity.x, rigid.velocity.y, maxspeed);
        else if (rigid.velocity.z < maxspeed * (-1))
            rigid.velocity = new Vector3(rigid.velocity.x, rigid.velocity.y, maxspeed * (-1));


        //점프
        if (Input.GetButtonDown("Jump") && !isJump && !GameManager.isStop)
        {
            SFXPlayer.SfxPlay(SFX_Player.Sfx.jump);
            anim.SetTrigger("isJump");
            isJump = true;
            rigid.AddForce(new Vector3(0, jumpPower*200, 0), ForceMode.Force);
        }

        //대쉬
        if (Input.GetKey(KeyCode.LeftShift) && isDash && !GameManager.isStop)
        {
            //Debug.Log("대쉬 가능!");
            SFXPlayer.SfxPlay(SFX_Player.Sfx.dash);
            isDash = false;
            DashUI.SetActive(false);
            anim.SetTrigger("isDash");
            if (h == 0 && v == 0)
                rigid.AddForce(orientation.forward * 800f * 250f, ForceMode.Force);
            else
                rigid.AddForce(moveDirection.normalized * 800f * 250f, ForceMode.Force);
            StartCoroutine(Dash(2.5f));
        }
    }

    //이중 점프 막기 판정
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6|| collision.gameObject.layer == 13)
        {
            isJump = false;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == 13)
            Physics.gravity = new Vector3(0, gravity+50, 0);
        else
            Physics.gravity = new Vector3(0, gravity, 0);
    }

    private IEnumerator Dash(float WaitTime)
    {
        isDash = false;
        while(WaitTime > 0f)
        {
            WaitTime -= Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        isDash = true;
        DashUI.SetActive(true);
    }
}
