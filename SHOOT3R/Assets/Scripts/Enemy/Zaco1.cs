using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zaco1 : ZacomobDefault
{
    [SerializeField] GameObject ball;
    [SerializeField] Transform shootinpoint;
    protected override IEnumerator Attack()
    {
        Vector3 direction = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);

        bool isShot = true;

        nav.isStopped = true;
        isturn = true;

        while (isShot)
        {
            anim.SetTrigger("isAttack");
            nav.speed = 4;
            Instantiate(ball, shootinpoint.position, rotation);
            yield return new WaitForSeconds(0.3f);
            Instantiate(ball, shootinpoint.position, rotation);
            isShot = false;
            
            yield return new WaitForSeconds(3f);
        }
        nav.isStopped = false;
        nav.speed = 15;
        isAttack = false;
    }

    protected override IEnumerator Timer()
    {
        nav.speed = 0;
        //nav.isStopped = true;
        isAttack = true;
        isRota = true;
        anim.SetTrigger("isDie");
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
