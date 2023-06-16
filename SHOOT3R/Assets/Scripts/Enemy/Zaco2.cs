using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zaco2 : ZacomobDefault
{
    bool isDie2 = true;
    protected override IEnumerator Attack()
    {
        yield return new WaitForSeconds(0.5f);
        float time = 1f;

        while (time > 0)
        {
            //Debug.Log("쿠아아아아아아아아아아");
            this.gameObject.layer = 12;
            nav.speed = 150;
            anim.SetBool("DashAttack", true);
            time -= Time.deltaTime;

            yield return new WaitForFixedUpdate();
        }
        
        nav.speed = 15;
        this.gameObject.layer = 10;
        anim.SetBool("DashAttack", false);

        yield return new WaitForSeconds(4f);
        isAttack = false;
    }

    protected override void OnDestroy()
    {
        Quaternion rotation = Quaternion.LookRotation(target.position - transform.position);
        Vector3 currentPosition = transform.position;
        currentPosition.y += 0.75f; 

        if (HP < 0 && isDie2)
        {
            for (int i = 0; i < 1; i++)
            {
                int randomInex = Random.Range(0, Items.Length);
                GameObject InstItem = Instantiate(Items[randomInex], transform.position, Quaternion.Euler(-90f, 0f, 0f));
            }
            isDie2 = false;
        }
    }
}
