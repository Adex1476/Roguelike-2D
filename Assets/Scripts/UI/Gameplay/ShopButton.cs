using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    [SerializeField] private InventoryScript _is;
    [SerializeField] private InitShop _inits;
    private ItemSO item;

    private int _points;
    private Button button;
    private Image image;
    [SerializeField] private Text price;
    [SerializeField] public Sprite bought;

    void Awake()
    {
        GameObject buttonObj = transform.Find("ShopButton").gameObject;
        button = buttonObj.GetComponent<Button>();
        image = buttonObj.GetComponent<Image>();
        _points= PlayerPrefs.GetInt("TotalPoints");
    }

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(ButtonLogic);
    }

    public void InitButton(ItemSO newItem)
    {
        item = newItem;

        image.sprite = item.img;
        price.text = item.price.ToString() + "pts";
    }

    private void ButtonLogic()
    {
        if (PlayerPrefs.GetInt("TotalPoints") >= item.price)
        {
            _is.addItem(item);
            image.sprite = bought;
            PlayerPrefs.SetInt("TotalPoints", _points - item.price);

            button.onClick.RemoveAllListeners();
        }
    }

}
