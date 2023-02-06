using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelectorUI : MonoBehaviour
{
    [SerializeField] private WeaponController _wc;
    private List<Image> wIcon = new List<Image>();
    private Image selectedImg;

    // Start is called before the first frame update
    void Start()
    {
        selectedImg = transform.GetChild(0).gameObject.GetComponent<Image>();
        for (int i = 1; i < transform.childCount; i++) { wIcon.Add(transform.GetChild(i).gameObject.GetComponent<Image>()); }   
    }

    public void UpdateWeaponUI()
    {
        for (int i = 0; i < wIcon.Count; i++)
        {
            wIcon[i].sprite = _wc.weaponImg(i);
            wIcon[i].preserveAspect = true;
            selectedImg.transform.position = wIcon[_wc.currentWeapon].transform.position;
        }
    }

}
