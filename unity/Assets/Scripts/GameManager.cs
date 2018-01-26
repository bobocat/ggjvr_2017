using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Collections;
using VRTK;

public class GameManager : MonoBehaviour {

    public List<Chapter> chapterList = new List<Chapter>();

    public string currentChapter;
    public int currentChapterIndex;

    public Transform MollonkaStart;
    public Transform DeathStart;
    public Transform FatherStart;
    public Transform theVoid;               // a safe area where the headBall won't run into anything

    public VRTK.VRTK_BasicTeleport teleporter;

    //    public DestinationMarker marker;

    public Animator titleAnimator;          // anim controller for the titles

    public Transform sceneScaleObject;      // the object that we will scale to change the scene scale. top of the environment hierarchy

    private float sceneScaleMollonka = 1f;
    private float sceneScaleDeath = 1.4f;
    private float sceneScaleFather = 1f;

    private HeadBall headBall;              // the black sphere over the player's head that we use for fades. This allows us to have text overlays inside it.

    private void Awake()
    {
        UpdateChapter();

        headBall = GameObject.FindObjectOfType<HeadBall>();

    }

    // Use this for initialization
    void Start () {



//        headBall.FadeToBlack();
        StartCoroutine(TitlesOpening());

//        Invoke("Fade", 6f);

//        Invoke("ChangeToMollonka", 6f);

//        Invoke("ChangeToDeath", 6f);

//        Invoke("ChangeToFather", 16f);


    }

    IEnumerator TitlesOpening()
    {

        Debug.Log("titles opening 1");

        yield return new WaitForSeconds(1);

        //teleporter.ForceTeleport(theVoid.position);
//        TeleportFast(theVoid);

        Debug.Log("titles opening 2");

//        headBall.SetToBlack();

        yield return new WaitForSeconds(6);

        Debug.Log("titles opening 3");

        // start with a black screen
        //        GetComponent<VRTK_HeadsetFade>().Fade(Color.black, 0f);

        //        yield return new WaitForSeconds(3);

        titleAnimator.Play("title_mollonka");
        yield return new WaitForSeconds(8);

        GetComponent<VRTK_HeadsetFade>().Fade(Color.black, 0f);

        TeleportFast(MollonkaStart);

//        headBall.SetToClear();

        GetComponent<VRTK_HeadsetFade>().Unfade(3f);

        //        GetComponent<VRTK_HeadsetFade>().Unfade(3f);

        Debug.Log("titles opening 6");

    }

    void TeleportFast(Transform destination)
    {
        Quaternion q = Quaternion.Inverse(VRTK.VRTK_DeviceFinder.HeadsetTransform().rotation) * destination.rotation;

        teleporter.Teleport(destination, destination.position, q, true);

        Debug.Log("teleporting fast");
    }


    IEnumerator TeleportIE (Transform targetTransform)
    {

        GetComponent<VRTK_HeadsetFade>().Fade(Color.black, 3f);
        yield return new WaitForSeconds(3);

        Quaternion q = Quaternion.Inverse(VRTK.VRTK_DeviceFinder.HeadsetTransform().rotation) * targetTransform.rotation;

//        teleporter.ForceTeleport(targetTransform.position, q);
        teleporter.Teleport(targetTransform,targetTransform.position,q,true);

//        GetComponent<VRTK_HeadsetFade>().Fade(Color.black, 0f);

        Debug.Log("teleporting");

        //        GetComponent<VRTK_HeadsetFade>().Unfade(5f);

//        return null;

    }

    public void SetSceneScale(float scale)
    {
        sceneScaleObject.transform.localScale = new Vector3(scale,scale,scale);       
    }


    public void ChangeToMollonka()
    {
        StartCoroutine(TeleportIE(MollonkaStart));

        SetSceneScale(sceneScaleMollonka);

    }

    public void ChangeToDeath()
    {
        StartCoroutine(TeleportIE(DeathStart));

        SetSceneScale(sceneScaleDeath);
    }

    public void ChangeToFather()
    {
        StartCoroutine(TeleportIE(FatherStart));

        SetSceneScale(sceneScaleFather);
    }

    /*
        void Teleport()
        {

            Quaternion q = Quaternion.Inverse(VRTK.VRTK_DeviceFinder.HeadsetTransform().rotation) * MollonkaStart.rotation;

            teleporter.Teleport(MollonkaStart,MollonkaStart.position,q,true);

            Debug.Log("teleporting");

            GetComponent<VRTK_HeadsetFade>().Unfade(.3f);
        }
    */
    void Fade()
    {

        GetComponent<VRTK_HeadsetFade>().Fade(Color.black, 3f);


//        marker.SetDestination(MollonkaStart.gameObject);
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
