using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameManager _gm;
    private Transform _pos;
    private float _step;

    // Start is called before the first frame update
    void Start()
    {
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        _pos = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        _step = 2f * Time.deltaTime;
        if (_pos != null) { transform.position = Vector2.MoveTowards(transform.position, _pos.position, _step); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.dmg();
            Destroy(gameObject);
            if (_gm.hp == 0)
            {
                Destroy(collision.gameObject);
                _gm.ReloadScene();
            }
        }
        if (collision.CompareTag("Enemy")) { Destroy(this.gameObject); }
    }
}
