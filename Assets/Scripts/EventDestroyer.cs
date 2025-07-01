using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventDestroyer : MonoBehaviour
{
    public GameObject window;
    public void Skip()
    {
        window.SetActive(false);
        Time.timeScale = 1f;
    }
}
