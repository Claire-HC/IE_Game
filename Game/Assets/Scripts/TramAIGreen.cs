using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TramAIGreen : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform goal;
    private float distance;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        distance = Vector3.Distance(transform.position, goal.position);
        StartCoroutine(Route());
    }

    IEnumerator Route()
    {
        while (true)
        {
            agent.destination = goal.position;
            yield return new WaitForSecondsRealtime(distance / agent.speed);
            transform.position = new Vector3(-839.97f, 0.11f, -596.3f);
            yield return new WaitForSecondsRealtime(1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("StopCollider"))
        {
            agent.isStopped = true;
            agent.velocity = Vector3.zero;
            //transform.LookAt(other.transform);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.CompareTag("StopCollider"))
        {
            agent.isStopped = true;
            agent.velocity = Vector3.zero;
            //transform.LookAt(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        agent.isStopped = false;
    }
}
