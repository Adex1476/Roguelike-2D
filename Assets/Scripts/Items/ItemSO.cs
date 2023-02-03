using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemSO : ScriptableObject
{
    public string name;
    public itemType itemT;
    public int price;
    public Sprite img;
}

public enum itemType
{
    Weapon,
    Consum,
    Passive
}