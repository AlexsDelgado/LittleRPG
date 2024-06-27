using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestCanvas : MonoBehaviour
{
    [SerializeField] private GameObject Panel;
    [SerializeField] private bool questUnlocked;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && questUnlocked)
        {
            Panel.SetActive(!Panel.activeInHierarchy);
        }
    }

    private void OnEnable()
    {
        Quest.onPickupQuest += UnlockQuest;
    }
    private void OnDisable()
    {
        Quest.onPickupQuest -= UnlockQuest;
    }

    private void UnlockQuest()
    {
        questUnlocked = true;
        Panel.SetActive(true);
    }
}
