using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarAIOneWay : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject goal;
    private float distance;
    Vector3 startPos;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        startPos = this.transform.position;
        distance = Vector3.Distance(startPos, goal.transform.position);
        StartCoroutine(Route());
    }

    IEnumerator Route()
    {
        while (true)
        {
            agent.destination = goal.transform.position;
            yield return new WaitForSecondsRealtime(distance / agent.speed);
            this.transform.position = startPos;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("StopCollider") || other.transform.CompareTag("Player"))
        {
            agent.isStopped = true;
            agent.velocity = Vector3.zero;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.CompareTag("StopCollider") || other.transform.CompareTag("Player"))
        {
            agent.isStopped = true;
            agent.velocity = Vector3.zero;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        agent.isStopped = false;
    }
}
