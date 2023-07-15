
// MOVEMENT FOR PC

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Character_Controller : MonoBehaviour
//{
//    public float speed = 2f;
//    private SpriteRenderer char_sprite;
//    Rigidbody2D rb;

//    Vector2 dir = Vector2.zero;


//    private void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();
//        char_sprite = rb.GetComponent<SpriteRenderer>();
//    }

//    private void FixedUpdate()
//    {
//        dir.x = Input.GetAxisRaw("Horizontal");

//        if(dir.x < 0)
//        {
//            char_sprite.flipX = false;
//        }

//        else if (dir.x > 0)
//        {
//            char_sprite.flipX = true;
//        }

//        dir.y = Input.GetAxisRaw("Vertical");

//        rb.velocity = dir * speed;
//    }

//}




// MOVEMENT SCRIPT FOR MOBILE PHONES:



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour
{
    public float speed = 2f;
    private SpriteRenderer char_sprite;
    Rigidbody2D rb;

    Vector2 touchStartPos;
    Vector2 touchEndPos;
    Vector2 dir = Vector2.zero;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        char_sprite = rb.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchStartPos = touch.position;
                    break;

                case TouchPhase.Moved:
                    Vector2 touchCurrentPos = touch.position;
                    Vector2 touchDelta = touchCurrentPos - touchStartPos;
                    dir.x = touchDelta.x / Screen.width;
                    dir.y = touchDelta.y / Screen.height;
                    break;

                case TouchPhase.Ended:
                    dir = Vector2.zero;
                    break;
            }
        }
        else
        {
            dir = Vector2.zero;
        }

        if (dir.x < 0)
        {
            char_sprite.flipX = false;
        }

        else if (dir.x > 0)
        {
            char_sprite.flipX = true;
        }

        rb.velocity = dir * speed;
    }
}

