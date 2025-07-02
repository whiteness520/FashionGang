using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Fighting : MonoBehaviour
{
    public GameInit gameInit;
    private Player player;
    public float playerStrength;
    public float enemyStrength;
    public TMP_Text probabilityText;
    private float _probability;

    public Item[] items;
    public Item currentItem;

    public Sprite[] enemyIcons;

    public TMP_Text itemsCountText;
    public Image enemyIcon;
    public Image itemIcon;

    public GameObject mainMenu;
    public GameObject fightingMenu;
    public GameObject winMenu;
    public GameObject loseMenu;
    public GameObject doubleLoseMenu; // Отдал шмот без боя

    public void Start()
    {
        player = gameInit.GetPlayer();
    }

    public void FindMatch()
    {
        playerStrength = player.strength;
        currentItem = items[Random.Range(0, items.Length)];
        itemIcon.sprite = currentItem.icon;

        ProbabilityCompute();
        fightingMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    private void ProbabilityCompute()
    {
        enemyStrength = Random.Range(1f, 100f);
        _probability = playerStrength / enemyStrength * 100f;
        if (_probability > 100f)
            _probability = 100f;

        if (_probability > 50f)
            enemyIcon.sprite = enemyIcons[1];
        else
            enemyIcon.sprite = enemyIcons[0];

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
        player.mood -= 0.1f;
    }


    private void Win()
    {
        winMenu.SetActive(true);
        player.mood += 0.75f;
        player.money += Random.Range(5, 100);
        player.strength += Random.Range(1, 10);
        player.GetNewItem(currentItem);
    }

    private void Lose()
    {
        loseMenu.SetActive(true);
        player.health -= Random.Range(1, 20);
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
    }
}
