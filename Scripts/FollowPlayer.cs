using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject Player;

    public Vector3 CamOffset = new Vector3(0, 0, 0);


    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Player.transform.position + CamOffset;
    }
}
