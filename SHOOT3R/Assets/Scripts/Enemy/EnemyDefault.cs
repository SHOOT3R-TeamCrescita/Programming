using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyDefault : MonoBehaviour
{
    public Transform target;
    //public GameObject player;

    public float dist;
    public float radius;
    public float angle;

    public LayerMask targetPlayer;
    public LayerMask obstacleMask;

    Rigidbody enemy;
    BoxCollider boxCollider;
    NavMeshAgent nav;



    void Awake()
    {
        enemy = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        nav = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(GetComponent<Rigidbody>().velocity.magnitude);
        dist = Vector3.Distance(target.position, transform.position);

        CheckDist();
        //Find();
        //if (CanSee(target))
           // Debug.Log("found you!");
    }

    void FixedUpdate()
    {
        FreezeVelocity();
    }

    void FreezeVelocity()
    {
        enemy.velocity = Vector3.zero;
        enemy.angularVelocity = Vector3.zero;
    }

    void CheckDist()
    {
        nav.speed = 25;
        nav.SetDestination(target.position);
        if (dist < 20)
        {
            
            if(CanSee(target))
            {
                Debug.Log("found you!");
            }
            else
            {
                Debug.Log("where?");
                //transform.Rotate(Vector3.up * Time.deltaTime * 300);
                nav.speed = 1;
            }
        }
    }

    /* void Find()
     {
         Vector3 playerTarget = (player.transform.position - transform.position).normalized;

         Debug.DrawRay(transform.position, playerTarget * dist, Color.red);

         if ( Vector3.Angle(transform.forward, playerTarget) < viewAngle / 2)
         {
             //float distanceToTarget = Vector3.Distance(transform.position, player.transform.position);
             if(dist <= viewRadius)
             {
                 if(Physics.Raycast(transform.position, playerTarget, dist, obstacleMask) == false)
                 {
                     Debug.Log("found you!");
                 }
             }
         }
     }*/

     bool CanSee(Transform target)
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

     public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
     {
         if (!angleIsGlobal)
         {
             angleInDegrees += transform.eulerAngles.y;
         }

         return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0f, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
     }
}
