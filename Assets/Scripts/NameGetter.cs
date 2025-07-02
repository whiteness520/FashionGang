using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameGetter : MonoBehaviour
{
    public GameInit gameInit;
    private Player player;

    public TMP_InputField inputField;
    public GameObject nameGetterMenu;
    public GameObject nextMenu;

    public void Start()
    {
        player = gameInit.GetPlayer();
    }

    public void Turn()
    {
        nameGetterMenu.SetActive(true);
    }

    public void SetName()
    {
        player.playerName = inputField.text;
        PlayerPrefs.SetString("PlayerName", inputField.text);
        nameGetterMenu.SetActive(false);
        nextMenu.SetActive(true);
        // Остальная логика
    }
}
