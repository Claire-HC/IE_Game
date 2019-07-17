using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftTrafficLightsController : MonoBehaviour
{
    public GameObject red;
    public GameObject green;
    public GameObject yellow;

    // Start is called before the first frame update
    void Start()
    {
        green.SetActive(false);
        yellow.SetActive(false);
        red.SetActive(true);
        // start function Change as a coroutine: the execution of a coroutine can be paused at any point using the yield statement.
        StartCoroutine(Change());
    }

    IEnumerator Change()
    {
        while (true)
        {
            red.SetActive(true);
            yellow.SetActive(false);
            // Red light
            yield return new WaitForSecondsRealtime(10);

            red.SetActive(false);
            green.SetActive(true);
            // Green light
            yield return new WaitForSecondsRealtime(9);

            yellow.SetActive(true);
            green.SetActive(false);
            // Yellow light
            yield return new WaitForSecondsRealtime(1);
        }
    }

}
