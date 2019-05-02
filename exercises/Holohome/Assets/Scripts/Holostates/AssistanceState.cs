using UnityEngine;
using System.Collections;
using IBM.Watson.DeveloperCloud.Logging;
using IBM.Watson.DeveloperCloud.Services.SpeechToText.v1;
using IBM.Watson.DeveloperCloud.Utilities;
using IBM.Watson.DeveloperCloud.DataTypes;
using System.Collections.Generic;
using UnityEngine.UI;
using Holostates;

public class AssistanceState : State<ExampleStreaming>
{
    private static AssistanceState _instance;

    private AssistanceState()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static AssistanceState Instance
    {
        get
        {
            if (_instance == null)
            {
                new AssistanceState();
            }

            return _instance;
        }
    }

    public override void EnterState(ExampleStreaming _owner)
    {
        Debug.Log("Entering Assistance State");
    }

    public override void ExitState(ExampleStreaming _owner)
    {
        Debug.Log("Exiting Assistance State");
    }

    public override void UpdateState(ExampleStreaming _owner)
    {

    }
}
