using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropScript : MonoBehaviour
{
    private SpriteRenderer _sr;
    public ItemSO itemInfo;

    // Start is called before the first frame update
    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        _sr.sprite = itemInfo.img;
    }
}
