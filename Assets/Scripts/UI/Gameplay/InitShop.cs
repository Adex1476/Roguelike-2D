using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitShop : MonoBehaviour
{
    public List<ItemSO> weaponsAvailable;
    public List<ItemSO> consumablesAvailable;
    public List<ItemSO> passivesAvailable;
    private ShopButton[] images;
    [SerializeField] private Text _totalPointsTxt;
    private int _totalpoints;


    // Start is called before the first frame update
    void Start()
    {
        int button = 0;
        images = GetComponentsInChildren<ShopButton>();

        for (; button < 4; button++)
            images[button].InitButton(GetRandomItem(weaponsAvailable));
        for (; button < 5; button++)
            images[button].InitButton(GetRandomItem(consumablesAvailable));
        for (; button < 8; button++)
            images[button].InitButton(GetRandomItem(passivesAvailable));

    }

    // Update is called once per frame
    void Update()
    {
        _totalpoints = PlayerPrefs.GetInt("TotalPoints");
        _totalPointsTxt.text = "Points: " + _totalpoints + " pts";
    }

    private ItemSO GetRandomItem(List<ItemSO> list)
    {
        int n = Random.Range(0, list.Count);
        ItemSO result = list[n];
        list.RemoveAt(n);

        return result;
    }

}
