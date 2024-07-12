using UnityEngine;
[CreateAssetMenu(fileName = "HPPot",menuName = "HPPot")]

public class HPPot : ScriptableObject
{
    public int HealAmount;
    public AudioClip PotionSound;
    public Sprite Sprite;
}
