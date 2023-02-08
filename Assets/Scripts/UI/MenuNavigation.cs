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
        buttonMenu[0].onClick.AddListener(LoadShop);
        buttonMenu[1].onClick.AddListener(LoadSettings);
        buttonMenu[2].onClick.AddListener(UnloadShop);
        buttonMenu[3].onClick.AddListener(UnloadSettings);
    }

    
    private void LoadMenu() => canvasMenu[0].SetActive(true);
    private void UnloadMenu() => canvasMenu[0].SetActive(false);
    private void LoadShop() { UnloadMenu(); canvasMenu[1].SetActive(true); }
    private void UnloadShop() { canvasMenu[1].SetActive(false); LoadMenu(); }
    private void LoadSettings() { UnloadMenu(); canvasMenu[2].SetActive(true); }
    private void UnloadSettings() { canvasMenu[2].SetActive(false); LoadMenu(); }
}
