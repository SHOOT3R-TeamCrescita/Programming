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

    Rigidbody enemy;
    NavMeshAgent nav;


    void Awake()
    {
        enemy = GetComponent<Rigidbody>();
        nav = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
    }

    void Update()
    {
        dist = Vector3.Distance(target.position, transform.position);
        nav.SetDestination(target.position);
        CheckDist();
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
        if ( dist < attackrange )
        {
            Debug.Log("공격");
        }

        else if ( dist >attackrange && dist < outrange)
        {
            nav.isStopped = false;
            nav.speed = 15;
            Debug.Log("죽이자!");
        }

        else if  ( dist > outrange )
        {
            nav.isStopped = true;
            Debug.Log("배고파");
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
                HP -= (30 * (1 + (NoteCreater.noteCombo / 100))); ;
                NoteMove.isDamage = false;
            }
            else if (NoteCreater.isLong == true)
            {
                HP += 9f;
            }
        }
    }

    void OnDestroy()
    {
        if(HP < 0)
            Destroy(gameObject);
    }
}
