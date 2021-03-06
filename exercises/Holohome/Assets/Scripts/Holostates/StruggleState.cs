﻿using UnityEngine;
using System.Collections;
using IBM.Watson.DeveloperCloud.Logging;
using IBM.Watson.DeveloperCloud.Services.SpeechToText.v1;
using IBM.Watson.DeveloperCloud.Utilities;
using IBM.Watson.DeveloperCloud.DataTypes;
using System.Collections.Generic;
using UnityEngine.UI;
using Holostates;

public class StruggleState : State<ExampleStreaming>
{
    private static StruggleState _instance;

    private StruggleState()
    {
        if (_instance != null)
        {
            return;
        }

        _instance = this;
    }

    public static StruggleState Instance
    {
        get
        {
            if (_instance == null)
            {
                new StruggleState();
            }

            return _instance;
        }
    }

    public override void EnterState(ExampleStreaming _owner)
    {
        Debug.Log("Entering Struggle State");
    }

    public override void ExitState(ExampleStreaming _owner)
    {
        Debug.Log("Exiting Struggle State");
    }

    public override void UpdateState(ExampleStreaming _owner)
    {
        
    }
}
