using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    GameObject tutorialObject;
    GameObject pauseObject;
    GameObject finishObject;
    GameObject instructionObject;

    private PointCounter pointCounter;
    private int totalScore;

    private void Start()
    {
        tutorialObject = GameObject.FindGameObjectWithTag("ShowOnTutorial");
        instructionObject = GameObject.FindGameObjectWithTag("ShowOnInstruction");
        hideTutorial();

        Time.timeScale = 1;

        pauseObject = GameObject.FindGameObjectWithTag("ShowOnPause");
        finishObject = GameObject.FindGameObjectWithTag("ShowOnFinish");

        hidePaused();
        hideFinished();

        GameObject pointCounterObject = GameObject.FindWithTag("PointCounter");
        if (pointCounterObject != null)
        {
            pointCounter = pointCounterObject.GetComponent<PointCounter>();
        }
        if (pointCounter == null)
        {
            Debug.Log("Cannot find 'PointCounter' script");
        }

    }

    public void hideTutorial()
    {
        tutorialObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //uses the p button to pause and unpause the game
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                showPaused();
            }
            else if (Time.timeScale == 0)
            {
                Debug.Log("high");
                Time.timeScale = 1;
                hidePaused();
            }
        }

        totalScore = pointCounter.GetTotalScore();
        if (totalScore < 0)
        {
            Time.timeScale = 0;
            showFinished();
        }
    }


    //Reloads the Level
    public void Reload()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    //controls the pausing of the scene
    public void pauseControl()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            showPaused();
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            hidePaused();
        }
    }

    //shows objects with ShowOnPause tag
    public void showPaused()
    {
        pauseObject.SetActive(true);
    }

    //hides objects with ShowOnPause tag
    public void hidePaused()
    {
        pauseObject.SetActive(false);
    }

    public void showFinished()
    {
        finishObject.SetActive(true);
    }

    public void hideFinished()
    {
        finishObject.SetActive(false);
    }

    //loads inputted level
    /*public void LoadLevel(string level)
    {
        Application.LoadLevel(level);
    }*/

    public void LoadScene(int level)
    {
        Application.LoadLevel(level);
    }

    public void OnClickResume()
    {
        if(Time.timeScale == 0)
            {
            Debug.Log("high");
            Time.timeScale = 1;
            hidePaused();
        }
    }

    public void OnClickTutorial()
    {
        tutorialObject.SetActive(true);
    }

    public void OnClickBack()
    {
        tutorialObject.SetActive(false);
    }

    public void OnClickHide()
    {
        instructionObject.SetActive(false);
    }
}
