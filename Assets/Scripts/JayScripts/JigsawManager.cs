using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JigsawManager : MonoBehaviour
{
    // TODO: this will be a script that chooses the jigsaw difficulty and checks for pieces for the right order.
    // It will include:
    // A reference to the jigsaw UI.
    public GameObject[] puzzleUIS;

    public GameObject[] easyPieces;
    public GameObject[] mediumPieces;
    public GameObject[] hardPieces;

    private GameObject[][] allPieces;

    private int difficultyThisRound = 0;
    private int score = 2;

    MinigameManager myMiniManager;

    // A reference to the currently grabbed piece.
    [HideInInspector]
    public JigsawPiece activePiece;

    private AudioManager audioManager;
    public string Victory;

    void Start()
    {
        audioManager = AudioManager.instance;
        if (audioManager == null)
        {
            Debug.Log("No Audio Manager!!");
        }
    }

    private void Awake()
    {
        allPieces = new GameObject[][] { easyPieces, mediumPieces, hardPieces };

        myMiniManager = FindObjectOfType<MinigameManager>();
    }

    // A method to activate a jigsaw with the specified difficulty (1x2, 2x2, 3x3).
    public void ActivateJigsaw(int difficulty)
    {
        difficultyThisRound = difficulty;
        score = 2;

        for (int i = 0; i < puzzleUIS.Length; i++)
        {
            puzzleUIS[i].SetActive(i == difficultyThisRound);
        }
    }

    private void OnEnable()
    {
        ActivateJigsaw(Random.Range(0, 3));
    }

    // A method called whenever a piece is placed to check for the puzzle being complete.
    public void CheckCompletion()
    {
        foreach (var piece in allPieces[difficultyThisRound])
        {
            // Check each piece in play this round...
            // If it's not in the right spot, return early.
            if (!piece.GetComponent<JigsawPiece>().correctPosition)
            {
                return;
            }
        }

        // If they are all in the right spot, you win!
        Debug.Log("Puzzle complete!");
        ResetBoard();
        myMiniManager.CloseMinigame(score);
        audioManager.PlaySound("Victory");
    }

    // A method for resetting the jigsaw board.
    public void ResetBoard()
    {
        foreach (var piece in allPieces[difficultyThisRound])
        {
            piece.GetComponent<JigsawPiece>().ResetPosition();
        }

        JigsawSlot[] slots = FindObjectsOfType<JigsawSlot>();
        foreach (var slot in slots)
        {
            slot.ResetPieces();
        }
    }

    public void DecrementScore()
    {
        score = Mathf.Max(score - 1, 0);
    }

    // HOW IT WILL WORK:
    // The jigsaw UI will contain 3 panels- each coresponding to a difficukty.
    // Depending on the difficulty, a different panel is set to active.
    // The player has to solve the active puzzle.
    // Once all the pieces are in the right order, the MinigameManager is told to continue
    // and tally up the score of all the previous minigames.
    // The last active jigsaw board is then reset to have all the pieces removed from the board
}