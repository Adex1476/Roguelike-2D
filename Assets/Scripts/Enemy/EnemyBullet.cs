using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private GameManager _gm;
    [SerializeField] private Animator _anim;
    private GameObject _player;
    private Rigidbody2D _rb;
    public float force;
    private float _rot;
    private Vector3 _dir;

    // Start is called before the first frame update
    void Start()
    {
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        _rb = GetComponent<Rigidbody2D>();
        _player = GameObject.FindGameObjectWithTag("Player");

        _dir = _player.transform.position - transform.position;
        _rb.velocity = new Vector2(_dir.x, _dir.y).normalized * force;
        _rot = Mathf.Atan2(-_dir.y, -_dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, _rot - 90);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Walls") || collision.CompareTag("Obstacle"))
        {
            _rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            _rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            _anim.SetTrigger("Impact");
            Destroy(this.GetComponent<CapsuleCollider2D>());
            Invoke("Destroy", 1f);
        }
        if (collision.CompareTag("Breakable"))
        {
            _rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            _rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            _anim.SetTrigger("Impact");
            Destroy(this.GetComponent<CapsuleCollider2D>());
            Destroy(collision.gameObject);
            Invoke("Destroy", 1f);
        }
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.dmg();
            _rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            _rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            _anim.SetTrigger("Impact");
            Destroy(this.GetComponent<CapsuleCollider2D>());
            Invoke("Destroy", 1f);
            if (_gm.hp == 0)
            {
                Destroy(collision.gameObject);
                _gm.ReloadScene();
            }
        }
    }

    void Destroy() { Destroy(gameObject); }
}
