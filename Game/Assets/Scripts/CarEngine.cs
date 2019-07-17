using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEngine : MonoBehaviour
{
    public Transform path;
    public float maxSteerAngle = 40f;
    public WheelCollider wheelFL;
    public WheelCollider wheelFR;
    public WheelCollider wheelRL;
    public WheelCollider wheelRR;
    public float maxMotorTorque = 180f;
    public float currentSpeed = 0;
    public float maxSpeed = 200f;
    public float maxBreakTorque = 150f;
    public bool isBraking = false;

    public Texture2D textureNormal;
    public Texture2D textureBraking;
    public Renderer carRenderer;
    public Vector3 centerOfMass;
    private List<Transform> nodes;
    private int CurrentNode = 4;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().centerOfMass = centerOfMass;
        Transform[] pathTransforms = path.GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();

        for (int i = 0; i < pathTransforms.Length; i++)
        {
            if (pathTransforms[i] != path.transform)
            {
                nodes.Add(pathTransforms[i]);
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ApplySteer();
        Drive();
        CheckWaypointDistance();
        Braking();
    }

    private void ApplySteer()
    {
        Vector3 relativeVector = transform.InverseTransformPoint(nodes[CurrentNode].position);
        relativeVector = relativeVector/relativeVector.magnitude;
        float newSteer = (relativeVector.x / relativeVector.magnitude)*maxSteerAngle;
        wheelFL.steerAngle = newSteer;
        wheelFR.steerAngle = newSteer; 
    }


    private void Drive()
    {
        currentSpeed = 2*Mathf.PI * wheelFL.radius * wheelFL.rpm * 60 /1000;

        if (currentSpeed < maxSpeed && isBraking == true)
        {
            wheelFL.motorTorque = maxMotorTorque;
            wheelFR.motorTorque = maxMotorTorque;
        } else{
            wheelFL.motorTorque = 0;
            wheelFR.motorTorque = 0;
        }

        


    }

    private void CheckWaypointDistance()
    {
        if(Vector3.Distance(transform.position, nodes[CurrentNode].position) < 1f)
        {
            if(CurrentNode == nodes.Count - 1)
            {
                CurrentNode = 0;
            }
            else{
                CurrentNode++;
            }
        }
        print(nodes.Count + " : " + CurrentNode + " : " + Vector3.Distance(transform.position, nodes[CurrentNode].position));
    }

    private void Braking()
    {
        if(isBraking)
        {
            carRenderer.material.mainTexture = textureBraking;
            //wheelRL.brakeTorque = maxBreakTorque;
            //wheelRR.brakeTorque = maxBreakTorque;
            currentSpeed = 0f;
        }
        else {
            carRenderer.material.mainTexture = textureNormal;
            wheelRL.brakeTorque = 0;
            wheelRR.brakeTorque = 0;
        }
    }
}
