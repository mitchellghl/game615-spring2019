using UnityEngine;
using System.Collections;
using IBM.Watson.DeveloperCloud.Logging;
using IBM.Watson.DeveloperCloud.Services.SpeechToText.v1;
using IBM.Watson.DeveloperCloud.Utilities;
using IBM.Watson.DeveloperCloud.DataTypes;
using System.Collections.Generic;
using UnityEngine.UI;
using Holostates;

public class IdleState : State<ExampleStreaming>
{
    public float struggleTime;

    private static IdleState _instance;

    private IdleState()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static IdleState Instance
    {
        get
        {
            if (_instance == null)
            {
                new IdleState();
            }

            return _instance;
        }
    }

    public override void EnterState(ExampleStreaming _owner)
    {
        Debug.Log("Entering Idle State");
    }

    public override void ExitState(ExampleStreaming _owner)
    {
        Debug.Log("Exiting Idle State");
    }

    public override void UpdateState(ExampleStreaming _owner)
    {
        struggleTime += Time.deltaTime;
        Debug.Log("Strugglet Time: " + struggleTime);
        if(struggleTime > 10f)
        {
            struggleTime = 0f;
            _owner.stateMachine.ChangeState(StruggleState.Instance);
        }
    }
}
