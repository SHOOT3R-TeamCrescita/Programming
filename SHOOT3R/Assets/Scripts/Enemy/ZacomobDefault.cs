using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ZacomobDefault : MonoBehaviour
{
    public Transform target;  //�÷��̾��� ��ǥ

    public float dist;   //�÷��̾���� �Ÿ�
    public float HP;

    //��Ÿ� ������
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

    //���� ���� ����
    void FreezeVelocity()
    {
        enemy.velocity = Vector3.zero;
        enemy.angularVelocity = Vector3.zero;
    }


    void CheckDist()
    {
        if ( dist < attackrange )
        {
            Debug.Log("����");
        }

        else if ( dist >attackrange && dist < outrange)
        {
            nav.isStopped = false;
            nav.speed = 15;
            Debug.Log("������!");
        }

        else if  ( dist > outrange )
        {
            nav.isStopped = true;
            Debug.Log("�����");
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
