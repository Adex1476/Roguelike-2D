using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ConsumItem", menuName = "ScriptableObjects/ConsumItem", order = 3)]
public class ConsumSO : ItemSO
{
    public consumType ct;
    public int quantity;

    private void Awake() { itemT = itemType.Consum; }

    public enum consumType
    {
        Potion
    }
}
