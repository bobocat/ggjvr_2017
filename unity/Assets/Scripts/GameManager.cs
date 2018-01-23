using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Collections;

public class GameManager : MonoBehaviour {

    public List<Chapter> chapterList = new List<Chapter>();

    public string currentChapter;
    public int currentChapterIndex;

    private void Awake()
    {
        UpdateChapter();

    }

    // Use this for initialization
    void Start () {

	
	}

	// Update is called once per frame
	void Update () {

		
	}

    // look at the current conditions and figure out what chapter we are in
    void UpdateChapter()
    {
        Debug.Log("updating chapter in gameManager");

        // if we don't find any incomplete chapters than we will return an all complete
        currentChapter = "allComplete";

        // go through the chapters in reverse order to see what the highest incomplete one is
        for (int i = chapterList.Count-1; i >= 0; i--)
        {
            if (chapterList[i].complete == false)
            {
                currentChapter = chapterList[i].name;
                currentChapterIndex = i;
            }
        }

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

    public string GetCurrentChapter()
    {
        return currentChapter;
    }


}
