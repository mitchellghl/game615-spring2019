using UnityEngine;
using System.Collections;
using IBM.Watson.DeveloperCloud.Logging;
using IBM.Watson.DeveloperCloud.Services.SpeechToText.v1;
using IBM.Watson.DeveloperCloud.Utilities;
using IBM.Watson.DeveloperCloud.DataTypes;
using System.Collections.Generic;
using UnityEngine.UI;
using Holostates;

public class CheckAnswerState : State<ExampleStreaming>
{
    private static CheckAnswerState _instance;

    private CheckAnswerState()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static CheckAnswerState Instance
    {
        get
        {
            if (_instance == null)
            {
                new CheckAnswerState();
            }

            return _instance;
        }
    }

    public override void EnterState(ExampleStreaming _owner)
    {
        Debug.Log("Entering Check Answer State");
    }

    public override void ExitState(ExampleStreaming _owner)
    {
        Debug.Log("Exiting Check Answer State");
    }

    public override void UpdateState(ExampleStreaming _owner)
    {
        
    }
}
