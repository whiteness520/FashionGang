using UnityEngine;
using TMPro;

public class TimeController : MonoBehaviour
{
    public Player player;

    public float gameTime;
    public float startTime;

    public int days;
    public int months;
    public int years;

    private float timeToDay = 6f;
    private float timeToNight = 21f;

    public int dayCycleState = 0; // 0=день 1=ночь

    public GameObject DayIndicator;
    public GameObject NightIndicator;

    public Event[] randomEvents;
    public Event monthResults;
    public Event shopUpdate; // Привоз

    public TMP_Text timeText;
    public TMP_Text dateText;

    private void Awake()
    {
        nextRandomEvent = Random.Range(2, 4);
    }

    private void Update()
    {
        DateTimeCompute();

        CalendarEvents();

        DayCycle();
        UIOutput();
    }

//      3) Система распределения рандомных событий во времени
//      4) Конец игры при простое >17 дней. 
//      5) Окно ежемесячного отчета. (Отдать долг, заплатить налог)
//      6) Календарь привоза (индикатор). Привоз бывает раз в неделю.

        private int nextRandomEvent;
        private int nextShopReturn = 7;
    private void CalendarEvents()
    {
        if (days >= nextRandomEvent)
        {
            nextRandomEvent += Random.Range(1, 4);
            if (nextRandomEvent > 30)
                nextRandomEvent = Random.Range(1, 4);
            ApplyEvent(randomEvents[Random.Range(0, randomEvents.Length)]);
        }
        
        if (days == 30)
        {
            ApplyEvent(monthResults);
        }

        if (days >= nextShopReturn)
        {
            ApplyEvent(shopUpdate);
            nextShopReturn += 7;
        }
    }

    public void ApplyEvent(Event eventToApply)
    {
        eventToApply.window.SetActive(true);

        player.health = player.health + eventToApply.health;
        player.money = player.money + eventToApply.money;
        player.perfomance = player.perfomance + eventToApply.perfomance;
        player.strength = player.strength + eventToApply.strength;
        player.mood = player.mood + eventToApply.mood;

        Time.timeScale = 0f;
    }



    private void DateTimeCompute()
    {
        gameTime = startTime + Mathf.Round(Time.time) - 24f * (days - 1);
        if (gameTime > 23f)
            days++;
        
        if (days > 30)
        {
            months++;
            days = 1;
        }

        if (months > 12)
        {
            years++;
            months = 1;
        }
    }

    private void DayCycle()
    {
        if (dayCycleState == 1)
        {
            if (gameTime == timeToDay)
            {
                dayCycleState = 0;

                NightIndicator.SetActive(false);
                DayIndicator.SetActive(true);
            }
        }
        else
        {
            if (gameTime == timeToNight)
            {
                dayCycleState = 1;

                DayIndicator.SetActive(false);
                NightIndicator.SetActive(true);
            }
        }
    }



    private void UIOutput()
    {
        timeText.text = gameTime + ":00";
        dateText.text = days + "." + months + "." + years;
    }
}

[System.Serializable]
public class Event
{
    public string eventName; // Чтобы ориентироваться в инспекторе
    public GameObject window;
    
    [Header("Что даёт/забирает")]
    public int health;
    public int money;
    public int perfomance;
    public int strength;
    public int mood;
}
