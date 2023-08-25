using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField]
    private float thrustForce = 10f;
    private bool isThrusting = false;


    private Vector2 thrustPosition = new Vector2(1, 0);
    private Vector2 force = new Vector2(0, 0);
    

    private Rigidbody2D rb;
    private CircleCollider2D shipCollider;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        shipCollider = GetComponent<CircleCollider2D>();

        float colliderRadius = shipCollider.radius;
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        moveShip();
    }


    void changeDirection()
    {

    }

    void moveShip()
    {
        if (Input.GetAxis("Thrust") > 0 && isThrusting == false)
        {
            Vector2 force = thrustPosition * thrustForce;
            rb.AddForce(force, ForceMode2D.Impulse);
            isThrusting = true;

            Debug.Log("Space");
        }

        if (Input.GetAxis("Thrust") == 0 && isThrusting == true)
        {
            isThrusting = false;
        }
    }

    private void OnBecameInvisible()
    {
        transform.position = new Vector2(-10.8f,0f);
    }
}
