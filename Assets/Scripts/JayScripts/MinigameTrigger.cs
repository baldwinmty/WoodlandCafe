using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameTrigger : MonoBehaviour
{
    private MinigameManager manager;
    private bool playerInRange = false;
    private bool minigameDone = false;

    public float timeUntilDestruction = 3f;

    public GameObject mainObject;
    public SpriteRenderer currentEmotion;
    public Sprite talk;
    public Sprite[] emotions;

    private void Awake()
    {
        manager = FindObjectOfType<MinigameManager>();
        currentEmotion.sprite = null;
    }

    private void Update()
    {
        if (timeUntilDestruction < 0)
        {
            Destroy(mainObject);
        }

        if (minigameDone)
        {
            timeUntilDestruction -= Time.deltaTime;
        }

        if (playerInRange && !minigameDone)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                manager.TriggerMinigame(this);
            }
        }
    }

    public void FinishedMinigame(int reaction)
    {
        currentEmotion.sprite = emotions[reaction];
        minigameDone = true;

        NPCWalkScript animal = mainObject.GetComponent<NPCWalkScript>();
        animal.miniGameWon = true;
        switch (reaction)
        {
            case 0:
                animal.endOfMinigameAnim = "IsSad";
                break;
            case 1:
            default:
                animal.endOfMinigameAnim = "IsSitting";
                break;
            case 2:
                animal.endOfMinigameAnim = "IsHappy";
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !minigameDone)
        {
            playerInRange = true;
            currentEmotion.sprite = talk;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !minigameDone)
        {
            playerInRange = false;
            currentEmotion.sprite = null;
        }
    }
}