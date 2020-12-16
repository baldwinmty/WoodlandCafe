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

    public int pointCounter;
    public int winReward, missPenalty;
    public Text pointDisplay;
    public Button startButton;

    public float xSpawn, ySpawn;
    public float minY;

    public float sensitivity;
    bool hasStarted = false;
    private bool hasWon = false;

    // Start is called before the first frame update
    void Start()
    {
        balanceRB = balanceGO.GetComponent<Rigidbody>();
        balanceRB.rotation = Quaternion.Euler(Vector3.zero);
        cup.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(hasStarted)
        {
            if(Input.GetAxisRaw("Horizontal") != 0)
            {
                balanceRB.AddTorque(balanceRB.transform.forward * sensitivity * -Input.GetAxis("Horizontal"));
            }
            if(cup.transform.position.y <= minY)
            {
                FailedToCatch();
            }
        }
    }
    void FailedToCatch()
    {
        pointCounter -= missPenalty;

        cup.GetComponent<Rigidbody>().velocity = Vector3.zero;
        cup.transform.rotation = Quaternion.Euler(Vector3.zero);
        cup.transform.position = new Vector3(0, ySpawn, 0.8f);
    }
    public void ButtonPressed()
    {
        hasStarted = true;
        startButton.gameObject.SetActive(false);
        cup.SetActive(true);
    }
}
