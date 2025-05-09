using System;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    int score = 0;
    [SerializeField] GameObject Hoop;
    public bool switchHoop = true;
    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI timerTxt;
    [SerializeField] float timeLimit = 60f;
    float totalTime = 60f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "Hoop")
        {

            score += 100;
            timeLimit = totalTime;
            if (switchHoop)
            {
                switchHoop = false;
            }

            else if (switchHoop == false)
            {
                switchHoop = true;
            }
        }
    }

    void Update()
    {
        basketTimer(); // Calculates the time to basket. 
        scoreToTMP(); // Passes the score value to TMP
        switchTheHoop(); // Transforms the hoop
        scoreTimeBracket(); //Different timer based on score
    }

    private void scoreTimeBracket()
    {
        if (score > 300)
        {
            totalTime = 50f;
        }

        if (score > 500)
        {
            totalTime = 40f;
        }

        if (score > 700)
        {
            totalTime = 25f;
        }
    }

    private void scoreToTMP()
    {
        scoreTxt.text = score.ToString();
    }

    private void switchTheHoop()
    {
        if (switchHoop == true)
        {
            Hoop.transform.position = new Vector3(7, 0, 0);
        }

        if (switchHoop == false)
        {
            Hoop.transform.position = new Vector3(-7, 0, 0);
        }
    }

    private void basketTimer()
    {
        timeLimit -= Time.deltaTime;
        timerTxt.text = Mathf.FloorToInt(timeLimit).ToString();
        if (timeLimit <= 0)
        {
            timerTxt.text = "Time up!";
        }

    }
}
