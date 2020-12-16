using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof (RectTransform), typeof(Image), typeof (Button))]
public class JigsawPiece : MonoBehaviour
{
    private AudioManager audioManager;
    public string puzzlePiece;

    void Start()
    {
        audioManager = AudioManager.instance;
        if (audioManager == null)
        {
            Debug.Log("No Audio Manager!!");
        }
    }

    // TODO: this will hold information and logic for this specific piece of the jigsaw.
    // It will include:
    // Variable for it's original position.
    public RectTransform originalRect;
    private Button button;
    private Image img;
    private JigsawManager myManager;

    // An identifying index for it's place in the puzzle.
    public int index = 0;

    [HideInInspector]
    public bool correctPosition = false;

    private bool followingCursor = false;

    private void Awake()
    {
        button = gameObject.GetComponent<Button>();
        img = gameObject.GetComponent<Image>();
        myManager = FindObjectOfType<JigsawManager>();

        // Add the event of sticking to the cursor once we've clicked the button.
        gameObject.GetComponent<Button>().onClick.AddListener(delegate { this.StickToCursor(true); });
    }

    private void Update()
    {
        if (followingCursor)
        {
            transform.position = Input.mousePosition;
        }
    }

    // Logic for being moved by the cursor.
    public void StickToCursor(bool stick)
    {
        if (!correctPosition && myManager.activePiece == null)
        {
            button.interactable = !stick;
            img.raycastTarget = !stick;
            followingCursor = stick;

            if (stick)
            {
                audioManager.PlaySound("puzzlePiece");
                myManager.activePiece = this;
            }
            else
            {
                myManager.activePiece = null;
            }
        }
    }

    // Logic for locking into place upon the correct placement.
    public void LockPiece(RectTransform placememnt)
    {
        myManager.activePiece = null;

        RectTransform currentRect = gameObject.GetComponent<RectTransform>();

        currentRect.anchorMin = placememnt.anchorMin;
        currentRect.anchorMax = placememnt.anchorMax;
        currentRect.anchoredPosition = placememnt.anchoredPosition;
        currentRect.sizeDelta = placememnt.sizeDelta;

        StickToCursor(false);
        correctPosition = true;
    }

    // Logic for going back into it's original spot before board completion.
    public void ResetPosition()
    {
        myManager.activePiece = null;

        RectTransform currentRect = gameObject.GetComponent<RectTransform>();

        currentRect.anchorMin = originalRect.anchorMin;
        currentRect.anchorMax = originalRect.anchorMax;
        currentRect.anchoredPosition = originalRect.anchoredPosition;
        currentRect.sizeDelta = originalRect.sizeDelta;

        StickToCursor(false);
        correctPosition = false;
    }
}