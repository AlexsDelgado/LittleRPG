using UnityEngine;
[CreateAssetMenu(fileName = "BuffPot",menuName = "BuffPot")]
public class BuffPot : ScriptableObject
{
    public int Price;
    
    public int STRBuff;
    public int DEFBuff;
    public int SPDBuff;
    public float AttackSpeedBuff;

    public Sprite Sprite;
    public AudioClip PotionSound;
    
    
}
