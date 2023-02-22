using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject _proj;
    [SerializeField] private Transform _projPos;
    [SerializeField] private Animator _anim;
    [SerializeField] private Animator animator;
    private SpawnerScript _ss;
    private GameManager _gm;
    private EnemySpawner _es;
    private bool _isDead;
    private bool _isStunned;
    private float _stunTime;
    private float timer;
    public int cont;

    // Start is called before the first frame update
    void Start()
    {
        _isDead = false;
        _isStunned = false;
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        _ss = GameObject.Find("Spawners").GetComponent<SpawnerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.isPaused)
        {
            timer += Time.deltaTime;
            if (timer > 2f && !_isStunned)
            {
                timer = 0;
                Shoot();
            }
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
            int bulletDmg = collision.gameObject.GetComponent<Bullet>().Dmg;
            _stunTime = collision.gameObject.GetComponent<Bullet>().Stun;
            cont += bulletDmg;
            if (cont >= 30) { CollisionBehaviour(); }
            if(_stunTime > 0f) 
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
        _ss._enemiesLeft--;
        _gm.slainedEnemies(1);
        _gm.scorePoints(10);
        Destroy(this.gameObject); 
    }
}