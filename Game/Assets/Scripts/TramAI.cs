using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TramAI : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject goal;
    private float distance;
    Vector3 startPos;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        startPos = this.transform.position;
        distance = Vector3.Distance(transform.position, goal.transform.position);
        //agent.destination = goal.position;     
        StartCoroutine(Route());
    }

    IEnumerator Route()
    {
        while(true)
        {
            agent.destination = goal.transform.position;
            yield return new WaitForSecondsRealtime(distance / agent.speed + 3);
            transform.position = startPos;
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


