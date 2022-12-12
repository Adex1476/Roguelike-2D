using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    
    private bool _timerIsRunning;
    public float _timeRemaining;
    public float _timeBtwWaves;
    private float x;
    private float y;
    [SerializeField] private GameObject _enemy1;
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private GameObject _enemy2;

    // Start is called before the first frame update
    void Start()
    { 
        var rdmSpawn = Random.Range(0, 4);
        Instantiate(_enemy2, spawnPoints[rdmSpawn].transform.position, Quaternion.identity);
        _timerIsRunning = true;
        x = gameObject.transform.position.x;
        y = gameObject.transform.position.y;
        InvokeRepeating("Spawn", 1f, _timeBtwWaves);
    }

    // Update is called once per frame
    void Update()
    {
        if (_timerIsRunning)
        {
            if (_timeRemaining > 0)
            {
                _timeRemaining -= Time.deltaTime;
            }
            else
            {
                _timeRemaining = 0;
                _timerIsRunning = false;
                CancelInvoke();
            }
        }
    }

    void Spawn()
    {
        Instantiate(_enemy1, posSpawn(), Quaternion.identity);
    }

    Vector2 posSpawn() { return new Vector2(x, y); }
}
