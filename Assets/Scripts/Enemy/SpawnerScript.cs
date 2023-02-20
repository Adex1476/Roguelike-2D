using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawnerScript : MonoBehaviour
{
    public bool _timerIsRunning;
    public float _timeRemaining;
    public float _timeBtwWaves;
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private GameObject _enemy2;
    public int _enemiesLeft;
    [SerializeField] private Text _timeText;
    [SerializeField] UnityEvent _event;
    [SerializeField] private BoxCollider2D _doorCollider;

    // Start is called before the first frame update
    void Start()
    {
        var rdmSpawn = Random.Range(0, 4);
        _enemiesLeft = rdmSpawn;
        Instantiate(_enemy2, spawnPoints[rdmSpawn].transform.position, Quaternion.identity);
        _timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (/*_enemiesLeft == 0 &&*/ !_timerIsRunning)
            _event.Invoke();

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

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        _timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("Rooms", 1);
            PlayerPrefs.SetInt("ResultID", 0);
            SceneManager.LoadScene("ResultScene");
        }
    }
}
