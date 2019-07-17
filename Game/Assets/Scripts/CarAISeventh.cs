using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarAISeventh : MonoBehaviour
{
    public Transform path;
    private List<Transform> points;
    private int destPoint = 21;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        Transform[] pathTransforms = path.GetComponentsInChildren<Transform>();
        points = new List<Transform>();
        for (int i = 0; i < pathTransforms.Length; i++)
        {
            if (pathTransforms[i] != path.transform)
            {
                points.Add(pathTransforms[i]);
            }
        }
    }

    void FixedUpdate()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }

    void GotoNextPoint()
    {
        if (points.Count == 0)
            return;

        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Count;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("StopCollider") || other.transform.CompareTag("Player") || other.transform.CompareTag("HitCollider") || other.transform.CompareTag("AIPedestrian") || other.transform.CompareTag("Tram"))
        {
            agent.isStopped = true;
            agent.velocity = Vector3.zero;
            agent.autoBraking = true;
            //transform.LookAt(other.transform);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.CompareTag("StopCollider") || other.transform.CompareTag("Player") || other.transform.CompareTag("HitCollider") || other.transform.CompareTag("AIPedestrian") || other.transform.CompareTag("Tram"))
        {
            agent.isStopped = true;
            agent.velocity = Vector3.zero;
            //transform.LookAt(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        agent.isStopped = false;
        agent.autoBraking = false;
    }
}
