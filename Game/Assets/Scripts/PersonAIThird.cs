using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PersonAIThird : MonoBehaviour
{
    public Transform path;
    private int destPoint = 16;
    private NavMeshAgent agent;
    private List<Transform> points;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        points = new List<Transform>();
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
        if (!agent.pathPending && agent.remainingDistance < 0.1f)
        {
            GotoNextPoint();
        }
    }

    private void GotoNextPoint()
    {

        if (points.Count == 0)
        {
            return;
        }
        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Count;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Collider"))
        {
            agent.isStopped = true;
            agent.velocity = Vector3.zero;
            transform.LookAt(other.transform);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.CompareTag("Collider"))
        {
            agent.isStopped = true;
            agent.velocity = Vector3.zero;
            transform.LookAt(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        agent.isStopped = false;
    }
}
