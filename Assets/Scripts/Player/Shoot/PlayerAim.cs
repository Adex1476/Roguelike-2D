using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    public Transform target;
    protected Vector2 dir;
    private float angle;

    // Start is called before the first frame update
    private void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dir = (mousePos - transform.position).normalized;
        angle = Vector2.SignedAngle(Vector2.down, dir);
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

}
