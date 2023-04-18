using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zaco3 : ZacomobDefault
{
    public GameObject ball;
    public GameObject baby;
    bool isDie = true;

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

    protected override void OnDestroy()
    {
        //Vector3 direction = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(target.position - transform.position);

        if (HP < 0 && isDie)
        {
            anim.SetTrigger("IsDie");
            for (int i = 0; i < 4; i++)
            {
                GameObject babyA = Instantiate(baby, transform.position, rotation);
                Zaco3_1 zac = babyA.GetComponent<Zaco3_1>();
                zac.target = target;
            }
            isDie = false;
        }
    }
}
