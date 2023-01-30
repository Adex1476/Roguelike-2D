using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemListSO", menuName = "ScriptableObjects/ItemListSO", order = 1)]
public class ItemListSO : ScriptableObject
{
    public List<ItemSO> Items;

    public ItemSO randomItem() { return Items[Random.Range(0, Items.Count)]; }
}
