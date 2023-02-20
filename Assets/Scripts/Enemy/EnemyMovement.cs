using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private PlayerMovement _pm;
    [SerializeField] private Animator animator;
    private SpawnerScript _ss;
    private GameManager _gm;
    private Transform _pos;
    private float _step;
    private bool _isDead;
    private bool _isStunned;
    private float _stunTime;
    public int cont;

    // Start is called before the first frame update
    void Start()
    {
        _isDead = false;
        _isStunned = false;
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        _ss = GameObject.Find("Spawners").GetComponent<SpawnerScript>();
        _pos = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        _step = 2f * Time.deltaTime;
        if (_pos != null && !_isDead && !_isStunned) { transform.position = Vector2.MoveTowards(transform.position, _pos.position, _step); }
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
            _stunTime = collision.gameObject.GetComponent<Bullet>().Stun;
            cont += bulletDmg;
            if (cont >= 10) 
            {
                _ss._enemiesLeft--;
                _gm.slainedEnemies(1);
                _gm.scorePoints(5);
                CollisionBehaviour(); 
            }
            if (_stunTime > 0f)
                StartCoroutine(StunBehaviour());
        }
    }

    void CollisionBehaviour()
    {
        Destroy(this.GetComponent<CapsuleCollider2D>());
        _isDead = true;
        animator.SetTrigger("Death");
        EffectAudioController.PlaySound("EnemyDeath");
        Invoke("Destroy", 1f);
    }

    IEnumerator StunBehaviour()
    {
        _isStunned = true;
        animator.SetBool("Stunned", true);
        yield return new WaitForSeconds(_stunTime);
        animator.SetBool("Stunned", false);
        _isStunned = false;
    }

    private void Destroy() 
    {
        Destroy(this.gameObject); 
    }
}
