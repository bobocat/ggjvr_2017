using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        try
        {
            transform.position = VRTK.VRTK_DeviceFinder.HeadsetTransform().position;
            transform.rotation = VRTK.VRTK_DeviceFinder.HeadsetTransform().rotation;
        }
        catch { }


    }

}
