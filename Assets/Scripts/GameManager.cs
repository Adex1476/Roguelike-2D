using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null;
    [SerializeField] private HealthBar hb;
    private PlayerData _pd;
    public GameObject Player;
    public GameObject [] Enemies;
    private Text lifes;
    private Text enemies;
    private Text scrpoints;
    public int maxHp = 6;
    public int hp;
    private int _score;
    private int _highScore;
    private int _enemiesRemaining;
    private Vector2 _cameraSize;

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
        _enemiesRemaining = 0;
        highScore = PlayerPrefs.GetInt("highScore", highScore);
    }

    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
        hb.SetMaxHealth(maxHp);
        
        updateCS();
        _enemiesRemaining = 0;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int dmg()
    {
        hp--;
        hb.SetHealth(hp);
        return hp;
    }

    public void enemiesInS(int ekAux)
    {
        _enemiesRemaining += ekAux;
        enemies.text = "Enemies : " + _enemiesRemaining;
    }

    public void scorePoints(int scoreAux)
    {
        score += scoreAux;
        if (scrpoints != null) { scrpoints.text = "Score : " + score; }
    }


    public void updateCS() { _cameraSize = new Vector2(Camera.main.orthographicSize * Screen.width / Screen.height, Camera.main.orthographicSize); }

    public void ReloadScene() { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); }
}
