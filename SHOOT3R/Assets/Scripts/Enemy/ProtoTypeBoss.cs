using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoTypeBoss : EnemyDefault
{
    public GameObject weapon;
    public GameObject misile;
    public Transform shootingpoint;
    public GameObject range;

    [SerializeField]
    AudioSource rocket;

    /*public override void BossAttack2()
    {
        int randatt = Random.Range(0, 4);
        Debug.Log("¾å!!!");
        //isAttack = false;
    }*/


    protected override IEnumerator BossAttack()
    {
        while (curState == CurrentState.Attack)
        {
            nav.isStopped = true;

            int pattern = Random.Range(1, 4);

            switch (pattern)
            {
                case 1:
                    for (int i = 0; i < 60; i++)
                    {
                        //bossanim.SetInteger("Skill", 2);

                        targetDirection = target.position - transform.position;
                        Instantiate(weapon, shootingpoint.position, Quaternion.LookRotation(targetDirection, Vector3.up));
                    }
                    break;
                case 2:
                    for (int i = 0; i < 2; i++)
                    {
                        //bossanim.SetInteger("Skill", 3);

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
                        //bossanim.SetInteger("Skill", 1);

                        range.SetActive(true);
                        nav.isStopped = false;
                        nav.speed = 25;
                        BossHP.dotHP = true;
                    }
                    break;
            }

            bossanim.SetInteger("Skill", 0);
            yield return new WaitForSeconds(4f);
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
