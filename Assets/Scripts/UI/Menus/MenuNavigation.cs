using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


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
        buttonMenu[0].onClick.AddListener(LoadSettings);
        buttonMenu[1].onClick.AddListener(UnloadSettings);
    }
    
    private void LoadMenu() => canvasMenu[0].SetActive(true);
    private void UnloadMenu() => canvasMenu[0].SetActive(false);
    private void LoadSettings() { UnloadMenu(); canvasMenu[1].SetActive(true); }
    private void UnloadSettings() { canvasMenu[1].SetActive(false); LoadMenu(); }
}
