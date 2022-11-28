using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PassiveData", menuName = "ScriptableObjects/PassiveData", order = 2)]
public class PassiveSO : ItemSO
{
    public upgrade upgradeType;
    public int upgradeBoost;
    public enum upgrade
    {
        MoveSpeIncrease,
        DashCDReduction,
        MaxHealthIncrease
    }
}
