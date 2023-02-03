using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PassiveData", menuName = "ScriptableObjects/PassiveData", order = 2)]
public class PassiveSO : ItemSO
{
    public List<upModifier> mods;
    private void Awake() { itemT = itemType.Passive; }
}


[System.Serializable]
public struct upModifier
{
    public upgradeType ut;
    public float upgradeBoost;
}

public enum upgradeType
{
    MoveSpeIncrease,
    DashCDReduction,
    MaxHealthIncrease
}

