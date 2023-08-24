using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class ChangeCharacter : MonoBehaviour
{
    [SerializeField]
    private Sprite[] characters;

    SpriteRenderer mySprite;
    private Vector2 maxScale = new Vector2(3, 3);


    int sizeX = 3;
    int sizeY = 3;

    private int currentIndex = 0;

    private void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {

        if(Input.GetMouseButtonDown(0))
        {
            SpriteCycle();
        }

        

        if (Input.GetKeyDown(KeyCode.Z))
        {
            sizeX += 1;
            transform.localScale = new Vector2(sizeX, sizeY);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            sizeX -= 1;
            transform.localScale = new Vector2(sizeX, sizeY);
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            sizeY += 1;
            transform.localScale = new Vector2(sizeX, sizeY);
        }  
        
        if (Input.GetKeyDown(KeyCode.B))
        {
            sizeY -= 1;
            transform.localScale = new Vector2(sizeX, sizeY);
        }
    }

    void SpriteCycle()
    {
        currentIndex++;

        if(currentIndex >= characters.Length)
        {
            currentIndex = 0;
        }

        mySprite.sprite = characters[currentIndex];
    }

}
