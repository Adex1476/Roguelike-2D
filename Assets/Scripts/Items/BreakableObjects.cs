using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObjects : MonoBehaviour
{
    private int cont;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet") || collision.CompareTag("Fireball"))
        {
            cont += 1;
            if (cont == 3) { Destroy(gameObject); }
        }
    }
}
