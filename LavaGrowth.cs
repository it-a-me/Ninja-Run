using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaGrowth : MonoBehaviour
{       //presets variable types
    Transform playerTransform;
    float lavaSpeed;
    // Start is called before the first frame update
    void Start()
    {
        //loads the player's position
        playerTransform = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {   //sets the speed of lava
        lavaSpeed = playerTransform.position.x * 0.1f;
        lavaSpeed = Mathf.Max(lavaSpeed, 1);
        lavaSpeed = Mathf.Min(lavaSpeed, 6);
        //moves lava
        transform.localScale += new Vector3(lavaSpeed * Time.deltaTime, 0f, 0f);
        //makes sure the lava is never more the 10 units behind from the player
        if (playerTransform.position.x > transform.localScale.x * 0.5f + 10)
        {
            transform.localScale = new Vector3(playerTransform.position.x * 2 - 10, 20f, 1f);
        }

    }
}