using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIBehaviour : MonoBehaviour
{
    [SerializeField] Health playerHealth;
    
    [SerializeField] Slider healthSlider;
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;
    

    void Awake()
    {
        
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        healthSlider.maxValue = playerHealth.GetHealth();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = playerHealth.GetHealth();
        scoreText.text = scoreKeeper.GetCurrentScore().ToString("D6");
    }

    
}
