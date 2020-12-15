using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class DayTimer : MonoBehaviour
{
    // TODO: Should hold a public reference to a Light(s) component
    // so it can be changed over the course of the day.

    [Tooltip("Time in seconds that the day should go on for.")]
    public float dayLength = 300f;
    private float remainingTime = 0f;
    private bool executedEndEvents = false;

    //[Tooltip("Toggle whether or not to display the time UI to the player.")]
    //public bool useUI = false;
    //[Tooltip("Place the UI object you want to display the time here!")]
    //public TextMeshProUGUI timeUI;
    //[Range(1, 12)] [Tooltip("What time to start the human-readable clock at.")]
    //public int startClockTime = 8;
    //public bool amTime = true;

    // Unity Events let you add multiple calls from various other objects onto a function
    // via the editor. Seen in other places like the UI Button's OnClick() event.
    [Tooltip("Once the timer ends, these events will be triggered once.")]
    public UnityEvent OnTimerEnd;

    void Start()
    {
        remainingTime = 0f;
        executedEndEvents = false;

        //timeUI.gameObject.SetActive(useUI);
    }

    void Update()
    {
        // If the timer is less than the ending value...
        if (remainingTime < dayLength)
        {
            // count up!
            remainingTime += Time.deltaTime;

            // Style the text in the timer UI to appear like an actual clock.
            // Ex: Start at 8 am, timer ticks until the day ends at 8 pm (12 minutes IGT)
            // The visual clock is of course just an illusion of time for the player to understand.
            //if (useUI)
            //{
            //    TimeUIFormat(remainingTime, startClockTime);
            //}
        }
        else
        {
            // When we're at the end...
            if (!executedEndEvents)
            {
                Debug.Log("Time's up!");
                // This is what executes all of the actions in the OnTimerEnd() Event.
                OnTimerEnd.Invoke();
                executedEndEvents = true;
            }
        }
    }

    // TODO: Fix this. For some reason getting past 13 is impossible.
    //private void TimeUIFormat(float remainingTime, float addedTime)
    //{
    //    float hour = ((remainingTime / 120f) + addedTime) % 12f;
    //    float minute = remainingTime % 60;

    //    timeUI.text = remainingTime.ToString("0.00") + "\n";
    //    timeUI.text += string.Format("{0}:{1}"/*  {2}"*/, 
    //        (hour).ToString("00").Replace("00", "12"),
    //        (minute).ToString("00").Replace("60", "59")/*,*/
    //        /*am ? "am" : "pm"*/);
    //}

    // TODO: Test function, remove later.
    public void Ping()
    {
        Debug.Log("Pong!");
    }
}
