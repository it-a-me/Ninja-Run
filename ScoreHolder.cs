using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHolder : MonoBehaviour
{
    Transform playerTransform;
    float score;
    GameObject ScoreDisplay;
    void Start()
    {
        //gets gameobject and no destroy on load
        ScoreDisplay = GameObject.Find("ScoreDisplay");
        playerTransform = GameObject.Find("Player").transform;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        //if playerTransform exists sets score
        if (playerTransform != null)
        {
            score = Mathf.Max(Mathf.Floor(playerTransform.position.x), score);
        }
        //sets score text
        ScoreDisplay.GetComponent<UnityEngine.UI.Text>().text = "score: " + score.ToString();

    }
}