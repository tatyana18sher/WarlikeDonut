using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : Unit
{
    public static int scoreAmount; // переменная, содержащая кол очков
    public Text scoreText;
    // Start is called before the first frame update
    private void Start()
    {
        scoreText = GetComponent<Text>();    
        scoreAmount = 0; 
    }

    // Update is called once per frame
    private void Update()
    {
        scoreText.text = "Score: " + scoreAmount;
    }
}
