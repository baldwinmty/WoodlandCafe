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
    void Start()
    {
        balanceRB = balanceGO.GetComponent<Rigidbody>();
        balanceRB.rotation = Quaternion.Euler(Vector3.zero);
        cup.SetActive(false);
        timeLeft = minigameTimerLength;
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
        pointCounter -= dropPenalty;

        cup.GetComponent<Rigidbody>().velocity = Vector3.zero;
        cup.transform.rotation = Quaternion.Euler(Vector3.zero);
        cup.transform.localPosition = new Vector3(0, ySpawn, 0.8f);
    }
    public void ButtonPressed()
    {
        hasStarted = true;
        startButton.gameObject.SetActive(false);
        cup.SetActive(true);
    }
}
