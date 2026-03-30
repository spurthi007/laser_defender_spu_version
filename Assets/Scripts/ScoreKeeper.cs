using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreKeeper : MonoBehaviour
{
    private int currentScore;
    [SerializeField] int scoreToIncrease = 10;
    
    void Start()
    {
        int instanceCount = FindObjectsOfType(GetType()).Length;
        if(instanceCount > 1)
        {
            //gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    

    public void AddScore()
    {
        //Debug.Log("health.enemy: "+health.enemy);
        //Debug.Log("Layer name "+health.gameObject.layer);

        currentScore += scoreToIncrease;
        //Debug.Log("Score is " + currentScore);


    }

    //Instructor's version
    // public void ModifyScore(int value)
    // {
    //     score += value;
    //     Mathf.Clamp(score, 0, int.MaxValue);
    //     Debug.Log(score);
    // }


    public int GetCurrentScore()
    {
        return currentScore;
    }

    public void ResetScore()
    {
        currentScore = 0;
    }
}
