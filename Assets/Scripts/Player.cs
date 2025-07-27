using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public GameInit gameInit;
    public string playerName;
    public int money;
    [Range(0, 100)] public int health;
    [Range(0, 100)] public int strength;
    public int perfomance; // Успеваемост
    [Range(-1f, 3f)] public float mood;
    [Range(-1f, 3f)] public float parents;
    public bool policeSearch;
    private float policeSearchTime;

    public bool canGetMoney;

    public Item[] items;

    [Header("UI")]
    public TMP_Text healthText;
    public Slider healthSlider;
    public TMP_Text playerNameText;
    public TMP_Text moneyText;
    public TMP_Text strengthText;
    public TMP_Text perfomanceText;
    public TMP_Text moodText;
    public GameObject police;
    public TMP_Text parentsText;


    private NameGetter nameGetter;
    public GameObject mainMenu;
    public GameObject jailMenu;
    public GameObject allWindows;
    public GameObject gameOverWindow;

    private void Start()
    {
        nameGetter = gameInit.GetNameGetter();
        playerName = PlayerPrefs.GetString("PlayerName");
        if (playerName == "")
            nameGetter.Turn();
        else
            mainMenu.SetActive(true);
    }

    private void Update()
    {
        Mathf.Clamp(money, 0, 30000);
        Mathf.Clamp(health, 0, 100);
        Mathf.Clamp(strength, 0, 100);
        Mathf.Clamp(mood, -1f, 3f);
        DataUpdate();

        if (policeSearch)
        {
            if (policeSearchTime <= Time.time)
            {
                policeSearch = false;
                Jail();
            }
        }
    }

        private int lastEmptySlot; private int currentSlot;
    public void GetNewItem(Item newItem)
    {
        foreach (Item item in items)
        {
            currentSlot++;
            if (item == null)
            {
                lastEmptySlot = currentSlot;
                break;
            }
        }

            if (currentSlot < items.Length)
        items[currentSlot] = newItem;
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

        if (mood <= -0.9f)
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


        if (policeSearch)
            police.SetActive(true);
        else
            police.SetActive(false);


        if (parents <= 0)
            parentsText.text = "Отношения с родаками: Очень плохие";
        if (parents > 0)
            parentsText.text = "Отношения с родаками: Плохие";
        if (parents >= 1)
            parentsText.text = "Отношения с родаками: Нормальные";
        if (parents >= 2)
            parentsText.text = "Отношения с родаками: Гуд";
    }



    public void StartPoliceSearch()
    {
        policeSearchTime = Time.time + 60f;
        policeSearch = true;
    }



    public void GameOver()
    {
        gameOverWindow.SetActive(true);
        Time.timeScale = 0f;
        transform.gameObject.SetActive(false);
        allWindows.SetActive(false);
    }


    public void Jail()
    {
        allWindows.SetActive(false);
        jailMenu.SetActive(true);
    }


    public void GetMoney()
    {
        if (canGetMoney)
        {
            money += Random.Range(0, 3000);
            canGetMoney = false;
        }
    }
}
