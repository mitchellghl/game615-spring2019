using UnityEngine;
using System.Collections;
using IBM.Watson.DeveloperCloud.Logging;
using IBM.Watson.DeveloperCloud.Services.SpeechToText.v1;
using IBM.Watson.DeveloperCloud.Utilities;
using IBM.Watson.DeveloperCloud.DataTypes;
using System.Collections.Generic;
using UnityEngine.UI;
using Holostates;

public class HowToMultiplyState : State<ExampleStreaming>
{
    private static HowToMultiplyState _instance;

    private HowToMultiplyState()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static HowToMultiplyState Instance
    {
        get
        {
            if (_instance == null)
            {
                new HowToMultiplyState();
            }

            return _instance;
        }
    }

    public override void EnterState(ExampleStreaming _owner)
    {
        Debug.Log("Entering How To Multiply State");
    }

    public override void ExitState(ExampleStreaming _owner)
    {
        Debug.Log("Exiting How To Multiply State");
    }

    public override void UpdateState(ExampleStreaming _owner)
    {
        
    }
}
