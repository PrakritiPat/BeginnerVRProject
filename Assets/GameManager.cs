using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public int score;


    private void Start()
    {

        NewGame();
    }

    private void NewGame()
    {
        score = 0;
        scoreText.text = score.ToString();
    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
        if(score ==10)
        {
            SceneManager.LoadScene(1);
        }
    }
}
