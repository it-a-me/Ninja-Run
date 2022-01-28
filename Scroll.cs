using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    //set up variable
    public float scrollSpeed;
    Transform playerTransform;
    float zPos;
    float xPos;

    // Start is called before the first frame update
    void Start()
    {   //get player
        playerTransform = GameObject.Find("Player").transform;
        //get start x and z to manage offsets
        zPos = transform.position.z;
        xPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        //math to make camera loop around camera
        float xOffset = ((playerTransform.position.x * scrollSpeed)%21.6f)-xPos;
        transform.position = new Vector3(playerTransform.position.x-xOffset, 0f, zPos);

        
    }
}
