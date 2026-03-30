using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    
    
    void Start()
    {

        scoreText.text = $"You scored {FindObjectOfType<ScoreKeeper>().GetCurrentScore()}";
        Destroy(FindObjectOfType<ScoreKeeper>().gameObject);

    }
}
