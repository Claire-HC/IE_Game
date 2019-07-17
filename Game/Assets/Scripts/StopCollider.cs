using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopCollider : MonoBehaviour
{
    public GameObject redLight;
    private bool moving;
    Vector3 startPos;

    // Warning message
    public GameObject warningPanel;
    public Text warningText;

    // Score count
    public int scoreValue;
    private PointCounter pointCounter;

    // Start is called before the first frame update
    void Start()
    {
        moving = true;
        startPos = this.transform.position;
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

    private void Update()
    {
        if (redLight.activeSelf == true)
        {
            this.transform.position = startPos;
            moving = true;
        }
        else if (redLight.activeSelf == false && moving)
        {
            this.transform.position = new Vector3(transform.position.x, transform.position.y + 3.0f, transform.position.z);
            moving = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (redLight.activeSelf == true)
            {
                pointCounter.AddScore(scoreValue);
                warningPanel.SetActive(true);
                warningText.text = "Score Reduction: 5 points\n\nRunning the Red Light. Please obey traffic rules";
                StartCoroutine(WaitForSecs());
                //Debug.Log("Fail");
            }
        }
    }

    /*private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(WaitForSec());
            warningPanel.SetActive(false);
        }
    }*/

    IEnumerator WaitForSecs()
    {
        yield return new WaitForSeconds(7);
        warningPanel.SetActive(false);
    }
}
