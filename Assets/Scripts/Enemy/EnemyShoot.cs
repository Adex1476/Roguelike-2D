using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject _proj;
    [SerializeField] private Transform _projPos;
    [SerializeField] private Animator _anim;
    [SerializeField] private Animator animator;
    private bool _isDead;
    private float timer;
    public int cont;

    // Start is called before the first frame update
    void Start()
    {
        _isDead = false;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            cont += 1;
            if (cont == 5) { CollisionBehaviour(); }
        }
    }

    void CollisionBehaviour()
    {
        Destroy(this.GetComponent<CapsuleCollider2D>());
        _isDead = true;
        animator.SetTrigger("Death");
        Invoke("Destroy", 1f);
    }

    private void Destroy() { Destroy(this.gameObject); }
}