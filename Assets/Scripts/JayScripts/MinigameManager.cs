using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    public GameObject CupCatchMinigame;
    public GameObject BalanceMinigame;
    public GameObject JigsawMinigame;

    private ScoreManager scoreManager;

    private GameObject[] allMinigames;

    private bool minigameActive = false;

    private void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();

        allMinigames = new GameObject[] { CupCatchMinigame, BalanceMinigame, JigsawMinigame };

        foreach (var minigame in allMinigames)
        {
            minigame.SetActive(false);
        }
    }

    public void TriggerMinigame()
    {
        if (!minigameActive)
        {
            allMinigames[Random.Range(0, allMinigames.Length)].SetActive(true);
            minigameActive = true;
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
    }
}
