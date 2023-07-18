using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float turnSpeed;

    private float HorizontalInput;
    private float ForwardInput;



    void Start()
    {
        
    }

    void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal");

        ForwardInput = Input.GetAxis("Vertical");

        // Moves the player forward 

        transform.Translate(Vector3.forward * Time.deltaTime * speed * ForwardInput);

        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * HorizontalInput);

        
                                                            
        
    }


    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Obstacle")
    //    {
    //        speed += 2f;
    //        Debug.Log("Car Speed = " + speed);
    //    }
    //}
}
