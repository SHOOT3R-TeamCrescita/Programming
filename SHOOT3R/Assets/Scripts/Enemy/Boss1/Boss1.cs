using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : EnemyDefault
{
    public GameObject weapon;
    public GameObject misile;
    public Transform shootingpoint;
    public GameObject range;

    public float time = 1.2f;

    public Animator bookCol;

    [SerializeField]
    AudioSource rocket;

    protected override IEnumerator BossAttack()
    {
        while (curState == CurrentState.Attack)
        {
            //nav.isStopped = true;

            int pattern = Random.Range(0, 101);

            if(pattern<66)
            {
                nav.isStopped = false;
                nav.speed = 20;

                if (dist < 5.5f)
                {
                    nav.speed = 10;
                    bossanim.SetTrigger("isAttack");
                    bookCol.SetTrigger("isAttack");
                }
                else
                    nav.speed = 20;

                if (Boss1Collider.hitcount != 0)
                {
                    bossanim.SetTrigger("isHit");
                    bookCol.SetTrigger("isHit");
                    Boss1Collider.hitcount = 0;
                }

            }
            else if(pattern>=66)
            {
                while(time > 0)
                {
                    bossanim.SetTrigger("isDash");
                    nav.isStopped = false;
                    this.gameObject.layer = 15;
                    nav.speed = 35;
                    time -= Time.deltaTime;

                    yield return new WaitForFixedUpdate();
                }
                nav.speed = 15;
                bossanim.SetBool("isRun", false);
                bossanim.SetBool("isIdle", true);
                bossanim.SetBool("isWalk", false);
            }
            
            yield return new WaitForSeconds(2f);
            time = 1.2f;
            range.SetActive(false);
            this.gameObject.layer = 10;

            nav.speed = 15;
            bossanim.SetBool("isRun", false);
            bossanim.SetBool("isIdle", true);
            bossanim.SetBool("isWalk", false);

            BossHP.dotHP = false;
            isAttack = false;
        }

        if(curState != CurrentState.Attack)
            yield return StartCoroutine(CheckState(0.25f));
    }
}
