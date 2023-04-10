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
            status.text = "잠깐....";
        else if (enemy.curState == ProtoTypeBoss.CurrentState.Trace1)
            status.text = "어딨어?";
        else if (enemy.curState == ProtoTypeBoss.CurrentState.Trace2)
            status.text = "본 거 같은데...";
        else if (enemy.curState == ProtoTypeBoss.CurrentState.Attack)
        {
            if (enemy.CanSee(enemy.target))
                status.text = "찾았다!!!";
            else
                status.text = "근처에 있어...";
        }
        else if (enemy.curState == ProtoTypeBoss.CurrentState.Damaged)
            status.text = "아야!!";
    }
}
