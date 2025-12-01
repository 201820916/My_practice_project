using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClockManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public TextMeshProUGUI TimeText;
    // Update is called once per frame
    void Update()
    {
        DateTime nowDate = DateTime.Now;
        string formattedDate = nowDate.ToString("yyyy/MM/dd tt HH:mm:ss");
        TimeText.text = formattedDate;
    }
}
