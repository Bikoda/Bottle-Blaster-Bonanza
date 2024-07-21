using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score;
    private float respownTime = 1.0f;
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RespwnTimed());
        score = 0;
        ScoreToAddMethod(0);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RespwnTimed()
    {
        while (true)
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
}
