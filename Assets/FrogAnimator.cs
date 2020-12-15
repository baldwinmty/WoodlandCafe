//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class FrogAnimator : MonoBehaviour
//{
//    public Animator animator;
//    private bool IsSitting = false;
//    private bool IsHappy = false;
//    private bool IsSad = false;

//    void start()
//    {
//        animator = GetComponent<Animator>();
//    }

//    void Update ()
//    {
//        if(Input.GetKeyDown(KeyCode.Space) && !IsSitting)
//        {
//            animator.SetBool("IsSitting", true);
//            IsSitting = true;
//        }
//        else if (Input.GetKeyDown(KeyCode.Space) && IsSitting)
//        {
//            animator.SetBool("IsSitting", false);
//            IsSitting = false;
//        }
//    }
//}
