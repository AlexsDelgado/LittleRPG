using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class StatsCanvas : MonoBehaviour
{
    [SerializeField] private GameObject Panel;
    [SerializeField] private float timeToClose;
    private float timer;
    
    [SerializeField] private GameObject STR;
    private TextMeshProUGUI STR_text;
    [SerializeField] private GameObject DEF;
    private TextMeshProUGUI DEF_text;
    [SerializeField] private GameObject SPD;
    private TextMeshProUGUI SPD_text;
    [SerializeField] private GameObject AS;
    private TextMeshProUGUI AS_text;

    private void Start()
    {
        STR_text = STR.GetComponent<TextMeshProUGUI>();
        DEF_text = DEF.GetComponent<TextMeshProUGUI>();
        SPD_text = SPD.GetComponent<TextMeshProUGUI>();
        AS_text = AS.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Panel.SetActive(!Panel.activeInHierarchy);
            if (Panel.activeInHierarchy)
            {
                timer = 0;
            }
        }

        if (Panel.activeInHierarchy)
        {
            timer += Time.deltaTime;
            if (timer > timeToClose)
            {
                Panel.SetActive(false);
                timer = 0;
            }
        }
    }

    public void UpdateStats(int newStr, int newDef, int newSpd, float newAs)
    {
        STR_text.text = newStr.ToString();
        DEF_text.text = newDef.ToString();
        SPD_text.text = newSpd.ToString();
        AS_text.text = newAs.ToString();
    }
}
