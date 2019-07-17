using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightTrafficLightsController : MonoBehaviour
{
    public GameObject red;
    public GameObject green;
    public GameObject yellow;

    // Start is called before the first frame update
    void Start()
    {
        red.SetActive(false);
        yellow.SetActive(false);
        green.SetActive(true);
        // start function Change as a coroutine: the execution of a coroutine can be paused at any point using the yield statement.
        StartCoroutine(Change());
    }

    IEnumerator Change()
    {
        while (true)
        {
            green.SetActive(true);
            red.SetActive(false);
            // Green light
            yield return new WaitForSecondsRealtime(9);

            green.SetActive(false);
            yellow.SetActive(true);
            // Yellow light
            yield return new WaitForSecondsRealtime(1);

            red.SetActive(true);
            yellow.SetActive(false);
            // Red light
            yield return new WaitForSecondsRealtime(10);
        }
    }

}
