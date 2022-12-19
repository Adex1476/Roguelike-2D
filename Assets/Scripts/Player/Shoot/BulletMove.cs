using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    private float dmg;
    private float _spe;
    [SerializeField] private Rigidbody2D rb;
    private Transform _firePoint;
    public bool infiniteBullet;

    private float _mouseX;
    private float _mouseY;
    private Vector3 _initialPos;

    private Vector3 mousePosPix;
    private Vector3 mousePos;

    public Transform FirePoint { get => _firePoint; set => _firePoint = value; }
    public float Dmg { get => dmg; set => dmg = value; }


    // Start is called before the first frame update
    void Start()
    {
        mousePosPix = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePosPix);

        _mouseX = mousePos.x;
        _mouseY = mousePos.y;

        _initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float step = _spe * Time.deltaTime;
        if (infiniteBullet)
        {
            rb.AddForce((mousePos - _initialPos) * step, ForceMode2D.Impulse);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, mousePos, step * 10);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Walls"))
        {
            Destroy(gameObject);
        }
    }

}
