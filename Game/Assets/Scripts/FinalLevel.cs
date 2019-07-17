using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLevel : MonoBehaviour
{
    public GameObject nextLevelPanel;
    public GameObject[] targets;
    GameObject currentTarget;

    public int option;

    // Start is called before the first frame update
    void Start()
    {
        // hide the level panel
        nextLevelPanel.SetActive(false);
        // active time
        Time.timeScale = 1;

        foreach (GameObject target in targets)
        {
            target.SetActive(false);
        }
        currentTarget = targets[0];
        currentTarget.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            if (option == 1)
            {
                // active time
                Time.timeScale = 0;
                nextLevelPanel.SetActive(true);   
            }
            targets[option].SetActive(false);
            currentTarget = targets[1];     
            currentTarget.SetActive(true);
            option++;
        }       
    }
}
