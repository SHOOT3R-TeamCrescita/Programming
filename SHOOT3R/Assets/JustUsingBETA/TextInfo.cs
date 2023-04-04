using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextInfo : MonoBehaviour
{
    public EnemyDefault enemy;
    public Text status;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.curState == EnemyDefault.CurrentState.Idle)
            status.text = "���....";
        else if (enemy.curState == EnemyDefault.CurrentState.Trace1)
            status.text = "�����?";
        else if (enemy.curState == EnemyDefault.CurrentState.Trace2)
            status.text = "�� �� ������...";
        else if (enemy.curState == EnemyDefault.CurrentState.Attack)
        {
            if (enemy.CanSee(enemy.target))
                status.text = "ã�Ҵ�!!!";
            else
                status.text = "��ó�� �־�...";
        }
        else if (enemy.curState == EnemyDefault.CurrentState.Damaged)
            status.text = "�ƾ�!!";
    }
}
