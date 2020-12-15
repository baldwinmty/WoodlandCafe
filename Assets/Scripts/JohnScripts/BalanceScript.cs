using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceScript : MonoBehaviour
{
    public GameObject balanceGO;
    public Rigidbody balanceRB;
    // Start is called before the first frame update
    void Start()
    {
        balanceRB.rotation = Quaternion.Euler(Vector3.zero);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
