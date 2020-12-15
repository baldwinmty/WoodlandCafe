using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupHolsterScript : MonoBehaviour
{
    public CupCatchScript cCS;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    //private void Update()
    //{
    //    GetComponent<Rigidbody2D>().velocity = cCS.snuggieRB.velocity;
    //}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("CupTrigger"))
        {
            cCS.touchingSides++;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("CupTrigger"))
        {
            cCS.touchingSides--;
        }
    }
}
