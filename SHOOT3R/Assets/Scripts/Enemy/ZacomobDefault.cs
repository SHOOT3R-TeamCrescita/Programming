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

    //���� ���� ����
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
                //Debug.Log("����");
            }

            else if (dist > attackrange && dist < outrange && HP > 0)
            {
                nav.isStopped = false;
                nav.speed = 10;
                //Debug.Log("������!");
            }

            else if (dist > outrange && HP > 0)
            {
                nav.isStopped = true;
                //Debug.Log("�����");
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
                //Debug.Log("��");
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
            //Debug.Log("��!!!");
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
