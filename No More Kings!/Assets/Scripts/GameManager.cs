using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject mail;
    [SerializeField] public int score;
    [SerializeField] public int mailbag;
    [SerializeField] float timeRemaining = 180;
    [SerializeField] GameObject player;
    [SerializeField] TextMeshProUGUI mailbagText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI timeLeftText;
 



    private bool gameActive = true;
    //Entering specific transform locations for all spawn location
    private Vector3[] spawnPositions = new Vector3[]
        {
            new Vector3(-173f, 0f, -222f),
            new Vector3(-173f, 0f, -323f),
            new Vector3(-176f, 0f, -421.5f),
            new Vector3(123f, 0f, -222f),
            new Vector3(123f, 0f, -323f),
            new Vector3(123f, 0f, -421.5f),
            new Vector3(-131f, 0f, -280f),
            new Vector3(-75f, 0f, -280f),
            new Vector3(19f, 0f, -280f),
            new Vector3(75f, 0f, -280f),
            new Vector3(-131f, 0f, -385f),
            new Vector3(-75f, 0f, -385f),
            new Vector3(19f, 0f, -385f),
            new Vector3(75f, 0f, -385f),
            new Vector3(-131f, 0f, -480f),
            new Vector3(-75f, 0f, -480f),
            new Vector3(19f, 0f, -480f),
            new Vector3(75f, 0f, -480f)

        };


    // Start is called before the first frame update
    void Start()
    {
        Instantiate(player, new Vector3(-29f, 2f, -232f), player.transform.rotation);
        
        //GameObject player = GameObject.Find("Player");
        InvokeRepeating("SpawnRandomMail", 1f, 10f);
        score = 0;
        mailbag = 0;
        scoreText.text = "Score: " + score;

    }

    private void Update()
    {
        scoreText.text = "Score: " + score;
        mailbagText.text = "Mailbag: " + mailbag + " / 5";
        float minutes = Mathf.FloorToInt(timeRemaining / 60);
        float seconds = Mathf.FloorToInt(timeRemaining % 60);
        timeLeftText.text = "Time Left: "+ minutes + " : " + seconds;
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            timeRemaining = 0;
            GameOver();
        }
 

    }

    void SpawnRandomMail()
    {
        if(gameActive == true)
        {
            int x = Random.Range(1, 13);
            Vector3 spawnPos = spawnPositions[x];
            Instantiate(mail, spawnPos, mail.transform.rotation);
        }
    }

    void GameOver()
    {
        gameActive = false;
    }
}
