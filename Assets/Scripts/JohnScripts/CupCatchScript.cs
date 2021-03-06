﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CupCatchScript : MonoBehaviour
{
    public int pointCounter = 3;
    public int pointCounterMax = 3;
    public Text pointDisplay;
    public Button startButton;

    public GameObject snuggie;
    public GameObject cup;

    bool hasStarted = false;
    private bool hasWon = false;

    //public MiniGameManager miniGameManager;

    public Camera orthoCam;

    public float minXSpawn, maxXSpawn, ySpawn;
    public float minYPos;

    public int winReward, missPenalty;

    MinigameManager miniMan;

    [HideInInspector]
    public int touchingSides;
    public Rigidbody2D snuggieRB;

    private void OnEnable()
    {
        cup.SetActive(false);
        snuggie.transform.position = Input.mousePosition;
        cup.transform.localPosition = new Vector3(Random.Range(minXSpawn, maxXSpawn), ySpawn, snuggie.transform.localPosition.z);
        pointCounter = pointCounterMax;
        startButton.gameObject.SetActive(true);
        hasWon = false;
    }


    // Start is called before the first frame update
    void Start()
    {
        //Saving for later:
        //pointDisplay.text = miniGameManager.score;
        cup.SetActive(false);
        snuggie.transform.localPosition = Input.mousePosition;
        snuggieRB = snuggie.GetComponent<Rigidbody2D>();
        cup.GetComponent<Rigidbody2D>().isKinematic = true;
    }
    private void Awake()
    {
        miniMan = FindObjectOfType<MinigameManager>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (hasStarted)
        {
            if (touchingSides < 2)
            {
                Vector3 mousePos = Input.mousePosition;
                Ray castPoint = orthoCam.ScreenPointToRay(mousePos);
                RaycastHit hit;
                if (Physics.Raycast(castPoint, out hit, Mathf.Infinity, ~8, QueryTriggerInteraction.Collide))
                {
                    snuggie.transform.position = hit.point;
                    //snuggieRB.velocity = ((transform.right * mousePos.x) + (transform.forward * mousePos.y)) / Time.deltaTime;
                    snuggieRB.velocity = (hit.point - snuggie.transform.position) * 10;
                }

                if (cup.transform.localPosition.y < minYPos)
                {
                    Debug.Log("Resetting cup");
                    FailedToCatch();
                }
            }
            else
            {
                if (hasWon == false)
                {
                    Debug.Log("WIN!");
                    pointCounter += winReward;
                    hasWon = true;
                    miniMan.CloseMinigame(pointCounter);
                }
            }
            pointDisplay.text = pointCounter.ToString();

        }
    }
    void FailedToCatch()
    {
        if(pointCounter > 0)
        pointCounter -= missPenalty;
        
        cup.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        cup.transform.localRotation = Quaternion.Euler(Vector3.zero);
        cup.transform.localPosition = new Vector3(Random.Range(minXSpawn, maxXSpawn), ySpawn, snuggie.transform.localPosition.z);
    }
    public void ButtonPressed()
    {
        hasStarted = true;
        cup.SetActive(true);
        cup.GetComponent<Rigidbody2D>().isKinematic = false;
        startButton.gameObject.SetActive(false);
    }
}
