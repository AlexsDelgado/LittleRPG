using UnityEngine;

[CreateAssetMenu(fileName = "UnitStat", menuName = "UnitStat")]
public class UnitStat : ScriptableObject
{
    public bool isPlayer = false;
    public bool canFly = false;

    public string unitName = "defaultValue";
    public int unitLevel = 1;

    public int MaxHP = 3;
    public int HP = 3;
    public int DEF = 1;
    public int STR = 1;
    public float SPD = 5;
}
