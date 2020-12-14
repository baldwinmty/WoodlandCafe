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

    // TODO: Style the text in the timer UI to appear like an actual clock.
    // Ex: Start at 8 am, timer ticks until the day ends at 8 pm (12 minutes IGT);
    [Tooltip("Place the UI object you want to display the time here!")]
    public TextMeshProUGUI timeUI;

    [Tooltip("Once the timer ends, these events will be triggered once.")]
    public UnityEvent OnTimerEnd;

    void Start()
    {
        dayRemaining = dayLength;
        executedEndEvents = false;
    }


    void Update()
    {
        if (dayRemaining > 0)
        {
            dayRemaining -= Time.deltaTime;
            timeUI.text = dayRemaining.ToString("0:00");
        }
        else
        {
            if (!executedEndEvents)
            {
                Debug.Log("Time's up!");
                OnTimerEnd.Invoke();
                executedEndEvents = true;
            }
        }
    }

    public void Ping()
    {
        Debug.Log("Pong!");
    }
}
