using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    // Array coresponds to reactions- 0 frown, 1 neutral, 2 smile.
    public int[] reactions = new int[3];

    public GameObject endOfDayUI;

    public TextMeshProUGUI[] reactionTallies;

    private void Awake()
    {
        endOfDayUI.SetActive(false);
    }

    // Called at the end of a minigame, based on how well the player performed.
    // int reaction is the index to award the point to.
    public void AwardReaction(int reaction)
    {
        reactions[reaction]++;
    }

    public void OpenEndOfDayUI()
    {
        // Activate the element containing the end of day screen.
        if (!endOfDayUI.activeInHierarchy)
        {
            endOfDayUI.SetActive(true);
        }

        // Write the values from the reactions array to the ui element.
        for (int i = 0; i < reactions.Length; i++)
        {
            reactionTallies[i].text = reactions[i].ToString();
        }
    }
}
