using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DirectionalArrow : MonoBehaviour
{
    public GameObject[] targets;
    public Text distanceText;

    private GameObject target;
    private float dist;

    private void Start()
    {
        target = new GameObject();
        dist = 0f;
        foreach (GameObject child in targets)
        {
            if (child.activeSelf == true)
            {
                target = child;
            }
        }
    }

    private void Update()
    {
        foreach (GameObject child in targets)
        {
            if (child.activeSelf == true)
            {
                target = child;
            }
        }
        Vector3 targetPosition = target.transform.position;
        targetPosition.y = transform.position.y;
        transform.LookAt(targetPosition);
        dist = Vector3.Distance(targetPosition, transform.position) * 2;
        UpdateDistance();
        //transform.LookAt(target);
    }

    void UpdateDistance()
    {
        distanceText.text = System.Math.Round(dist, 2) + "m";
    }

}
