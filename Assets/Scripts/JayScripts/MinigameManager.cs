using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    //public GameObject CupCatchMinigame;
    //public GameObject BalanceMinigame;
    public GameObject JigsawMinigame;

    private ScoreManager scoreManager;

    private GameObject[] allMinigames;

    private bool minigameActive = false;
    private MinigameTrigger activeGame;

    private void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();

        allMinigames = new GameObject[] { /*CupCatchMinigame, BalanceMinigame,*/ JigsawMinigame };

        foreach (var minigame in allMinigames)
        {
            minigame.SetActive(false);
        }
    }

    public void TriggerMinigame(MinigameTrigger game)
    {
        if (!minigameActive)
        {
            allMinigames[Random.Range(0, allMinigames.Length)].SetActive(true);
            minigameActive = true;
            activeGame = game;
            FindObjectOfType<PlayerController>().enabled = false;
        }
    }

    public void CloseMinigame(int point)
    {
        foreach (var minigame in allMinigames)
        {
            minigame.SetActive(false);
        }

        minigameActive = false;

        if (scoreManager != null)
        {
            scoreManager.AwardReaction(Mathf.Clamp(point, 0, 2));
        }

        activeGame.FinishedMinigame(Mathf.Clamp(point, 0, 2));
        FindObjectOfType<PlayerController>().enabled = true;
    }
}
