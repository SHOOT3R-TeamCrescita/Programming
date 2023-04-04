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


    //오브젝트
    Rigidbody rigid;
    public GameObject model;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.freezeRotation = true;

        Physics.gravity = new Vector3(0, gravity, 0);
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
        if (Input.GetMouseButton(0)&&shootTimer > shootDelay)
        {
            if (NoteCreater.isLong == true)
            {
                Vector3 aimDir = (mouseWorldPosition - bulletspawn.position).normalized;
                Instantiate(bullet, bulletspawn.position, Quaternion.LookRotation(aimDir, Vector3.up));
                //Instantiate(bullet, orientation.position, Quaternion.LookRotation(aimDir, Vector3.up));
            }
            else 
            {
                Vector3 aimDir = (mouseWorldPosition - bulletspawn.position).normalized;
                Instantiate(bullet, bulletspawn.position, Quaternion.LookRotation(aimDir, Vector3.up));
                //Instantiate(bullet, orientation.position, Quaternion.LookRotation(aimDir, Vector3.up));

                shootTimer = 0f;
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

        rigid.AddForce(moveDirection.normalized * Time.deltaTime *1000 * speed, ForceMode.Force);

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
        if (Input.GetButtonDown("Jump") && !isJump)
        {
            isJump = true;
            rigid.AddForce(new Vector3(0, jumpPower*100, 0), ForceMode.Force);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && isDash)
        {
            rigid.AddForce(orientation.forward * 2000f, ForceMode.Impulse);
            isDash = false;
            StartCoroutine(Dash(5f));
        }

    }

    //이중 점프 막기 판정
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
            isJump = false;
    }

    private IEnumerator Dash(float WaitTime)
    {
        while(true)
        {
            yield return new WaitForSeconds(WaitTime);
            isDash = true;
            Debug.Log("대쉬 가능!");
        }
    }
}
