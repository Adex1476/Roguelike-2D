using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float _timeRemaining;
    private bool _timerIsRunning;
    private float x;
    private float y;
    [SerializeField] private GameObject _enemy1;

    // Start is called before the first frame update
    void Start()
    {
        _timeRemaining = 3f;
        x = gameObject.transform.position.x;
        y = gameObject.transform.position.y;
        InvokeRepeating("Spawn", 1f, 0.5f);
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
