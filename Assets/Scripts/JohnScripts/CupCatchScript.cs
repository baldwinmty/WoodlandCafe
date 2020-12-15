using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CupCatchScript : MonoBehaviour
{
    public int pointCounter;
    public Text pointDisplay;

    public GameObject snuggie;
    public GameObject cup;

    private bool hasWon = false;

    //public MiniGameManager miniGameManager;

    public Camera orthoCam;

    public float minXSpawn, maxXSpawn, ySpawn;

    public int winReward, missPenalty;

    [HideInInspector]
    public int touchingSides;
    public Rigidbody2D snuggieRB;
    // Start is called before the first frame update
    void Start()
    {
        //Saving for later:
        //pointDisplay.text = miniGameManager.score;
        snuggie.transform.position = Input.mousePosition;
        snuggieRB = snuggie.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (touchingSides < 2)
        {
            Vector3 mousePos = Input.mousePosition;
            Ray castPoint = orthoCam.ScreenPointToRay(mousePos);
            RaycastHit hit;
            if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
            {
                snuggie.transform.position = hit.point;
                //snuggieRB.velocity = ((transform.right * mousePos.x) + (transform.forward * mousePos.y)) / Time.deltaTime;
                snuggieRB.velocity = (hit.point - snuggie.transform.position) * 10;
            }

            if (cup.transform.position.y < -10)
            {
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
            }
        }
        pointDisplay.text = pointCounter.ToString();

    }
    void FailedToCatch()
    {
        pointCounter -= missPenalty;
        
        cup.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        cup.transform.rotation = Quaternion.Euler(Vector3.zero);
        cup.transform.position = new Vector3(Random.Range(minXSpawn, maxXSpawn), ySpawn);
    }
}
