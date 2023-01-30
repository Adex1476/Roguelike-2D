using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int dmg;
    private float stunTime;
    public float _spe;
    [SerializeField] private Rigidbody2D rb;
    private Transform _firePoint;
    protected Vector2 dir;
    private float angle;
    public bool infiniteBullet;
    private Vector3 _mousePos;

    public int Dmg { get => dmg; set => dmg = value; }
    public float Stun { get => stunTime; set => stunTime = value; }


    // Start is called before the first frame update
    void Start()
    {
        infiniteBullet = true;
        _firePoint = GameObject.Find("FirePoint").transform;
        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dir = (_mousePos - transform.position).normalized;
        angle = Vector2.SignedAngle(Vector2.left, dir);
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        rb.velocity = dir * _spe;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Walls") || collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Breakable") || collision.gameObject.CompareTag("Spawner"))
        {
            Destroy(gameObject);
        }
    }
}
