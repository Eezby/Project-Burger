using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    public float moveSpeed = 3f;
    float Velx;
    float Vely;
    bool facingRight = true;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        Velx = Input.GetAxisRaw("Horizontal");
        Vely = rb.velocity.y;
        rb.velocity = new Vector2(Velx * moveSpeed, Vely);
    }

    void FixedUpdate()
    {
        Vector3 localScale = transform.localScale;
        if (Velx > 0)
        {
            facingRight = true;
        }
        else if (Velx < 0)
        {
            facingRight = false;
        }

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
        {
            localScale.x *= -1;
        }
        transform.localScale = localScale;
    }
}
