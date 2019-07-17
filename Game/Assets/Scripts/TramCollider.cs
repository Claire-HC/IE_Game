using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TramCollider : MonoBehaviour
{
    public GameObject redLight;
    private bool moving;
    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        moving = true;
        startPos = this.transform.position;
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
            this.transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
            moving = false;
        }
    }

}
