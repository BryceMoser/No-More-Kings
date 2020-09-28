using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Variables
    [SerializeField] public int score;
    [SerializeField] public int mailbag;
    [SerializeField] public int totalVotes = 0;
    [SerializeField] float timeRemaining = 90;
    private bool gameActive = true;
    private bool timerActive = false;

    //References to game objects, that get set within the inspector
    [SerializeField] GameObject player;
    [SerializeField] GameObject mail;
    [SerializeField] TextMeshProUGUI mailbagText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI timeLeftText;
    [SerializeField] TextMeshProUGUI gameOverText;
    [SerializeField] Button startButton;
    [SerializeField] Button restartButton;
    [SerializeField] GameObject titleScreen;
    [SerializeField] GameObject gameOverScreen;
 

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


    //Sets text before player starts the game
    void Start()
    {
        score = 0;
        mailbag = 0;
        scoreText.text = "Score: " + score;

    }

    //Removes title text, starts timer, and instantiates player/mail
    public void StartGame()
    {
        titleScreen.gameObject.SetActive(false);
        gameActive = true;
        //Player is set to specific coordinates to spawn in center
        Instantiate(player, new Vector3(-29f, 2f, -232f), player.transform.rotation);
        
        InvokeRepeating("SpawnRandomMail", 1f, 10f);
        timerActive = true;
    }

    private void Update()
    {
        scoreText.text = "Score: " + score;
        mailbagText.text = "Mailbag: " + mailbag + "/5";
        float minutes = Mathf.FloorToInt(timeRemaining / 60);
        float seconds = Mathf.FloorToInt(timeRemaining % 60);
        if (seconds > 9)
            timeLeftText.text = "Time Left: " + minutes + ":" + seconds;
        else
            timeLeftText.text = "Time Left: " + minutes + ":0" + seconds;
        //Timer, ending game when it reaches zero
        if (timerActive)
        {
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

    }

    //Chooses from the list of preselected positions on the map, and randomly spawns at one of them.
    void SpawnRandomMail()
    {
        if(gameActive)
        {
            int x = Random.Range(1, 13);
            Vector3 spawnPos = spawnPositions[x];
            Instantiate(mail, spawnPos, mail.transform.rotation);
        }
    }

    //Ends game, displays the number of ballots collected and the restart button
    void GameOver()
    {
        gameActive = false;
        gameOverText.text = "Ballots have been cast! You collected: " + totalVotes + " ballots! Democracy wins!";
        gameOverScreen.SetActive(true);
    }
    
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
