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
    public bool isturn = false;

    protected Rigidbody enemy;
    protected NavMeshAgent nav;

    protected Vector3 targetDirection;

    public Animator anim;

    public GameObject[] Items;

    public GameObject DeadEffect;

    bool isCh = true;

    float x;

    void Awake()
    {
        enemy = GetComponent<Rigidbody>();
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        target = GameObject.Find("Player").transform;
    }


    void Update()
    {
        Turn();
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
            DeadEFF();
            StatManager.score += 1f;
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
            if (dist < attackrange )
            {
                isAttack = true;
                StartCoroutine(Attack());
                //Debug.Log("공격");
            }

            else if (dist > attackrange && dist < outrange && HP > 0)
            {
                nav.isStopped = false;
                nav.speed = 10;
                //Debug.Log("죽이자!");
            }

            else if (dist > outrange && HP > 0)
            {
                nav.isStopped = true;
                //Debug.Log("배고파");
            }
            break;
        }
    }

    void Rotation()
    {
        targetDirection = target.position - transform.position;
        //if (isRota)
        //{
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * 150f);
       // }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            nav.isStopped = false;
            nav.speed = 10;
            HP -= 10;
            //if (NoteMove.isDamage == true)
            //{
                //Debug.Log("퍽");
                HP -= 30 * (1 + (NoteManager.noteCombo / 100f));
                //NoteMove.isDamage = false;
            //}
            if (NoteManager.isLong == true)
            {
                HP += 6f;
            }
        }
    }

    public void Turn()
    {
        targetDirection = target.position - transform.position;
        if (isturn)
        {
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * 150f);
        }
    }

    protected virtual void OnDestroy()
    {

    }

    protected virtual IEnumerator Timer()
    {
            nav.speed = 0;
            //nav.isStopped = true;
            isAttack = true;
            isRota = true;
            yield return new WaitForSeconds(2f);
            Destroy(gameObject);
    }

    protected virtual IEnumerator Attack()
    {
        while (true)
        {
            //Debug.Log("얍!!!");
            yield return null;
        }
    }

    public void DeadEFF()
    {
        if (isCh)
        {
            Instantiate(DeadEffect, transform.position, Quaternion.Euler(0, 0, 0));
            isCh = false;
        }
    }
}
