using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    
    private bool _timerIsRunning;
    public float _timeRemaining;
    public float _timeBtwWaves;
    private float x;
    private float y;
    public float cont;
    [SerializeField] private GameObject _enemy1;
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private GameObject _enemy2;
    [SerializeField] private Text _timeText;

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
                DisplayTime(_timeRemaining);
            }
            else
            {
                _timeRemaining = 0;
                _timerIsRunning = false;
                CancelInvoke();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet"))
        {
            cont += 1;
            if (cont == 5)
            {
                Destroy(gameObject);
            }
        }
    }

    void Spawn()
    {
        Instantiate(_enemy1, posSpawn(), Quaternion.identity);
    }

    Vector2 posSpawn() { return new Vector2(x, y); }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        _timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
