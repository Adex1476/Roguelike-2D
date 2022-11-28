using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ConsumItem", menuName = "ScriptableObjects/ConsumItem", order = 3)]
public class ConsumSO : ItemSO
{
    public type consumType;
    public int quantity;

    public enum type
    {
        Potion
    }
}
