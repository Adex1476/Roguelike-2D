using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    
    private bool dashAvailable, invencible;
    public float spe, invencibleDuration, dashCD, dashF;

    private float x, y;

    private Mov m;
    private Vector2 dir;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        dashAvailable = true;
        invencible = false;
    }

    private void FixedUpdate() 
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
            rb.AddForce(dir * spe, ForceMode2D.Force);
        }

        if (x == 0 && y == 0) { rb.velocity = Vector2.zero; }

        if (Input.GetKeyDown(KeyCode.Space) && dashAvailable)
        {
            rb.velocity = Vector2.zero;
            Dash();
        }
    }

    private void Dash()
    {
        m = Mov.Dash;
        rb.AddForce(dir.normalized * dashF, ForceMode2D.Impulse);
        StartCoroutine(canDash());
        StartCoroutine(invulnerability());
    }

    IEnumerator canDash()
    {
        dashAvailable = false;
        yield return new WaitForSeconds(dashCD);
        dashAvailable = true;
    }

    IEnumerator invulnerability()
    {
        invencible = true;
        yield return new WaitForSeconds(invencibleDuration);
        invencible = false;
        rb.velocity = Vector2.zero;
    }

    public enum Mov { Movement, Stop, Dash }
}