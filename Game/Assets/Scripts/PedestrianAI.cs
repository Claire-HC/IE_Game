using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PedestrianAI : MonoBehaviour
{
    public List<Transform> points1;
    //public List<Transform> points2;
    private int destPoint = 0;
    private NavMeshAgent agent;
    private Animation myAnimation;
    private List<Transform> points;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        myAnimation = GetComponent<Animation>();
        points = new List<Transform>();
        //int number = Random.Range(0, 2);
        //if (number == 0)
        //{
            points = points1;
        //}
        //else
       // {
          //  points = points2;
       // }
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
        myAnimation.Play("Run");
        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Count;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Collider"))
        {
            myAnimation.Play("Idle");
            agent.isStopped = true;
            agent.velocity = Vector3.zero;
            transform.LookAt(other.transform);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.CompareTag("Collider"))
        {
            myAnimation.Play("Idle");
            agent.isStopped = true;
            agent.velocity = Vector3.zero;
            transform.LookAt(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        agent.isStopped = false;
        myAnimation.Play("Run");
    }

}
