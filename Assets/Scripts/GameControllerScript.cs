using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameControllerScript : MonoBehaviour
{
    public Canvas pauseMenu;
    public Canvas gameOverMenu;
    public GameObject[] gridCases;
    [SerializeField] 
    private TMP_Text countdownText;
    [SerializeField] 
    private TMP_Text scoreText;
    [SerializeField] 
    private TMP_Text finalScoreText; 
    [SerializeField]
    private TMP_Text highScoreText;

    public AudioSource appleSound;
    public AudioSource deathSound;
    public AudioSource backgroundMusic;

    private float length = 3;
    private float score = 0;

    private float timeRemaining = 3;
    public bool timerIsRunning = false;
    public bool gameIsStarted = false;
    [SerializeField] 
    private float timeBetweenMove;

    private int coordCase = 24;

    private string direction = "right";
    private string directionPrec = "right";
    private bool nextIsWall = false;

    private float bombTimer = 3f;
    private float timeRemainingBombs = 10f; 
    private float timeBetweenBombs = 10f;

    private void Start()
    {
        if(StateManager.Ssspeedster == true){
            timeBetweenMove = 0.2f;
        }else{
            timeBetweenMove = 0.4f;
        }
        // Starts the timer automatically
        Time.timeScale = 1;
        timerIsRunning = true;
        pauseMenu.enabled = false;
        gameOverMenu.enabled = false;
        highScoreText.enabled = false;
        countdownText.text = "3";
        backgroundMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        // When pressing esc, set pause menu to active
        // Prevent both to active in same frame

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            displayMenu();
        }

        if(pauseMenu.enabled == false){
            if (timerIsRunning)
            {
                if (timeRemaining > 0)
                {
                    timeRemaining -= Time.deltaTime;
                    countdownText.text = timeRemaining.ToString("0");
                }
                else
                {
                    timeRemaining = timeBetweenMove;
                    timerIsRunning = false;
                    countdownText.text = "";
                    gameIsStarted = true;
                    gridCases[coordCase].GetComponent<CaseScript>().setActive(length, timeBetweenMove);
                    SpawnApple();
                    InvokeRepeating("moveSnake", timeBetweenMove, timeBetweenMove);
                    if(StateManager.Bombsss){
                        InvokeRepeating("SpawnBomb", timeBetweenBombs, timeBetweenBombs);
                    }
                }
            }

            if (gameIsStarted){
                if (Input.GetKeyDown(KeyCode.UpArrow) && directionPrec != "down")
                {
                    direction = "up";
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow) && directionPrec != "up")
                {
                    direction = "down";
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow) && directionPrec != "right")
                {
                    direction = "left";
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow) && directionPrec != "left")
                {
                    direction = "right";
                }

                /*if(StateManager.Bombsss){
                    if (timeRemainingBombs > 0)
                    {
                        timeRemainingBombs -= Time.deltaTime;
                    }
                    else
                    {
                        timeRemainingBombs = timeBetweenBombs;
                        SpawnBomb();
                    }
                }*/
            }
        }
    }

    public void SpawnApple()
    {
        int randomCase = Random.Range(0, 48);
        if(gridCases[randomCase].GetComponent<CaseScript>().timerIsRunning == false && gridCases[randomCase].GetComponent<CaseScript>().hasBomb == false){
            gridCases[randomCase].GetComponent<CaseScript>().addApple();
        }else{
            SpawnApple();
        }
    }

    public void SpawnBomb()
    {
        int randomCase = Random.Range(0, 48);
        if(gridCases[randomCase].GetComponent<CaseScript>().timerIsRunning == false
        && gridCases[randomCase].GetComponent<CaseScript>().hasApple == false
        && randomCase != coordCase + 1 && randomCase != coordCase - 1 && randomCase != coordCase + 7 && randomCase != coordCase - 7){
            gridCases[randomCase].GetComponent<CaseScript>().addBomb();
        }else{
            SpawnBomb();
        }
    }

    public void moveSnake()
    {
        directionPrec = direction;

        if (direction == "up")
        {
            coordCase -= 7;
        }
        else if (direction == "down")
        {
            coordCase += 7;
        }
        else if (direction == "left")
        {
            coordCase -= 1;
        }
        else if (direction == "right")
        {
            coordCase += 1;
        }

        if((coordCase + 1) % 7 == 0 && direction == "left"){
            if (StateManager.SnakeInABox) {
                nextIsWall = true;
                coordCase += 1;
            } else {
                coordCase += 7;
            }
        }
        else if((coordCase - 1) % 7 == 6 && direction == "right"){
            if (StateManager.SnakeInABox) {
                nextIsWall = true;
                coordCase -= 1;
            } else {
                coordCase -= 7;
            }
        }
        else if(coordCase > 48){
            if (StateManager.SnakeInABox) {
                nextIsWall = true;
                coordCase -= 7;
            } else {
                coordCase -= 49;
            }
        }
        else if(coordCase < 0){
            if (StateManager.SnakeInABox) {
                nextIsWall = true;
                coordCase += 7;
            } else {
                coordCase += 49;
            }
        }

        if(gridCases[coordCase].GetComponent<CaseScript>().timerIsRunning || 
            gridCases[coordCase].GetComponent<CaseScript>().hasBomb || 
            nextIsWall){ //Game Over
            GameOver();
        }

        gridCases[coordCase].GetComponent<CaseScript>().setActive(length, timeBetweenMove);

        if(gridCases[coordCase].GetComponent<CaseScript>().hasApple){ // Apple
            gridCases[coordCase].GetComponent<CaseScript>().removeApple();
            for (int i = 0; i < gridCases.Length; i++)
            {
                if (gridCases[i].GetComponent<CaseScript>().timerIsRunning == true){
                    gridCases[i].GetComponent<CaseScript>().increaseLength(timeBetweenMove);
                }
            }
            length += 1;
            score += 1;
            scoreText.text = score.ToString("0");

            SpawnApple();
            appleSound.Play();
        }
    }

    public void GameOver(){
        for (int i = 0; i < gridCases.Length; i++){
            if (gridCases[i].GetComponent<CaseScript>().timerIsRunning == true){
                gridCases[i].GetComponent<CaseScript>().timerIsRunning = false;
            }
        }
        timerIsRunning = false;
        displayMenu(true);
    }

    public void displayMenu(bool gameOver = false){
    if(gameOver){
        //wait 3 seconds then display
        

        gameOverMenu.enabled = true;
        score = score * StateManager.Multiplier();
        finalScoreText.text = "Score - " + score.ToString("0");
        if(score > StateManager.highScore){
            StateManager.SetHighScore(score);
            highScoreText.enabled = true;
        }
        deathSound.Play();
        backgroundMusic.Stop();
        Time.timeScale = 0;
    }else{
        if (pauseMenu.isActiveAndEnabled)
        {
            pauseMenu.enabled = false;
            Time.timeScale = 1;
            backgroundMusic.Play();
        }
        else
        {
            pauseMenu.enabled = true;
            Time.timeScale = 0;
            backgroundMusic.Pause();
        }
    }
}
}