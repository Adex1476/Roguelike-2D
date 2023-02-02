using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObjects : MonoBehaviour
{
    private int cont;
    private int _cont;
    private GameManager _gm;
    private Vector2 pos;
    private int rdm;

    void Start()
    {
        rdm = Random.Range(0, 10);
        pos = transform.position;
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            int bulletDmg = collision.gameObject.GetComponent<Bullet>().Dmg;
            cont += bulletDmg;
            if (cont == 15)
            {
                if (rdm == 0 || rdm == 1)
                {
                    _gm.InstantiateDrop(pos);
                    Destroy(gameObject);
                } else
                {
                    Destroy(gameObject);
                }
            }
        }
        else if (collision.CompareTag("Fireball"))
        {
            _cont += 1;
            if(_cont == 5) { Destroy(gameObject); }
        }
    }
}