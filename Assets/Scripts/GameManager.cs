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
    public GameObject Player;
    public GameObject Item;
    public ItemListSO DroppableItems;
    public GameObject [] Enemies;
    [SerializeField] private Text enemies;
    [SerializeField] private Text scrpoints;
    [SerializeField] private Text ammo;
    public int maxHp = 6;
    public int hp;
    private int _score;
    private int _highScore;
    private int cAmmo;
    private int mAmmo;
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
        highScore = PlayerPrefs.GetInt("highScore", highScore);
    }

    // Start is called before the first frame update
    void Start()
    {
        mAmmo = _ps.maxAmmo;
        hp = maxHp;
        hb.SetMaxHealth(maxHp);
        
        updateCS();
        _enemiesRemaining = 0;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        cAmmo = _ps.currentAmmo;
        showCurrentAmmo();
    }

    public int dmg()
    {
        hp--;
        hb.SetHealth(hp);
        return hp;
    }

    public void PlayerDeath()
    {
        StartCoroutine(Death());
    }

    public void scorePoints(int scoreAux)
    {
        score += scoreAux;
        if (scrpoints != null) { scrpoints.text = "Score : " + score; }
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

    public void ReloadScene() { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); }

    IEnumerator Death()
    {
        Player.GetComponent<PlayerMovement>().enabled = false;
        Player.transform.GetChild(0).GetComponent<PlayerShoot>().enabled = false;
        _rb.freezeRotation = true;
        _pd.anim.SetTrigger("Dead");
        yield return new WaitForSeconds(1f);
        Destroy(Player);
        ReloadScene();
    }
}