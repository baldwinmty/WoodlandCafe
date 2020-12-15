﻿using System.Collections;
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

    // A reference to the currently grabbed piece.
    [HideInInspector]
    public JigsawPiece activePiece;

    private void Awake()
    {
        allPieces = new GameObject[][] { easyPieces, mediumPieces, hardPieces };

        // TESTING ONLY PLEASE REMOVE LATER.
        ActivateJigsaw(Random.Range(0, allPieces.Length));
    }

    // A method to activate a jigsaw with the specified difficulty (1x2, 2x2, 3x3).
    public void ActivateJigsaw(int difficulty)
    {
        difficultyThisRound = difficulty;

        for (int i = 0; i < puzzleUIS.Length; i++)
        {
            puzzleUIS[i].SetActive(i == difficultyThisRound);
        }
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
        // TESTING PLEASE REMOVE LATER
        ActivateJigsaw(Random.Range(0, allPieces.Length));
    }


    // A method to call to the overall MinigameManager (TODO) to signal going to the next minigame.


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

    // HOW IT WILL WORK:
    // The jigsaw UI will contain 3 panels- each coresponding to a difficukty.
    // Depending on the difficulty, a different panel is set to active.
    // The player has to solve the active puzzle.
    // Once all the pieces are in the right order, the MinigameManager is told to continue
    // and tally up the score of all the previous minigames.
    // The last active jigsaw board is then reset to have all the pieces removed from the board
}