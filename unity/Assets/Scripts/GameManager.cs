using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Collections;

public class GameManager : MonoBehaviour {

    public List<Chapter> chapterList = new List<Chapter>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CompleteCondition(string conditionName)
    {
        Debug.Log("completing condition: " + conditionName);

        foreach (Chapter chapter in chapterList)
        {
            foreach (Condition condition in chapter.conditions)
            {
                if (condition.name == conditionName)
                {
                    condition.complete = true;
                }
            }
        }
    }

}
