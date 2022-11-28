using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuNavigation : MonoBehaviour
{
    [SerializeField]
    private GameObject[] canvasMenu;

    [SerializeField]
    private Button[] buttonMenu;

    // Start is called before the first frame update
    void Start()
    {
        LoadMenu();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        buttonMenu[0].onClick.AddListener(LoadGame);
        buttonMenu[1].onClick.AddListener(LoadSettings);*/
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    
    private void LoadMenu() => canvasMenu[0].SetActive(true);/*
    private void UnloadMenu() => canvasMenu[0].SetActive(false);
    private void LoadSettings() { UnloadMenu(); canvasMenu[1].SetActive(true); }
    private void UnloadSettings() { canvasMenu[1].SetActive(false); LoadMenu(); }*/
}
