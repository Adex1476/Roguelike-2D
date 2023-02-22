using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ReturnToPreviousScene : MonoBehaviour
{
    [SerializeField] private Button[] _buttons;
    private bool _created = false;

    void Awake()
    {
        if (_created!) { DontDestroyOnLoad(this.gameObject); }
    }

    // Start is called before the first frame update
    void Start()
    {
        _buttons[0].onClick.AddListener(GoToMenu);
        _buttons[1].onClick.AddListener(GoToGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GoToMenu() { SceneManager.LoadScene("StartScene"); }
    void GoToGame() 
    {
        GameManager.Instance.ReloadWeapons();
        SceneManager.LoadScene("GameScene"); 
    }
}
