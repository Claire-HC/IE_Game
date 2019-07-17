using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public GameObject nextLevelPanel;
    public GameObject[] targets;
    GameObject currentTarget;

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

        int option = Random.Range(1, 3);
        switch (option)
        {
            case 1:
                currentTarget = targets[0];
                currentTarget.SetActive(true);
                break;
            case 2:
                currentTarget = targets[1];
                currentTarget.SetActive(true);
                break;
            default:
                print("Cannot find the target");
                break;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Time.timeScale = 0;
            nextLevelPanel.SetActive(true);
            //currentTarget.SetActive(false);
        }
    }

}
