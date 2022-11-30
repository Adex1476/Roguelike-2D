using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private Animator _anim;
    [SerializeField] private Collider2D _coll;
    [SerializeField] private SpriteRenderer _sr;

    private bool _dashAvailable, _invencible;
    public float spe, invencibleDuration, dashCD, dashF;

    private float x, y, _invencibleTime;

    private Mov m;
    private Vector2 dir;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _invencibleTime = invencibleDuration / 0.1f;
        _dashAvailable = true;
        _invencible = false;
    }

    private void Update() 
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        Move();
    }

    private void Move()
    {  
        if (x != 0 || y != 0)
        {
            dir = new Vector2(x, y);
            _rb.AddForce(dir * spe, ForceMode2D.Force);
        }

        if (x == 0 && y == 0) { _rb.velocity = Vector2.zero; }

        if (Input.GetKeyDown(KeyCode.Space) && _dashAvailable)
        {
            _rb.velocity = Vector2.zero;
            _anim.SetBool("isDashing", true);
            Dash();
        }
    }

    private void Dash()
    {
        m = Mov.Dash;
        _rb.AddForce(dir.normalized * dashF, ForceMode2D.Impulse);
        StartCoroutine(canDash());
        StartCoroutine(invulnerability());
    }

    IEnumerator canDash()
    {
        _dashAvailable = false;
        yield return new WaitForSeconds(dashCD);
        _dashAvailable = true;
    }

    IEnumerator invulnerability()
    {
        _invencible = true;
        yield return new WaitForSeconds(invencibleDuration);
        _invencible = false;
        _anim.SetBool("isDashing", false);
        _rb.velocity = Vector2.zero;
    }

    public enum Mov { Movement, Stop, Dash }
}