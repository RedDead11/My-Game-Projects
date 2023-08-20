using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveObject : MonoBehaviour
{
    // Jump Location Support

    public float minX = -10.66f;
    public float maxX = 10.66f;

    public float minY = -4.4f;
    public float maxY = 4.4f;


    // Timer Support

    private const int TotalJumpDelaySeconds = 1;
    private float elapsedJumpDelaySeconds = 0f;

    private float timeLeft;



    private void Update()
    {
        // Generating Random Position

        Vector2 jumpPostition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));


        timeLeft = TotalJumpDelaySeconds - elapsedJumpDelaySeconds;

        if (elapsedJumpDelaySeconds > TotalJumpDelaySeconds && Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = jumpPostition;

            elapsedJumpDelaySeconds = 0f;
        }

        else if(elapsedJumpDelaySeconds < TotalJumpDelaySeconds && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Wait for " + timeLeft.ToString("F2") + " to jump again!");
        }

        elapsedJumpDelaySeconds += Time.deltaTime;

        

    }
}
