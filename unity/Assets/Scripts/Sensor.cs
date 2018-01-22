using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Sensor : MonoBehaviour {

    public int triggerCount = 0;

    public UnityEvent touched;
    public UnityEvent triggered;

    public bool useLookedAt = false;
    public float lookAtSeconds = .5f;       // how long the player has to look at this sensor for it to activate
    private float lookAtStart = 0f;         // when did they start looking at this sensor
    private bool beingLookedAt = false;     // are we being looked at?
    private float lookAtTimePassed = 0f;    // how long have we been looked at?
    public UnityEvent lookedAt;

    public UnityEvent grabbed;
    public UnityEvent clicked;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


    }


    void FixedUpdate()
    {

        if (useLookedAt)
        {
            if (lookAtTimePassed > lookAtSeconds)
            {
                Debug.Log(gameObject.name + "  has been lookAtTriggered!");
                lookedAt.Invoke();
            }
            else if (lookAtTimePassed > 0f)
            {
                lookAtTimePassed -= Time.deltaTime * .15f;
            }
        }

    }

    public void OnLookedAt()
    {
        lookAtTimePassed += Time.deltaTime;
//        Debug.Log("someone is looking at us! " + lookAtTimePassed);
    }

    private void OnTriggerEnter(Collider other)
    {
        // screen this so it only reacts to the body entering the trigger
        if (other.gameObject.name.Contains("Body"))
        {
//            Debug.Log(gameObject.name + "  triggered " + other.gameObject.name);
            triggered.Invoke();
            triggerCount++;
        }
        else if (other.gameObject.name.Contains("Index"))
        {
//            Debug.Log(gameObject.name + "  touched "+other.gameObject.name);
            touched.Invoke();
            triggerCount++;
        }
        else
        {
//            Debug.Log(gameObject.name + "  touched " + other.gameObject.name);
        }


    }

}
