using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseScript : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public bool timerIsRunning = false;
    public double timeRemaining;

    public bool hasApple = false;

    public bool hasGoldenApple = false;

    public bool hasBomb = false;
    public float timeRemainingBomb = 0f;
    public float bombTimerDuration = 5f;


    public void setActive(float length, float timeBetweenMove)
    {
        spriteRenderer.color = new Color(0, 0, 1, 1);
        timerIsRunning = true;
        timeRemaining = length*timeBetweenMove;
    }
    public void setEmpty()
    {
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }

    public void Update(){

        if(timerIsRunning){
            if(timeRemaining > 0){
                timeRemaining -= Time.deltaTime;
            }else{
                timeRemaining = 0;
                timerIsRunning = false;
                setEmpty();
            }
        }

        if(hasBomb){ //Baisser l'opacité à chaque frame, 
            if(timeRemainingBomb > 0){
                timeRemainingBomb -= Time.deltaTime;
                spriteRenderer.color = new Color(0,0,0,(float)timeRemainingBomb/bombTimerDuration);
            }else{
                timeRemainingBomb = 0;
                bombExplode();
            }
        }
    }

    public void addApple(){
        hasApple = true;
        spriteRenderer.color = new Color(1, 0, 0, 1);
    }
    public void removeApple(){
        hasApple = false;
    }
    public void addBomb(){
        hasBomb = true;
        timeRemainingBomb = bombTimerDuration;
        spriteRenderer.color = new Color(0, 0, 0, 1);
    }
    public void bombExplode(){
        hasBomb = false;
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }
    public void increaseLength(float timeBetweenMove){
        timeRemaining += timeBetweenMove;
    }
}
