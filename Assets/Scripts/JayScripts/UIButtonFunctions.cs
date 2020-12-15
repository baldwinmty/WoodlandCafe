using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonFunctions : MonoBehaviour
{
    public GameObject Menu;

    public void ChangeScene(int sceneIndex)
    {
        GameManager.Instance.ChangeScene(sceneIndex);
    }

    public void QuitGame()
    {
        GameManager.Instance.QuitGame();
    }

    public void MenuSlider()
    {
        if(Menu != null)
        {
            Animator animator = Menu.GetComponent<Animator>();
            if(animator != null)
            {
                animator.SetBool("Move", true);
            }
        }
    }

    public void MenuSliderUp()
    {
        if (Menu != null)
        {
            Animator animator = Menu.GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetBool("Move", false);
            }
        }
    }
}
