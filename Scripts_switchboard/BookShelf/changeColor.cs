using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColor : MonoBehaviour
{
    private SpriteRenderer bookshelf;
    void Start()
    {
        bookshelf = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) 
        {
            bookshelf.color = Color.green;
        }   
    }
}
