using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Fighting : MonoBehaviour
{
    public Player player;
    public float playerStrength;
    public float enemyStrength;
    public int itemsCount; // Пока шмотки -- инт
    public TMP_Text probabilityText;
    private float _probability;

    public TMP_Text itemsCountText;

    public GameObject mainMenu;
    public GameObject fightingMenu;
    public GameObject winMenu;
    public GameObject loseMenu;
    public GameObject doubleLoseMenu; // Отдал шмот без боя

    public void FindMatch()
    {
        playerStrength = player.strength;
        ProbabilityCompute();
        itemsCountText.text = "Items: " + itemsCount;
        fightingMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    private void ProbabilityCompute()
    {
        enemyStrength = Random.Range(1f, 100f);
        _probability = playerStrength / enemyStrength * 100f;
        if (_probability > 100f)
            _probability = 100f;

        probabilityText.text = "Вероятность победы: " + Mathf.Round(_probability) + "%"; 
    }


        private float randomNumber;
    public void Fight()
    {
        randomNumber = Random.Range(1f, 100f);
        if (randomNumber <= _probability)
            Win();
        else
            Lose();

        fightingMenu.SetActive(false);
    }

    public void GiveItem()
    {
        fightingMenu.SetActive(false);
        doubleLoseMenu.SetActive(true);
        itemsCount--;
        player.mood -= 0.1f;
    }


    private void Win()
    {
        winMenu.SetActive(true);
        player.mood += 0.75f;
        player.money += Random.Range(5, 100);
    }

    private void Lose()
    {
        loseMenu.SetActive(true);
        itemsCount--;
        player.mood -= 0.25f;
        // Остальная логика
    }


    public void Return()
    {
        winMenu.SetActive(false);
        loseMenu.SetActive(false);
        doubleLoseMenu.SetActive(false);
        mainMenu.SetActive(true);

        ProbabilityCompute();
        itemsCountText.text = "Шмоток: " + itemsCount;
    }
}
