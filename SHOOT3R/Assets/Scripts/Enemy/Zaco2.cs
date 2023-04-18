using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zaco2 : ZacomobDefault
{
    protected override IEnumerator Attack()
    {
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
}
