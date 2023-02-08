using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeToPlayScene : MonoBehaviour
{
    private Button _button;
    private bool _created = false;

    void Awake()
    {
        if (_created!) { DontDestroyOnLoad(this.gameObject); }
    }

    // Start is called before the first frame update
    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(GoToScene);
    }

    public void GoToScene()
    {
        SceneManager.LoadScene("GameScene");
    }

}
