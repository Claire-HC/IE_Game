using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject wheelFR;
    public GameObject wheelFL;
    public GameObject wheelBR;
    public GameObject wheelBL;

    public WheelCollider WFL;
    public WheelCollider WFR;
    public WheelCollider WBL;
    public WheelCollider WBR;
   

    public GameObject SpeedBox;
    public GameObject warningPanel;
    public Text warningText;
    public GameObject warningPanelForPerson;
    public Text warningTextForPerson;

    public float Torque = 1000f;
    public float loweststeerspeed = 20f;
    public float loweststeerangle = 70f;
    public float higheststeerangle = 40f;
    public float turning = 5f;

    public bool executing;
    public Vector3 centerOfMass;

    public bool isBrake = false;
    public float brakeTorque;
    //public float decelerationForce;

    public int scoreValue;
    private PointCounter pointCounter;

    // Start is called before the first frame update
    void Start()
    {
        executing = false;
        warningPanel.SetActive(false);
        warningPanelForPerson.SetActive(false);
        GetComponent<Rigidbody>().centerOfMass = centerOfMass;
        GameObject pointCounterObject = GameObject.FindWithTag("PointCounter");
        if(pointCounterObject != null)
        {
            pointCounter = pointCounterObject.GetComponent<PointCounter>();
        }
        if(pointCounter == null)
        {
            Debug.Log("Cannot find 'PointCounter' script");
        }
    }

    private void FixedUpdate()
    {
        CarMovement();
        HandBrake();
        double kph = this.GetComponent<Rigidbody>().velocity.magnitude * 3.6; //convert meter per second to km/h
        SpeedBox.GetComponent<Text>().text = "Speed: " + Mathf.RoundToInt((float)kph) + " Km/H";
        if ((Mathf.RoundToInt((float)kph) > 40))
        {
            if(executing == false)
            {
                pointCounter.AddScore(scoreValue);
                warningPanel.SetActive(true);
                warningText.text = "Score Reduction: 5 points\n\nThe speed limit in the city is 40 Km/H, please Slow Down";
                StartCoroutine(WaitForSecs());
            }
        }
    }

    void CarMovement()
    {
        WBL.motorTorque = Torque * Input.GetAxis("Vertical");
        WBR.motorTorque = Torque * Input.GetAxis("Vertical");
        float speedfactor = this.GetComponent<Rigidbody>().velocity.magnitude / loweststeerspeed;
        float currentsteerAngle = Mathf.Lerp(loweststeerangle, higheststeerangle, speedfactor);

        currentsteerAngle *= Input.GetAxis("Horizontal");
        //WFL.steerAngle = currentsteerAngle;
        //WFR.steerAngle = currentsteerAngle;       
        WFL.steerAngle = Input.GetAxis("Horizontal") * turning;
        WFR.steerAngle = Input.GetAxis("Horizontal") * turning;
    }

    IEnumerator WaitForSecs ()
    {
        executing = true;
        yield return new WaitForSeconds(5);
        warningPanel.SetActive(false);
        executing = false;
    }

    // Apply Brake on Car
    void HandBrake()
    {
        //brakeTorque = Mathf.Clamp(Mathf.Abs(WBL.rpm) * 8f, 100, 10000);
        brakeTorque = ((WBL.mass + (this.GetComponent<Rigidbody>().mass / 4)) * Mathf.Pow(this.GetComponent<Rigidbody>().velocity.magnitude, 2));
        if (Input.GetKey(KeyCode.Space))
        {
            isBrake = true;
        }
        else
        {
            isBrake = false;
        }

        if(isBrake == true)
        {
            WBL.brakeTorque = brakeTorque;
            WBR.brakeTorque = brakeTorque;
            WBL.motorTorque = 0;
            WBR.motorTorque = 0;
        }
        else
        {
            WBL.brakeTorque = 0;
            WBR.brakeTorque = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("DamageCollider"))
        {
            // hit AI Car will reduce 10 points
            pointCounter.AddScore(-10);
            warningPanel.SetActive(true);
            warningText.text = "Score Reduction: 10 points\n\nYou hitted another car, please driving safely";
            StartCoroutine(WaitForSecs());
        }
        else if (other.gameObject.CompareTag("AIPedestrian"))
        {
            // hit AI Car will reduce 10 points
            pointCounter.AddScore(-60);
            warningPanelForPerson.SetActive(true);
            warningTextForPerson.text = "\nAccident!!! \n\nYou hit the pedestrian";
            StartCoroutine(WaitForSecs());
        }
        else if (other.gameObject.CompareTag("Tram"))
        {
            // hit AI Car will reduce 10 points
            pointCounter.AddScore(-10);
            warningPanel.SetActive(true);
            warningText.text = "Score Reduction: 10 points\n\nYou hitted the tram, please driving safely";
            StartCoroutine(WaitForSecs());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
