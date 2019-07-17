using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaneController : MonoBehaviour
{
    public GameObject warningPanel;
    public Text warningText;

    private void Start()
    {
        warningPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collider"))
        {
            warningPanel.SetActive(true);
            warningText.text = "Oops! Please Keep Left";
            StartCoroutine(WaitForSecs());
        }
    }

    /*private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Collider"))
        {
            warningPanel.SetActive(false);
        }
    }*/

    IEnumerator WaitForSecs()
    {
        yield return new WaitForSeconds(5);
        warningPanel.SetActive(false);
    }
}
