using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SideLaneController : MonoBehaviour
{
    public GameObject warningPanel;
    public Text warningText;

    public int scoreValue;
    private PointCounter pointCounter;

    private void Start()
    {
        warningPanel.SetActive(false);
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pointCounter.AddScore(scoreValue);
            warningPanel.SetActive(true);
            warningText.text = "Score Reduction: 1 point\n\nOops! You shouldn't cross the line";
            StartCoroutine(WaitForSecs());
        }
    }

    /*private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
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
