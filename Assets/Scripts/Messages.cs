using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Messages : MonoBehaviour
{
    public MessagesArray[] messages;
    public int currentArray;
    public TMP_Text messageText;

    public void Start()
    {
        UpdateMessage();
    }

    public void UpdateMessage()
    {
        messageText.text = messages[currentArray].messages[Random.Range(0, messages.Length)];
    }

        private float timeToNewMessages;
    private void Update()
    {
        if (Time.time >= timeToNewMessages)
        {
            timeToNewMessages += Random.Range(30f, 100);
            currentArray++;

            if (currentArray >= messages.Length)
                currentArray = messages.Length - 1;
        }
    }
}
