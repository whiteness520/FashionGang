using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Fighting : MonoBehaviour
{
    public float playerStrength;
    public float enemyStrength;
    public TMP_Text probabilityText;
    private float _probability;

    public int itemsCount; // Пока шмотки -- инт
    public TMP_Text itemsCountText;

    public GameObject mainMenu;
    public GameObject winMenu;
    public GameObject loseMenu;
    public GameObject doubleLoseMenu; // Отдал шмот без боя


    private void Start()
    {
        ProbabilityCompute();
        itemsCountText.text = "Items: " + itemsCount;
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

        mainMenu.SetActive(false);
    }

    public void GiveItem()
    {
        mainMenu.SetActive(false);
        doubleLoseMenu.SetActive(true);
        itemsCount--;
    }


    private void Win()
    {
        winMenu.SetActive(true);
        // Остальная логика
    }

    private void Lose()
    {
        loseMenu.SetActive(true);
        itemsCount--;
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
