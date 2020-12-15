using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JigsawManager : MonoBehaviour
{
    // TODO: this will be a script that chooses the jigsaw difficulty and checks for pieces for the right order.
    // It will include:
    // A reference to the jigsaw UI.
    // A method to activate a jigsaw with the specified difficulty (1x2, 2x2, 3x3).
    // A method called whenever a piece is placed to check for the puzzle being complete.
    // A method to call to the overall MinigameManager (TODO) to signal going to the next minigame.
    // A method for resetting the jigsaw board.

    // HOW IT WILL WORK:
    // The jigsaw UI will contain 3 panels- each coresponding to a difficukty.
    // Depending on the difficulty, a different panel is set to active.
    // The player has to solve the active puzzle.
    // Once all the pieces are in the right order, the MinigameManager is told to continue
    // and tally up the score of all the previous minigames.
    // The last active jigsaw board is then reset to have all the pieces removed from the board
}
