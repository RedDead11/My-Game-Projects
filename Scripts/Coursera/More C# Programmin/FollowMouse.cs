using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{

    private float minX = -22.65f;
    private float maxX =  22.65f;

    private float minY = -4.26f;
    private float maxY =  4.26f;


    private Vector3 birdPos = new Vector3(0, 0, 0);

    void Update()
    {

        Vector3 mousePos = Input.mousePosition;

        Vector3 birdPos = Camera.main.ScreenToWorldPoint(mousePos);

        float ClampedX = Mathf.Clamp(birdPos.x, minX, maxX);
        float ClampedY = Mathf.Clamp(birdPos.y, minY, maxY);

        birdPos = new Vector3(ClampedX, ClampedY, 0f);

        transform.position = birdPos;
        
    }

}
