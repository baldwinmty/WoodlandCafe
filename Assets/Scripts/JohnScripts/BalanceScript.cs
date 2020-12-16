using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalanceScript : MonoBehaviour
{
    //public GameObject[] cups = new GameObject[0];
    public GameObject cup;
    public GameObject balanceGO;
    private Rigidbody balanceRB;

    public int pointCounter = 3;
    public int pointCounterMax = 3;
    public int winReward, dropPenalty = 1;
    public Text pointDisplay;
    public Button startButton;

    public float xSpawn, ySpawn;
    public float minY;

    public float sensitivity;
    bool hasStarted = false;
    private bool hasWon = false;

    public float minigameTimerLength = 15f;
    private float timeLeft;

    MinigameManager miniMan;

    // Start is called before the first frame update
    private void OnEnable()
    {
        cup.SetActive(false);
        timeLeft = minigameTimerLength;
        cup.transform.localPosition = new Vector3(0, ySpawn, 0.8f);
        pointCounter = pointCounterMax;
        startButton.gameObject.SetActive(true);
        hasStarted = false;

        if (balanceRB != null)
        {
            balanceRB.transform.localRotation = Quaternion.Euler(Vector3.zero);
        }
    }

    void Start()
    {
        balanceRB = balanceGO.GetComponent<Rigidbody>();
        balanceRB.transform.localRotation = Quaternion.Euler(Vector3.zero);    
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
            timeLeft -= Time.deltaTime;

            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                balanceRB.AddTorque(balanceRB.transform.forward * sensitivity * -Input.GetAxis("Horizontal"));
            }
            if (cup.transform.localPosition.y <= minY)
            {
                FailedToCatch();
            }
            if (timeLeft <= 0)
            {
                miniMan.CloseMinigame(pointCounter);
            }
        }
    }
    void FailedToCatch()
    {
        if (pointCounter > 0)
            pointCounter -= dropPenalty;

        pointDisplay.text = pointCounter.ToString();
        cup.GetComponent<Rigidbody>().velocity = Vector3.zero;
        cup.transform.localRotation = Quaternion.Euler(Vector3.zero);
        cup.transform.localPosition = new Vector3(0, ySpawn, 0.8f);
        //balanceRB.velocity = Vector3.zero;
        //balanceRB.transform.localRotation = Quaternion.Euler(Vector3.zero);
    }
    public void ButtonPressed()
    {
        hasStarted = true;
        startButton.gameObject.SetActive(false);
        cup.SetActive(true);
    }
    public void ResetVariables()
    {
        cup.SetActive(false);
    }
}
