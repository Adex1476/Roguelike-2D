using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    
    public float spe;
    private bool dashAvailable;
    private bool invencible;
    public float invencibleDuration; 
    public float dashCD;
    public float dashF;
    private float x;
    private float y;

    private Vector2 dir = Vector2.right;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashAvailable = true;
        invencible = false;
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        Move();
    }

    private void FixedUpdate() { rb.AddForce(Vector2.zero * spe, ForceMode2D.Force); }

    private void Move()
    {
        if (x != 0 || y != 0)
        {
            dir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            transform.Translate(dir * Time.deltaTime * spe);
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
}
