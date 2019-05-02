using UnityEngine;
using System.Collections;
using IBM.Watson.DeveloperCloud.Logging;
using IBM.Watson.DeveloperCloud.Services.SpeechToText.v1;
using IBM.Watson.DeveloperCloud.Utilities;
using IBM.Watson.DeveloperCloud.DataTypes;
using System.Collections.Generic;
using UnityEngine.UI;
using Holostates;

public class IncorrectAnswerState : State<ExampleStreaming>
{
    private static IncorrectAnswerState _instance;

    private IncorrectAnswerState()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static IncorrectAnswerState Instance
    {
        get
        {
            if (_instance == null)
            {
                new IncorrectAnswerState();
            }

            return _instance;
        }
    }

    public override void EnterState(ExampleStreaming _owner)
    {
        Debug.Log("Entering Incorrect Answer State");
    }

    public override void ExitState(ExampleStreaming _owner)
    {
        Debug.Log("Exiting Incorrect Answer State");
    }

    public override void UpdateState(ExampleStreaming _owner)
    {
        _owner.stateMachine.ChangeState(IdleState.Instance);
    }
}
