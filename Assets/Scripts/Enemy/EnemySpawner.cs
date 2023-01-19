using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    
    private bool _timerIsRunning;
    public float _timeRemaining;
    public float _timeBtwWaves;
    public float cont;
    private GameManager _gm;
    [SerializeField] private GameObject _enemy1;
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private GameObject _enemy2;
    private int maxEnemies = 4;
    private int minEnemies = 1;
    private int enemies;
    private int max;
    private float x;
    private float y;
    [SerializeField] private Text _timeText;

    // Start is called before the first frame update
    void Start()
    { 
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        max = 0;
        enemies = Random.Range(minEnemies, maxEnemies);
        StartCoroutine(Spawn2());
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
            if (cont == 5) { Destroy(gameObject); }
        }
    }

    void Spawn()
    {
        Instantiate(_enemy1, posSpawn(), Quaternion.identity);
        _gm.enemiesInS(1);
    }

    IEnumerator Spawn2()
    {
        while (max < enemies)
        {
            var rndPos = Random.Range(0, spawnPoints.Length);
            yield return new WaitForSeconds(0.1f);
            var theNewPos = spawnPoints[rndPos];
            GameObject go = GameObject.Instantiate(_enemy2);
            go.transform.position = theNewPos.transform.position;
            max += 1;
            _gm.enemiesInS(1);
        }

        /*
        Instantiate(_enemy2, spawnPoints[_rdmSpawn].transform.position, Quaternion.identity);
        */
        
    }

    Vector2 posSpawn() 
    { 
        return new Vector2(x, y); 
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        _timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
