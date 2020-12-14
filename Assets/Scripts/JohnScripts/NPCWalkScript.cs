﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCWalkScript : MonoBehaviour
{
    public Transform[] locations = new Transform[2];
    private Vector3 currentDestination;
    public int nextDestination;
    bool atDestination = true;
    bool bLock = false;
    public float moveSpeed = 300;
    public float minDistance;
    public float currentWait, maxWait;
    public bool randomWait = false;
    public float randomWaitMin, randomWaitMax;

    public NavMeshAgent nMA;
    

    // Start is called before the first frame update
    void Start()
    {
        nMA = gameObject.GetComponent<NavMeshAgent>();
        currentDestination = locations[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        //If farther than the minimum distance, move towards the destination.
        if (Vector3.Distance(gameObject.transform.position, currentDestination) >= minDistance)
        {
            atDestination = false;
            WalkNM(currentDestination);
            bLock = false;
        }
        else
        {
            atDestination = true;
        }
        //Prevents the script from looping and resetting the count down timer.
        //If the randomWait bool is set to true, generates a random time within the corresponding constraints. 
        if(bLock == false && atDestination)
        {
            currentWait = 0;
            if(randomWait)
            {
                maxWait = Random.Range(randomWaitMin, randomWaitMax);
            }
            bLock = true;
        }

        //Waits for the time its waited to exceed the maxWait set.
        //Once done waiting, it sets a new destination.
        if (bLock && atDestination)
        {
            if (currentWait < maxWait)
            {
                currentWait += Time.deltaTime;
            }
            else
            {
                if(nextDestination < locations.Length - 1)
                {
                    nextDestination++;
                }
                else
                {
                    nextDestination = 0;
                }
                currentDestination = locations[nextDestination].position;
            }
        }
    }
    
    //Tells the player where to face and move.
    private void Walk(Vector3 destination)
    {
        gameObject.transform.LookAt(destination);
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, destination, moveSpeed * Time.deltaTime);
    }

    //Walk code but repurposed to work with navmesh
    private void WalkNM(Vector3 destination)
    {
        //nMA.transform.LookAt(destination);
        nMA.SetDestination(destination);
    }
}
