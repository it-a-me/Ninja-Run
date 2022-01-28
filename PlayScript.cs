using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayScript : MonoBehaviour
{
    // Start is called before the first frame update
    //destroys score gameobject when going to GameScene
    GameObject ScoreHolder;
    void Start()
    {
        ScoreHolder = GameObject.Find("Permanent");
    }

    // Update is called once per frame
    void Update()
    {       //changes to game scene
        if (Input.GetKey(KeyCode.Return) || Input.GetKey("y"))
        {
            Destroy(ScoreHolder);
            SceneManager.LoadScene(0);
            SceneManager.UnloadSceneAsync(1);

        }
    }
}
