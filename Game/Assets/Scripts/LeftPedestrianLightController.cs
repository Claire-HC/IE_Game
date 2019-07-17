using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftPedestrianLightController : MonoBehaviour
{
    public GameObject redLight;
    public GameObject greenLight;

    // Start is called before the first frame update
    void Start()
    {
        redLight.SetActive(true);
        greenLight.SetActive(false);
        StartCoroutine(Change());
    }

    IEnumerator Change()
    {
        while (true)
        {
            // Red Light
            greenLight.SetActive(false);
            redLight.SetActive(true);
            yield return new WaitForSecondsRealtime(10);

            // Green Light
            greenLight.SetActive(true);
            redLight.SetActive(false);
            yield return new WaitForSecondsRealtime(10);
        }
    }


}
