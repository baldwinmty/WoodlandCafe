using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    // Start is called before the first frame update
    void Start()
    {
        currentDestination = locations[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(gameObject.transform.position, currentDestination) >= minDistance)
        {
            atDestination = false;
            Walk(currentDestination);
            bLock = false;
        }
        else
        {
            atDestination = true;
        }
        if(bLock == false && atDestination)
        {
            currentWait = 0;
            if(randomWait)
            {
                maxWait = Random.Range(randomWaitMin, randomWaitMax);
            }
            bLock = true;
        }
        if (bLock && atDestination)
        {
            if (currentWait < maxWait)
            {
                currentWait += Time.deltaTime;
            }
            else
            {
                if(nextDestination < locations.Length)
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
    

    private void Walk(Vector3 destination)
    {
        gameObject.transform.LookAt(destination);
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, destination, moveSpeed * Time.deltaTime);
    }
}
