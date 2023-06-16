using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zaco3_1 : ZacomobDefault
{
    public GameObject ball;

    protected override IEnumerator Attack()
    {
        Vector3 direction = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);

        bool isShot = true;

        while (isShot)
        {
            nav.speed = 1;
            Instantiate(ball, transform.position, rotation);
            isShot = false;
            yield return new WaitForSeconds(3f);
            nav.speed = 15;
        }
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

    protected override void OnDestroy()
    {
    }
}
