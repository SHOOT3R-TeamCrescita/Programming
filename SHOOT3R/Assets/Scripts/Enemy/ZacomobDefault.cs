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
            if (dist < attackrange)
            {
                isAttack = true;
                StartCoroutine(Attack());
                //Debug.Log("����");
            }

            else if (dist > attackrange && dist < outrange)
            {
                nav.isStopped = false;
                nav.speed = 15;
                //Debug.Log("������!");
            }

            else if (dist > outrange)
            {
                nav.isStopped = true;
                //Debug.Log("�����");
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
                Debug.Log("��");
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
            Debug.Log("��!!!");
            yield return null;
        }
    }
}
