using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : EnemyDefault
{
    public GameObject weapon;
    public GameObject misile;
    public Transform shootingpoint;
    public GameObject range;

    
    public Animator bookCol;

    [SerializeField]
    AudioSource rocket;

    protected override IEnumerator BossAttack()
    {
        while (curState == CurrentState.Attack)
        {
            nav.isStopped = true;

            int pattern = Random.Range(1, 2);

            switch (pattern)
            {
                case 1:
                    {
                        bossanim.SetTrigger("isAttack");
                        bookCol.SetTrigger("isAttack");
                    }
                    break;
                case 2:
                    for (int i = 0; i < 2; i++)
                    {
                        rocket.Play();
                        targetDirection = target.position - transform.position;
                        //Instantiate(misile, transform.position, Quaternion.LookRotation(targetDirection, Vector3.up)); 
                        GameObject misileA = Instantiate(misile, shootingpoint.position, Quaternion.LookRotation(targetDirection, Vector3.up));
                        Misile mis = misileA.GetComponent<Misile>();
                        mis.target = target;
                    }
                    break;
                case 3:
                    {
                        range.SetActive(true);
                        //nav.isStopped = false;
                        //nav.speed = 25;
                        BossHP.dotHP = true;
                    }
                    break;
            }
            yield return new WaitForSeconds(3f);
            range.SetActive(false);
            nav.isStopped = true;
            nav.speed = 1;
            BossHP.dotHP = false;
            isAttack = false;
        }

        if(curState != CurrentState.Attack)
            yield return StartCoroutine(CheckState(0.25f));
    }

}
