using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    public int score = 0;
    private float respownTime = 1.0f;
    public Button restartButton;
    public Button exitButton;
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOver;
    public bool isGameActive;
    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        score = 0;
        StartCoroutine(RespwnTimed());
        ScoreToAddMethod(0);
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RespwnTimed()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(respownTime);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public int ScoreToAddMethod(int ScoreToAdd)
    {
        score += ScoreToAdd;
        scoreText.text = "Score: " + score;
        return ScoreToAdd;
    }

    public void GameOver()
    {
        
        isGameActive = false;
        gameOver.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);


    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
