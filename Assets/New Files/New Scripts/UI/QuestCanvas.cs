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
        NewEventHandler.Instance.onPickupQuest += UnlockQuest;
        NewEventHandler.Instance.onResetGame += ResetQuest;
    }
    private void OnDisable()
    {
        NewEventHandler.Instance.onPickupQuest -= UnlockQuest;
        NewEventHandler.Instance.onResetGame -= ResetQuest;
    }

    private void UnlockQuest()
    {
        questUnlocked = true;
        Panel.SetActive(true);
    }

    private void ResetQuest()
    {
        questUnlocked = false;
    }
}
