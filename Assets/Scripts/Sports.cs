using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sports : MonoBehaviour
{
    public GameInit gameInit;
    private Player player;
    public GameObject mainMenu, sportsMenu;
    public GameObject notEnoughMoney;

    public GameObject chinUpsSuccess;
    public GameObject gymSuccess;
    public GameObject drunkSuccess;

    public GameObject chinUpsInjury;
    public GameObject gymInjury;

    public float injuryProbabilityChin;
    public float injuryProbabilityGym;

    private void Start()
    {
        player = gameInit.GetPlayer();
    }

    public void Return()
    {
        sportsMenu.SetActive(false);
        chinUpsSuccess.SetActive(false);
        gymSuccess.SetActive(false);
        drunkSuccess.SetActive(false);
        chinUpsInjury.SetActive(false);
        gymInjury.SetActive(false);
        notEnoughMoney.SetActive(false);

        mainMenu.SetActive(true);
    }

    public void DoSports()
    {
        mainMenu.SetActive(false);
        sportsMenu.SetActive(true);
    }

    public void ChinUps()
    {
        sportsMenu.SetActive(false);

        float probability = Random.Range(0f, 100f);

        if (probability < injuryProbabilityChin)
        {
            chinUpsInjury.SetActive(true);

            player.health -= 25;
            player.mood -= 1f;
            player.strength -= 10;
        }
        else
        {
            chinUpsSuccess.SetActive(true);
            
            player.strength += 5;
            player.mood += 1f;
            player.health += 5;
        }
    }

    public void Gym()
    {
        if (player.money >= 150)
        {
            player.money -= 150;
            sportsMenu.SetActive(false);

            float probability = Random.Range(0f, 100f);

            if (probability < injuryProbabilityChin)
            {
                gymInjury.SetActive(true);

                player.health -= 10;
                player.mood += 0.5f;
                player.strength = player.strength / 2;
            }
            else
            {
                gymSuccess.SetActive(true);
                
                player.health -= 5;
                player.strength += 10;
                player.mood += 1f;
            }
        }
        else
        {
            sportsMenu.SetActive(false);
            chinUpsSuccess.SetActive(false);
            gymSuccess.SetActive(false);
            drunkSuccess.SetActive(false);
            chinUpsInjury.SetActive(false);
            gymInjury.SetActive(false);

            notEnoughMoney.SetActive(true);
        }
    }

    public void Drunk()
    {
        sportsMenu.SetActive(false);

        player.health += 10;
        player.mood += 0.5f;
        player.strength -= 1;

        drunkSuccess.SetActive(true);
    }
}
