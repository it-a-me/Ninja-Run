using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
        //sets up variables
    bool spaceLast = false;
    Rigidbody2D PlayerBody;
    BoxCollider2D PlayerCollider;
    Vector3 speed;
    Vector3 Velocity;
    // Start is called before the first frame update
    void Start()
    {   //loads player information
        PlayerBody = GetComponent<Rigidbody2D>();
        PlayerCollider = GetComponent<BoxCollider2D>();


    }

    // Update is called once per frame
    void Update()
    {
        //sets speed to 0
        speed = new Vector3(0, 0, 0);

            //raycast detect ground
        if (Physics2D.Raycast(transform.position + new Vector3(-0.49f, -0.500001f, 0), Vector2.down, 0.05f)|| Physics2D.Raycast(transform.position + new Vector3(0.49f, -0.500001f, 0), Vector2.down, 0.05f))
        {
            //jump if space is pressed.  spaceLast prevents a buffering jumps
            if (Input.GetKey("space") && !spaceLast) {
                speed.y = 450;
            }
            spaceLast = Input.GetKey("space");

            //directional movement
            if (Input.GetKey("a")) {
                speed.x += -1500f * Time.deltaTime;
            }

            if (Input.GetKey("d")) {
                speed.x += 1500f * Time.deltaTime;
            }

        } else {
                //movement in air
            if (Input.GetKey("a")) {
                speed.x += -1000f * Time.deltaTime;
            }

            if (Input.GetKey("d")) {
                speed.x += 1000f * Time.deltaTime;
            }
        }
        //apply speed
        PlayerBody.AddForce(speed);
        //set player look direction
        if (speed.x > 0) {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (speed.x < 0) {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        //max speeds
        Velocity = PlayerBody.velocity;
        Velocity.x = Mathf.Max(Velocity.x, -6000*Time.deltaTime);
        Velocity.x = Mathf.Min(Velocity.x, 6000*Time.deltaTime);
        PlayerBody.velocity = Velocity;

    }
}
