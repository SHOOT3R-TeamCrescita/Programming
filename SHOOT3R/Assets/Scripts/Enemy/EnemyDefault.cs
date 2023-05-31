using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyDefault : MonoBehaviour
{
    public Transform target;  //플레이어의 좌표
    //public GameObject player;

    public float dist;   //플레이어와의 거리
    public float radius;  //탐지 범위
    public float angle;  //탐지 각도

    //사거리 변수들
    public int attackrange;
    public int outrange;

    //속도
    public int defSpeed;
    public int tracSpeed;
    public int damSpeed;

    public LayerMask targetPlayer;  //플레이어 레이어
    public LayerMask obstacleMask;  //장애물 레이어

    //스테이터스
    public enum CurrentState {Idle, Trace1, Trace2, Attack, Damaged}
    public CurrentState curState = CurrentState.Idle;


    Rigidbody enemy;
    protected NavMeshAgent nav;
    public Animator bossanim;

    private int randdirec;
    private Vector3 moveDirection;

    public bool isCheck = true;  //IdleMove 판별
    bool isRota = false;  //회전 판별
    public bool isAttack = false; //공격중인지 판별

    protected Vector3 targetDirection;

    void Awake()
    {
        enemy = GetComponent<Rigidbody>();
        nav = GetComponent<NavMeshAgent>();
        bossanim = GetComponent<Animator>();
    }

    void Start()
    {
        StartCoroutine(Delay(2.0f));
        StartCoroutine(CheckState(0.1f));
        StartCoroutine(ChangeState(2f));
    }

    void Update()
    {
        dist = Vector3.Distance(target.position, transform.position);
        IdleMove();
        nav.SetDestination(target.position);

        //Debug.Log(nav.speed);
    }

    void FixedUpdate()
    {
        FreezeVelocity();
        Rotation();
        Animation();
    }

    //마찰 버그 수정
    void FreezeVelocity()
    {
        enemy.velocity = Vector3.zero;
        enemy.angularVelocity = Vector3.zero;
    }

    
    //스테이트에 따른 적 행동 변화
    public IEnumerator CheckState(float waitTime)
    {
        while (!isAttack)
        {
            if (curState == CurrentState.Damaged && dist < attackrange)
            {
                curState = CurrentState.Attack;
                nav.isStopped = true;
            }

            else
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
                    //Debug.Log("어딨어?");
                    nav.SetDestination(target.position);
                    nav.speed = tracSpeed;
                }
                else if (curState == CurrentState.Trace2)
                {
                    isCheck = false;
                    nav.isStopped = false;
                    //Debug.Log("본 거 같은데");
                    nav.SetDestination(target.position);
                    nav.speed = defSpeed;
                }

                else if (curState == CurrentState.Attack)
                {
                    isCheck = false;

                    if (dist < attackrange)
                    {
                        nav.SetDestination(target.position);

                        if (CanSee(target))
                        {
                            nav.isStopped = true;
                            //Debug.Log("찾았다!");
                            isRota = true;
                            isAttack = true;
                            StartCoroutine(BossAttack());
                        }
                        else
                        {
                            nav.isStopped = false;
                            //Debug.Log("근처에 있는데");
                            nav.speed = 1;
                            isRota = false;
                        }
                    }
                }
                if (dist < attackrange)
                {
                    nav.speed = 1; 
                    curState = CurrentState.Attack;
                }
            }
            

            yield return new WaitForSeconds(waitTime);
        }
    }

    //적이 플레이어를 바라보게끔 회전.
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

    //무작위 이동 방향 결정
    void IdleCheck()
    {
        //Debug.Log("작동");
        randdirec = Random.Range(0, 3);
        
        float x = Random.Range(-1f, 1f);
        float z = Random.Range(-1f, 1f);

        if (randdirec == 2)
            moveDirection = new Vector3(x, 0f, z);
        else
            moveDirection = Vector3.zero;
    }

    //무작위 이동
    void IdleMove()
    {
        if (isCheck && curState != CurrentState.Damaged)
        {
            //Debug.Log("우쒸");
            enemy.AddForce(moveDirection * 2000f * Time.deltaTime, ForceMode.Impulse);
            if (moveDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 150f * Time.deltaTime);
            }
        }
    }

    //탐지 범위(부채꼴) 판별
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

     //Scene뷰에서 탐지 범위 표시(전체범위)
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
    //Scene뷰에서 탐지 범위 표시(탐지범위)
     public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
     {
         if (!angleIsGlobal)
         {
             angleInDegrees += transform.eulerAngles.y;
         }

         return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0f, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
     }

    //stateCheck 딜레이 함수.
    public IEnumerator ChangeState(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            stateCheck();
        }
    }


    //일정 시간마다 적의 스테이터스 판정.
    void stateCheck()
    {
        //거리에 따라 이동 확률 증가를 위한 변수들
        float probability = Mathf.Clamp(dist / 300, 0.1f, 0.9f);
        float stateRand = Random.Range(0.1f,1f);

        if (curState != CurrentState.Damaged)
        {
            if (dist < attackrange)
                curState = CurrentState.Attack;
            else if (dist > attackrange && dist < outrange)
            {
                if (stateRand < probability)
                    curState = CurrentState.Idle;
                else
                    curState = CurrentState.Trace2;
            }

            else if (dist > outrange)
            {
                if (stateRand < probability)
                    curState = CurrentState.Idle;
                else
                    curState = CurrentState.Trace1;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8)
            if (dist > attackrange)
            {
                //Debug.Log("쿠아아앙");
                curState = CurrentState.Damaged;
                isCheck = false;
                nav.isStopped = false;
                nav.speed = damSpeed;

                bossanim.SetBool("isRun", true);
                bossanim.SetBool("isIdle", false);
                bossanim.SetBool("isWalk", false);
            }
    }

    protected virtual IEnumerator BossAttack()
    {
        while (true)
        {
            //Debug.Log("얍!!!");
            yield return null;
        }
    }

    void Animation()
    {
        if ( curState == CurrentState.Damaged )
        {
            bossanim.SetBool("isRun", true);
            bossanim.SetBool("isIdle", false);
            bossanim.SetBool("isWalk", false);
        }
        else if (isCheck)
        {
            bossanim.SetBool("isRun", false);
            bossanim.SetBool("isIdle", false);
            bossanim.SetBool("isWalk", true);
        }
        else if ( nav.speed > 1 )
        {
            bossanim.SetBool("isRun", true);
            bossanim.SetBool("isIdle", false);
            bossanim.SetBool("isWalk", false);
        }
        else
        {
            bossanim.SetBool("isRun", false);
            bossanim.SetBool("isIdle", true);
            bossanim.SetBool("isWalk", false);
        }
    }
}
