using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldGen : MonoBehaviour
{
    //sets up variables
    public float scroll = 10;
    Transform playerTransform;
    Transform lavaTransform;
    public GameObject levelTemplate1;
    public GameObject levelTemplate2;
    public GameObject levelTemplate3;
        //attempted LavaCollisionfix: float lavaSpeed;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
        lavaTransform = GameObject.Find("Lava").transform;
    }

    // Update is called once per frame
    void Update()
    {
            //attempted LavaCollisionfix: lavaSpeed = lavaTransform.localScale.y - 20;
            //attempted LavaCollisionfix: Debug.Log((lavaTransform.localScale.y-20).ToString()+"calc");
            //attempted LavaCollisionfix: Debug.Log(lavaTransform.position.x.ToString() +lavaLastX.ToString());
            //attempted LavaCollisionfix: Debug.Log((playerTransform.position.x - 0.3f).ToString()+"   "+(lavaTransform.position.x + lavaTransform.localScale.x * 0.5f).ToString());
            //attempted LavaCollisionfix: if (playerTransform.position.x-0.3f + lavaSpeed*Time.deltaTime < lavaTransform.position.x + lavaTransform.localScale.x * 0.5f||playerTransform.position.y < -5)

        //change scenes if the player colides with lava or falls from world
        if (playerTransform.position.x-0.3f < lavaTransform.position.x + lavaTransform.localScale.x * 0.5f||playerTransform.position.y < -5)
        {
            SceneManager.LoadScene(1);
            SceneManager.UnloadSceneAsync(0);
        }
            //generates terrain as it nears player
        if (playerTransform.position.x > scroll-20f)
        {
            int randomLevel = Random.Range(1, 4);
            if (randomLevel == 1)
            {
                Instantiate(levelTemplate1, new Vector3(scroll, -3.5f, 0f), Quaternion.identity);
                //Debug.Log("terrainGen1");
                scroll += 10;

            } else if (randomLevel == 2)
            {
                Instantiate(levelTemplate2, new Vector3(scroll, -3.5f, 0f), Quaternion.identity);
                //Debug.Log("terrainGen2");
                scroll += 10;
            }
            else if (randomLevel == 3)
            {
                Instantiate(levelTemplate3, new Vector3(scroll, -3.5f, 0f), Quaternion.identity);
                //Debug.Log("terrainGen3");
                scroll += 10;
            }
        }
    }
}
