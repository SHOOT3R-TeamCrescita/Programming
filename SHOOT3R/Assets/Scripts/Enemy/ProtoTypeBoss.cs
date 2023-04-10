using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoTypeBoss : EnemyDefault
{
    public GameObject weapon;
    
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
            Debug.Log("¾ÆÀÚ!!!");
            for (int i = 0; i < 50; i++)
            {
                Instantiate(weapon, transform.position, Quaternion.LookRotation(Vector3.forward));
            }
            
            yield return new WaitForSeconds(4f);
            isAttack = false;
        }

        if(curState != CurrentState.Attack)
            yield return StartCoroutine(CheckState(0.25f));
    }

}
