using UnityEngine;
using System.Collections;
using IBM.Watson.DeveloperCloud.Logging;
using IBM.Watson.DeveloperCloud.Services.SpeechToText.v1;
using IBM.Watson.DeveloperCloud.Utilities;
using IBM.Watson.DeveloperCloud.DataTypes;
using System.Collections.Generic;
using UnityEngine.UI;
using Holostates;

public class IntroductionState : State<ExampleStreaming>
{
    private static IntroductionState _instance;

    private IntroductionState()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static IntroductionState Instance
    {
        get
        {
            if (_instance == null)
            {
                new IntroductionState();
            }

            return _instance;
        }
    }

    public override void EnterState(ExampleStreaming _owner)
    {
        Debug.Log("Entering Introduction State");
    }

    public override void ExitState(ExampleStreaming _owner)
    {
        Debug.Log("Exiting Introduction State");
    }

    public override void UpdateState(ExampleStreaming _owner)
    {
        _owner.stateMachine.ChangeState(NewQuestionState.Instance);
    }
}
