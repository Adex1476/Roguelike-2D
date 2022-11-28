using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemSO : ScriptableObject
{
    public string name;
    public type itemT;
    public int price;
    public Sprite img;

    public enum type
    {
        Weapon,
        Consum,
        Passive
    }
}
