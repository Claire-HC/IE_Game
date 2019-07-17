using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPedestrianLightController : MonoBehaviour
{
    public GameObject redLight;
    public GameObject greenLight;

    // Start is called before the first frame update
    void Start()
    {
        greenLight.SetActive(true);
        redLight.SetActive(false);
        StartCoroutine(Change());
    }

    IEnumerator Change()
    {
        while (true)
        {
            // Green Light
            greenLight.SetActive(true);
            redLight.SetActive(false);
            yield return new WaitForSecondsRealtime(10);

            // Red Light
            greenLight.SetActive(false);
            redLight.SetActive(true);
            yield return new WaitForSecondsRealtime(10);

        }
    }

}
