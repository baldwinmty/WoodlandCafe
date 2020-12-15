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

    public Camera orthoCam;

    private Vector3 correctedMousePos;

    // Start is called before the first frame update
    void Start()
    {
        snuggie.transform.position = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        Ray castPoint = orthoCam.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
        {
            snuggie.transform.position = hit.point;
        }

        //snuggie.transform.position = correctedMousePos;

    }
}
