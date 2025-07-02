using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInit : MonoBehaviour
{
    public Fighting fighting;
    public NameGetter nameGetter;
    public Player player;
    public TimeController timeController;
    public Sports sports;

    public int gameOverDate;

    public void Awake()
    {
        fighting.gameInit = this;
        nameGetter.gameInit = this;
        player.gameInit = this;
        timeController.gameInit = this;
        sports.gameInit = this;
    }
    
        private int nextDay = 1;
    private void Update()
    {
        if (timeController.days == nextDay)
        {
            player.mood -= 0.1f;
            nextDay++;
        }
    }

    public Fighting GetFighting()
    {
        return fighting;
    }

    public NameGetter GetNameGetter() 
    {
        return nameGetter;
    }

    public Player GetPlayer()
    {
        return player;
    }

    public TimeController GetTimeController()
    {
        return timeController;
    }

    public void Action()
    {
        
    }
}
