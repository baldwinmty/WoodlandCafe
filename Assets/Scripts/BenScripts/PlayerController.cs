using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public UIButtonFunctions PauseMenu;

    public float speed;
    public float smoothTime;
    float smoothVel;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(horizontal, 0f, vertical).normalized;

        if(dir.magnitude >= 0.1f)
        {
            float tarAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            Animator animator = controller.GetComponent<Animator>();
            if(animator != null)
            {
                animator.SetBool("Moving", true);
            }
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, tarAngle, ref smoothVel, smoothTime);
            transform.rotation = Quaternion.Euler(0f, tarAngle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, tarAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        if (dir.magnitude <= 0f)
        {
            Animator animator = controller.GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetBool("Moving", false);
            }
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            Animator animator = controller.GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetTrigger("Wave");
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu.PauseGame();
        }
    }
}
