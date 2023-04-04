using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyDefault : MonoBehaviour
{
    public Transform target;  //�÷��̾��� ��ǥ
    //public GameObject player;

    public float dist;   //�÷��̾���� �Ÿ�
    public float radius;  //Ž�� ����
    public float angle;  //Ž�� ����

    public LayerMask targetPlayer;  //�÷��̾� ���̾�
    public LayerMask obstacleMask;  //��ֹ� ���̾�

    public enum CurrentState {Idle, Trace1, Trace2, Attack, Damaged}
    public CurrentState curState = CurrentState.Idle;


    Rigidbody enemy;
    NavMeshAgent nav;

    private int randdirec;
    private Vector3 moveDirection;

    public bool isCheck = true;
    bool isRota = false;

    public float elaspedTime = 0f;

    Vector3 targetDirection;

    void Awake()
    {
        enemy = GetComponent<Rigidbody>();
        nav = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        StartCoroutine(Delay(2.0f));
        StartCoroutine(CheckState(0.25f));
        StartCoroutine(ChangeState(2f));
    }

    void Update()
    {
        dist = Vector3.Distance(target.position, transform.position);
        IdleMove();
        nav.SetDestination(target.position);
    }

    void FixedUpdate()
    {
        FreezeVelocity();
        Rotation(); 
    }

    //���� ���� ����
    void FreezeVelocity()
    {
        enemy.velocity = Vector3.zero;
        enemy.angularVelocity = Vector3.zero;
    }

    
    private IEnumerator CheckState(float waitTime)
    {
        while (true)
        {
            if (curState == CurrentState.Idle)
            {
                isCheck = true;
                nav.isStopped = true;
            }

            else if (curState == CurrentState.Trace1)
            {
                isCheck = false;
                nav.isStopped = false;
                Debug.Log("�����?");
                nav.SetDestination(target.position);
                nav.speed = 15;
            }
            else if (curState == CurrentState.Trace2)
            {
                isCheck = false;
                nav.isStopped = false;
                Debug.Log("�� �� ������");
                nav.SetDestination(target.position);
                nav.speed = 10;
            }

            else if (curState == CurrentState.Attack)
            {
                isCheck = false;
                if (dist < 30)
                {
                    nav.SetDestination(target.position);
                    if (CanSee(target))
                    {
                        nav.isStopped = true;
                        Debug.Log("ã�Ҵ�!");
                        //isRota = true;
                    }
                    else
                    {
                        nav.isStopped = false;
                        Debug.Log("��ó�� �ִµ�");
                        nav.speed = 1;
                        isRota = false;
                    }
                }
            }

            if ( dist < 30 )
                curState = CurrentState.Attack;

            else if (curState == CurrentState.Damaged)
            {
                Debug.Log("�ƾ�!!");
                isCheck = false;
                nav.speed = 40;
                if (dist < 30)
                    curState = CurrentState.Attack;
            }

            yield return new WaitForSeconds(waitTime);
        }
    }

    void Rotation()
    {
        targetDirection = target.position - transform.position;
        if (isRota)
        {
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * 150f);
        }
    }
    private IEnumerator Delay(float waitTime)
    {
        while(true)
        {
            yield return new WaitForSeconds(waitTime);
            IdleCheck();
        }
    }

    private IEnumerator DelayMove(float waitTime)
    {
        while (!isCheck)
        {
            IdleMove();
            yield return new WaitForSeconds(waitTime);
            isCheck = true;
        }
    }

    //������ �̵� ���� ����
    void IdleCheck()
    {
        //Debug.Log("�۵�");
        randdirec = Random.Range(0, 3);
        
        float x = Random.Range(-1f, 1f);
        float z = Random.Range(-1f, 1f);

        if (randdirec == 2)
            moveDirection = new Vector3(x, 0f, z);
        else
            moveDirection = Vector3.zero;
    }

    //������ �̵�
    void IdleMove()
    {
        if (isCheck && curState != CurrentState.Damaged)
        {
            Debug.Log("�쾯");
            enemy.AddForce(moveDirection * 2000f * Time.deltaTime, ForceMode.Impulse);
            if (moveDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 150f * Time.deltaTime);
            }
        }
    }

    //Ž�� ����(��ä��) �Ǻ�
     public bool CanSee(Transform target)
     {
         if (Vector3.Distance(transform.position, target.position) < radius )
         {
             Vector3 dirToTarget = (target.position - transform.position).normalized;
             float Viewangle = angle / 2f;

             if ( Vector3.Angle(transform.forward, dirToTarget) < Viewangle)
             {
                 float distToTarget = Vector3.Distance(transform.position, target.position);
                 if (!Physics.Raycast(transform.position, dirToTarget, distToTarget, obstacleMask))
                 { return true; }
             }
         }
         return false;
     }

     //Scene�信�� Ž�� ���� ǥ��(��ü����)
     void OnDrawGizmosSelected()
     {
         Gizmos.color = Color.yellow;
         Gizmos.DrawWireSphere(transform.position, radius);

         Vector3 leftBoundary = DirFromAngle(-angle / 2f, false);
         Vector3 rightBoundary = DirFromAngle(angle / 2f, false);

         Gizmos.color = Color.red;
         Gizmos.DrawLine(transform.position, transform.position + leftBoundary * radius);
         Gizmos.DrawLine(transform.position, transform.position + rightBoundary * radius);
     }
    //Scene�信�� Ž�� ���� ǥ��(Ž������)
     public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
     {
         if (!angleIsGlobal)
         {
             angleInDegrees += transform.eulerAngles.y;
         }

         return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0f, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
     }

    private IEnumerator ChangeState(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            stateCheck();
        }
    }

    void stateCheck()
    {
        int stateRand = Random.Range(0, 101);

        //if (curState != CurrentState.Damaged)
        //{
            if (dist < 30)
                curState = CurrentState.Attack;
            else if (dist > 30 && dist < 100)
            {
                if (stateRand > 51)
                    curState = CurrentState.Idle;
                else
                    curState = CurrentState.Trace2;
            }

            else if (dist > 100)
            {
                if (stateRand > 71)
                    curState = CurrentState.Idle;
                else
                    curState = CurrentState.Trace1;
            }
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 8)
        {
            curState = CurrentState.Damaged;
            isCheck = false;
            nav.isStopped = false;
            //nav.SetDestination(target.position);
        }
    }
}
