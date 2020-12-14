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
    private float dayRemaining;
    private bool executedEndEvents = false;

    [Tooltip("Place the UI object you want to display the time here!")]
    public TextMeshProUGUI timeUI;

    // Unity Events let you add multiple calls from various other objects onto a function
    // via the editor. Seen in other places like the UI Button's OnClick() event.
    [Tooltip("Once the timer ends, these events will be triggered once.")]
    public UnityEvent OnTimerEnd;

    void Start()
    {
        dayRemaining = dayLength;
        executedEndEvents = false;
    }


    void Update()
    {
        // If the time is above 0...
        if (dayRemaining > 0)
        {
            // count down!
            dayRemaining -= Time.deltaTime;

            // TODO: Style the text in the timer UI to appear like an actual clock.
            // Ex: Start at 8 am, timer ticks until the day ends at 8 pm (12 minutes IGT);
            timeUI.text = dayRemaining.ToString("0:00");
        }
        else
        {
            // When we're at 0...
            if (!executedEndEvents)
            {
                Debug.Log("Time's up!");
                // This is what executes all of the actions in the OnTimerEnd() Event.
                OnTimerEnd.Invoke();
                executedEndEvents = true;
            }
        }
    }

    // TODO: Test function, remove later.
    public void Ping()
    {
        Debug.Log("Pong!");
    }
}
