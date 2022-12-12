using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject _proj;
    [SerializeField] private Transform _projPos;
    [SerializeField] private Animator _anim;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2f)
        {
            timer = 0;
            Shoot();
        }
    }

    void Shoot()
    {
        _anim.SetTrigger("Active");
        Instantiate(_proj, _projPos.position, Quaternion.identity);
    }
}