// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public string playerName;
    public int money;
    [Range(0, 100)] public int health;
    [Range(0, 100)] public int strength;
    public int perfomance; // Успеваемост
    [Range(-1f, 3f)] public float mood;

    [Header("UI")]
    public TMP_Text healthText;
    public Slider healthSlider;
    public TMP_Text playerNameText;
    public TMP_Text moneyText;
    public TMP_Text strengthText;
    public TMP_Text perfomanceText;
    public TMP_Text moodText;

    public NameGetter nameGetter;
    public GameObject mainMenu;
    public GameObject allWindows;
    public GameObject gameOverWindow;

    private void Start()
    {
        playerName = PlayerPrefs.GetString("PlayerName");
        if (playerName == "")
            nameGetter.Turn();
        else
            mainMenu.SetActive(true);
    }

    private void Update()
    {
        DataUpdate();
    }

    public void DataUpdate()
    {
        if (health <= 0 || perfomance < 0)
        {
            GameOver();
        }
        
        playerNameText.text = "Кликуха: " + playerName;
        healthText.text = "ХП: " + health;
        moneyText.text = "Бабки (не живые): " + money;
        strengthText.text = "Бицуха: " + strength;
        perfomanceText.text = "Успеваемость: " + perfomance;
        healthSlider.value = health;

        if (mood == -1)
        {
            GameOver();
        }

        if (mood <= 0)
            moodText.text = "Настроение: Да я сейчас вскроюсь";
        if (mood > 0)
            moodText.text = "Настроение: Ужасное";
        if (mood >= 1)
            moodText.text = "Настроение: Среднее";
        if (mood >= 2)
            moodText.text = "Настроение: Ништяк";
    }

    public void GameOver()
    {
        gameOverWindow.SetActive(true);
        Time.timeScale = 0f;
        transform.gameObject.SetActive(false);
        allWindows.SetActive(false);
    }
}
