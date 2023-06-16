using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zaco3 : ZacomobDefault
{
    public GameObject ball;
    public GameObject baby;
    bool isDie3 = true;

    protected override IEnumerator Attack()
    {
        Vector3 direction = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);

        bool isShot = true;

        nav.isStopped = true;
        isturn = true;

        while (isShot)
        {
            Instantiate(ball, transform.position, rotation);
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

    protected override void OnDestroy()
    {
        //Vector3 direction = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(target.position - transform.position);

        if (HP < 0 && isDie3)
        {
            anim.SetTrigger("IsDie");
            for (int i = 0; i < 4; i++)
            {
                GameObject babyA = Instantiate(baby, transform.position, rotation);
                Zaco3_1 zac = babyA.GetComponent<Zaco3_1>();
                zac.target = target;
            }
            //int randomInex = Random.Range(0, Items.Length);
            //GameObject InstItem = Instantiate(Items[randomInex], transform.position, rotation);
            isDie3 = false;
        }
    }
}
