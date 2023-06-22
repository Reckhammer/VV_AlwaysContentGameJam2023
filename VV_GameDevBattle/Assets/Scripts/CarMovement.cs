using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class CarMovement : MonoBehaviour
{
    public Transform waypoints;
    public NavMeshAgent agent;
    public float finishDistance = 1f;
    private int currentWaypoint;
    private NavMeshPath currentPath;
    private Vector3 currentVel;

    private Vector3 NextPoint => currentWaypoint < waypoints.childCount ? waypoints.GetChild(currentWaypoint).position : Vector3.zero;

    private void Start()
    {
        agent.updatePosition = false;
        agent.updateRotation = false;
        agent.destination = NextPoint;
    }

    private void Update()
    {
        transform.position += transform.forward * Time.deltaTime * agent.speed;
        transform.forward = Vector3.SmoothDamp(transform.forward, (NextPoint - transform.position), ref currentVel, Time.deltaTime * agent.angularSpeed);
        if (Vector3.Distance(transform.position, agent.destination) < finishDistance)
        {
            currentWaypoint++;
        }

        if (currentWaypoint >= waypoints.childCount)
        {
            enabled = false;
        }
        else
        {
            agent.destination = NextPoint;
        }
        agent.Warp(transform.position);
        agent.destination = NextPoint;
    }
}
