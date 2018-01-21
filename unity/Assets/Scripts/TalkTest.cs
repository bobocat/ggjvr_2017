using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VikingCrewTools;

public class TalkTest : MonoBehaviour {

    public string message;

	// Use this for initialization
	void Start () {
        ShowBubble();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ShowBubble()
    {
        VikingCrewTools.UI.SpeechBubbleManager.Instance.AddSpeechBubble(transform, message);


    }

}
