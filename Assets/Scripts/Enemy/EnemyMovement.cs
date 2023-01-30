using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private PlayerMovement _pm;
    [SerializeField] private Animator animator;
    private GameManager _gm;
    private Transform _pos;
    private float _step;
    private bool _isDead;
    public int cont;

    // Start is called before the first frame update
    void Start()
    {
        _isDead = false;
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        _pos = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        _step = 2f * Time.deltaTime;
        if (_pos != null && !_isDead) { transform.position = Vector2.MoveTowards(transform.position, _pos.position, _step); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !_pm._invencible)
        {
            GameManager.Instance.dmg();
            CollisionBehaviour();
            if (_gm.hp == 0) { _gm.PlayerDeath(); }
        }
        else if (collision.CompareTag("Bullet"))
        {
            int bulletDmg = collision.gameObject.GetComponent<Bullet>().Dmg;
            cont += bulletDmg;
            if (cont >= 7) { CollisionBehaviour(); }
        }
    }

    void CollisionBehaviour()
    {
        Destroy(this.GetComponent<CapsuleCollider2D>());
        _isDead = true;
        animator.SetTrigger("Death");
        Invoke("Destroy", 1f);
    }

    private void Destroy() 
    {
        _gm.scorePoints(5);
        Destroy(this.gameObject); 
    }
}
