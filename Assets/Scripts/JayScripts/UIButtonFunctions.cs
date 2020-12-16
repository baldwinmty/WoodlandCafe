using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonFunctions : MonoBehaviour
{
    public GameObject Menu;

    public GameObject PauseMenu;

    public void ChangeScene(int sceneIndex)
    {
        Time.timeScale = 1f;
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

    public void PauseGame()
    {
        if (PauseMenu != null)
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void UnpauseGame()
    {
        if (PauseMenu != null)
        {
            PauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
