using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthCanvas : MonoBehaviour
{
    [SerializeField] private Image MissingHearth1;
    [SerializeField] private Image MissingHearth2;
    [SerializeField] private Image MissingHearth3;
    [SerializeField] private Image MissingHearth4;
    [SerializeField] private Image UnlockableHeart;

    [SerializeField] private bool heartUnlocked;

    public void UpdateHealth(int newHealth)
    {
        switch (newHealth)
        {
            case 0:
                MissingHearth1.enabled = true;
                MissingHearth2.enabled = true;
                MissingHearth3.enabled = true;
                if (heartUnlocked)
                {
                    MissingHearth4.enabled = true;
                }
                else
                {
                    MissingHearth4.enabled = false;
                }
                break;
            case 1:
                MissingHearth1.enabled = false;
                MissingHearth2.enabled = true;
                MissingHearth3.enabled = true;
                if (heartUnlocked)
                {
                    MissingHearth4.enabled = true;
                }
                else
                {
                    MissingHearth4.enabled = false;
                }
                break;
            case 2:
                MissingHearth1.enabled = false;
                MissingHearth2.enabled = false;
                MissingHearth3.enabled = true;
                if (heartUnlocked)
                {
                    MissingHearth4.enabled = true;
                }
                else
                {
                    MissingHearth4.enabled = false;
                }
                break;
            case 3:
                MissingHearth1.enabled = false;
                MissingHearth2.enabled = false;
                MissingHearth3.enabled = false;
                if (heartUnlocked)
                {
                    MissingHearth4.enabled = true;
                }
                else
                {
                    MissingHearth4.enabled = false;
                }
                break;
            case 4:
                MissingHearth1.enabled = true;
                MissingHearth2.enabled = true;
                MissingHearth3.enabled = true;
                MissingHearth4.enabled = true;
                UnlockableHeart.enabled = true;
                heartUnlocked = true;
                break;
        }
    }
}
