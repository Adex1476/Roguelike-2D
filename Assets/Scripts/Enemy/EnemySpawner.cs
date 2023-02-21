using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float cont;
    [SerializeField]private SpawnerScript _ss;
    [SerializeField] private GameObject _enemy1;
    private int max;
    private float x;
    private float y;

    // Start is called before the first frame update
    void Start()
    {
   
        x = gameObject.transform.position.x;
        y = gameObject.transform.position.y;
        InvokeRepeating("Spawn", 1f, _ss._timeBtwWaves);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet"))
        {
            cont += 1;
            if (cont == 5) { Destroy(gameObject); }
        }
    }

    void Spawn()
    {
        if (_ss._timerIsRunning)
        {
            Instantiate(_enemy1, posSpawn(), Quaternion.identity);
            _ss._enemiesLeft++;
        }
       
    }

    Vector2 posSpawn() 
    { 
        return new Vector2(x, y); 
    }
}
