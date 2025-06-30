using UnityEngine;
using TMPro;

public class TimeController : MonoBehaviour
{
    public float gameTime;

    public float startTime;

    public int days;

    private float timeToDay = 6f;
    private float timeToNight = 21f;

    public int state = 0; // 0=день 1=ночь

    public GameObject DayIndicator;
    public GameObject NightIndicator;

    public TMP_Text timeText;

    private void Update()
    {
        gameTime = startTime + Mathf.Round(Time.time) - 24f * days;
        if (gameTime > 23f)
            days++;
        DayCycle();
        TimeOutput();
    }


    private void DayCycle()
    {
        if (state == 1)
        {
            if (gameTime == timeToDay)
            {
                state = 0;

                NightIndicator.SetActive(false);
                DayIndicator.SetActive(true);
            }
        }
        else
        {
            if (gameTime == timeToNight)
            {
                state = 1;

                DayIndicator.SetActive(false);
                NightIndicator.SetActive(true);
            }
        }
    }



    private void TimeOutput()
    {
        timeText.text = gameTime + ":00";
    }
}
