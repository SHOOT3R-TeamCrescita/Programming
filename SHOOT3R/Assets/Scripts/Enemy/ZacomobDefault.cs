using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ZacomobDefault : MonoBehaviour
{
    public Transform target;  //플레이어의 좌표

    public float dist;   //플레이어와의 거리
    public float HP;

    //사거리 변수들
    public int attackrange;
    public int outrange;

    public bool isAttack = false;

    public bool isRota = false;

    protected Rigidbody enemy;
    protected NavMeshAgent nav;

    public Animator anim;

    float x;

    void Awake()
    {
        enemy = GetComponent<Rigidbody>();
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        dist = Vector3.Distance(target.position, transform.position);
        nav.SetDestination(target.position);
        CheckDist();

        if (isRota)
        {
            x += Time.deltaTime * 50f;
            transform.eulerAngles = Vector3.forward * x;
        }
        if (HP < 0)
        {
            StartCoroutine("Timer");
        }


    }

    void FixedUpdate()
    {
        FreezeVelocity();
        OnDestroy();
    }

    //마찰 버그 수정
    void FreezeVelocity()
    {
        enemy.velocity = Vector3.zero;
        enemy.angularVelocity = Vector3.zero;
    }


    void CheckDist()
    {
        while (!isAttack)
        {
            if (dist < attackrange)
            {
                isAttack = true;
                StartCoroutine(Attack());
                //Debug.Log("공격");
            }

            else if (dist > attackrange && dist < outrange)
            {
                nav.isStopped = false;
                nav.speed = 15;
                //Debug.Log("죽이자!");
            }

            else if (dist > outrange)
            {
                nav.isStopped = true;
                //Debug.Log("배고파");
            }
            break;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            nav.isStopped = false;
            nav.speed = 15;
            HP -= 10;
            if (NoteMove.isDamage == true)
            {
                Debug.Log("퍽");
                HP -= 30 * (1 + (NoteCreater.noteCombo / 100f));
                //NoteMove.isDamage = false;
            }
            else if (NoteCreater.isLong == true)
            {
                HP += 6f;
            }
        }
    }

    protected virtual void OnDestroy()
    {

    }

    private IEnumerator Timer()
    {
        while (true)
        {
            nav.speed = 0;
            //nav.isStopped = true;
            isAttack = true;
            isRota = true;
            yield return new WaitForSeconds(2f);
            Destroy(gameObject);
        }
    }

    protected virtual IEnumerator Attack()
    {
        while (true)
        {
            Debug.Log("얍!!!");
            yield return null;
        }
    }
}
