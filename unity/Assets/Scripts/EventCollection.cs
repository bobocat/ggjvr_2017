using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Collections;

//[System.Serializable]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Animator))]
public class EventCollection : MonoBehaviour{

    public List<EventGroup> eventGroupList = new List<EventGroup>();

    private GameManager gameManager;

    public TextBubbleSimple textBubble;
    public Animator anim;
    public AudioSource audioSource;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();

    }

    public void TriggerEvent()
    {
        // go through the events in the list
        foreach (EventGroup eventGroup in eventGroupList)
        {
            // find the first event that is incomplete and do the stuff in it
            if (eventGroup.complete == false)
            {
                // do the stuff in the event
                if (eventGroup.textMessage.text != "")
                {
                    textBubble.ShowMessage(eventGroup.textMessage.text, eventGroup.textMessage.delay);
                }

                // mark the event as complete
                eventGroup.complete = true;

                // update the condition in the gameManager
                gameManager.CompleteCondition(eventGroup.gmCondition);

                break;
            }

        }

    }

}
