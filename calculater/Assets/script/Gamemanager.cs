using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Data;


public class Gamemanager : MonoBehaviour
{
    public TMP_InputField inputfield;
    public TextMeshProUGUI result;
    DataTable dt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dt = new DataTable();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            BtnClicked();
        }
    }

    public void BtnClicked()
    {
        result.text = dt.Compute(inputfield.text, "").ToString();
    }
}
