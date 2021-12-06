using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coroutines : MonoBehaviour
{
    public Transform[] waypoints;
    int currentWaypoint;
    int speed;
    IEnumerator currentCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        speed = 7;
        currentWaypoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // if a coroutine is already running then stop it
            if (currentCoroutine != null)
            {
                StopCoroutine(currentCoroutine);
            }
            // start a new coroutine to move the cube to the current waypoint and keep track of it in the
            // currentCoroutine
            currentCoroutine = Move(waypoints[currentWaypoint].position, speed);
            StartCoroutine(currentCoroutine);
            // now that the couroutine is off and running we can update the waypoint index
            currentWaypoint += 1;
            if (currentWaypoint >= waypoints.Length)
            {
                currentWaypoint = 0;
            }
        }
    }

    // Each update this will run until it hits the yield statement
    IEnumerator Move(Vector3 destination, int speed)
    {
        while (Vector3.Distance(transform.position, destination) >= 1)
        {
            // the destination - the current position normalized equals the direction to move
            // could also just use Vector.MoveToward() but I want to make sure I understand this
            transform.position += (destination - transform.position).normalized * speed * Time.deltaTime;
            print(Vector3.Distance(transform.position, destination));
            yield return null;
        }
    }
}