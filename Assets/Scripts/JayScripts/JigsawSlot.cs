using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof (Image), typeof(Button))]
public class JigsawSlot : MonoBehaviour
{
    public int index = 0;

    private RectTransform slotTransform;
    private JigsawManager myManager;
    private Button button;
    private Image img;

    private void Awake()
    {
        myManager = FindObjectOfType<JigsawManager>();
        slotTransform = gameObject.GetComponent<RectTransform>();
        button = gameObject.GetComponent<Button>();
        img = gameObject.GetComponent<Image>();
    }

    public void PlaceActivePiece()
    {
        if (myManager.activePiece != null)
        {
            if (myManager.activePiece.index == this.index)
            {
                myManager.activePiece.LockPiece(slotTransform);
                PiecePlaced();

                myManager.CheckCompletion();
            }
            else
            {
                myManager.activePiece.ResetPosition();
                myManager.DecrementScore();
            }
        }
    }

    public void PiecePlaced()
    {
        button.enabled = false;
        img.enabled = false;
    }

    public void ResetPieces()
    {
        button.enabled = true;
        img.enabled = true;
    }
}
