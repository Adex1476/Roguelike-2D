using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null;
    public GameObject Player;
    private int _score;
    private int _highScore;
    private Vector2 _cameraSize;
    private int enemiesRemaining;

    public int score { get => _score; set => _score = value; }
    public int highScore { get => _highScore; set => _highScore = value; }

    public Vector2 cameraSize { get { return _cameraSize; } }

    public static GameManager Instance
    {
        get { return _instance; }
    }

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        _instance = this;

        score = 0;
        enemiesRemaining = 0;
        //highScore = PlayerPrefs.GetInt("highScore", highScore);
    }

    // Start is called before the first frame update
    void Start()
    {
        updateCS();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateCS() { _cameraSize = new Vector2(Camera.main.orthographicSize * Screen.width / Screen.height, Camera.main.orthographicSize); }
}
