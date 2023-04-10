using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextInfo : MonoBehaviour
{
    public ProtoTypeBoss enemy;
    public Text status;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.curState == ProtoTypeBoss.CurrentState.Idle)
            status.text = "���....";
        else if (enemy.curState == ProtoTypeBoss.CurrentState.Trace1)
            status.text = "�����?";
        else if (enemy.curState == ProtoTypeBoss.CurrentState.Trace2)
            status.text = "�� �� ������...";
        else if (enemy.curState == ProtoTypeBoss.CurrentState.Attack)
        {
            if (enemy.CanSee(enemy.target))
                status.text = "ã�Ҵ�!!!";
            else
                status.text = "��ó�� �־�...";
        }
        else if (enemy.curState == ProtoTypeBoss.CurrentState.Damaged)
            status.text = "�ƾ�!!";
    }
}
