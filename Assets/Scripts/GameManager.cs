using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null;
    [SerializeField] private HealthBar hb;
    [SerializeField] private PlayerData _pd;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private PlayerMovement _pm;
    [SerializeField] private PlayerShoot _ps;
    [SerializeField] private GameObject _shopMenu;
    public WeaponSO _weapons;
    public GameObject Player;
    public GameObject Item;
    public ItemListSO DroppableItems;
    public GameObject [] Enemies;
    [SerializeField] private Text enemies;
    [SerializeField] private Text scrpoints;
    [SerializeField] private Text ammo;
    [SerializeField] private EffectAudioController _effectAudioController;
    public bool isPaused;
    public bool isDead;
    public bool shopActive;
    public int maxHp = 6;
    public int hp;
    private int _score;
    private int _highScore;
    public int _isHighscore;
    private int _lastScore;
    private int _totalPoints;
    private int cAmmo;
    private int mAmmo;
    private int _enemiesKilled;
    private Vector2 _cameraSize;

    public int score { get => _score; set => _score = value; }
    public int highScore { get => _highScore; set => _highScore = value; }
    public int lastScore { get => _lastScore; set => _lastScore = value; }

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
    }

    // Start is called before the first frame update
    void Start()
    {
        mAmmo = _ps._maxAmmo;
        hp = maxHp;
        hb.SetMaxHealth(maxHp);
        isPaused = false;
        isDead = false;
        shopActive = false;
        
        updateCS();
        score = 0;
        _enemiesKilled = 0;
        _isHighscore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        mAmmo = _ps._maxAmmo;
        cAmmo = _ps._currentAmmo;
        showCurrentAmmo();

        if ((Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.Escape)) && !isDead && !shopActive)
        {
            Pause();
            if (isPaused)
            {
                _effectAudioController.OnClickSound();
            }
            else
            {
                _effectAudioController.OnClickBackSound();
            }
        }
        if (!shopActive)
        {
            _shopMenu.SetActive(isPaused);
        }  
    }

    public void Pause() => isPaused = !isPaused;

    public int dmg()
    {
        hp--;
        hb.SetHealth(hp);
        return hp;
    }

    public void scorePoints(int scoreAux)
    {
        score += scoreAux;
        if (scrpoints != null) { scrpoints.text = "Score : " + score; }
    }

    public void slainedEnemies(int enemiesAux)
    {
        _enemiesKilled += enemiesAux;
        PlayerPrefs.SetInt("SlainedEnemies", _enemiesKilled);
    }

    public void showCurrentAmmo()
    {
        if (ammo != null) { ammo.text = "Ammo: " + cAmmo + "/" + mAmmo; }
    }

    public void InstantiateDrop(Vector2 pos)
    {
        GameObject go = Instantiate(Item, pos, Quaternion.identity);
        go.GetComponent<DropScript>().itemInfo = DroppableItems.randomItem();
    }

    public void updateCS() { _cameraSize = new Vector2(Camera.main.orthographicSize * Screen.width / Screen.height, Camera.main.orthographicSize); }

    public void ReloadScene() 
    {
        scoreManagement();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }

    public void PlayerDeath()
    {
        isDead = true;
        StartCoroutine(Death());
    }

    public void scoreManagement()
    {
        highScore = PlayerPrefs.GetInt("HighScore", highScore);
        if (highScore < score)
        {
            _isHighscore = 1;
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.SetInt("HSBool", _isHighscore);
        }
        PlayerPrefs.SetInt("HSBool", _isHighscore);
        lastScore = score;
        PlayerPrefs.SetInt("LastScore", lastScore);
        _totalPoints = PlayerPrefs.GetInt("TotalPoints", _totalPoints);
        _totalPoints += lastScore;
        PlayerPrefs.SetInt("TotalPoints", _totalPoints);
    }

    IEnumerator Death()
    {
        Player.GetComponent<PlayerMovement>().enabled = false;
        Player.transform.GetChild(0).GetComponent<PlayerShoot>().enabled = false;
        _rb.freezeRotation = true;
        EffectAudioController.PlaySound("PlayerDeath");
        _pd.anim.SetTrigger("Dead");
        yield return new WaitForSeconds(1f);
        ReloadWeapons();
        scoreManagement();
        PlayerPrefs.SetInt("ResultID", 1);
        Destroy(Player);
        SceneManager.LoadScene("ResultScene");
    }

    public void ReloadWeapons()
    {
        for (int i = 0; i < _weapons.Weapons.Count; i++)
        {
            _weapons.Weapons[i].currentAmmo = _weapons.Weapons[i].bulletLoader;
        }
    }
}