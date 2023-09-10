using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class StateManager{
    public static float highScore = 0;

    public static bool Rattlesnake = false;
    public static bool SnakeInABox = false;
    public static bool GoldenApples = false;
    public static bool Shedding = false;
    public static bool Bombsss = false;
    public static bool SnakeOLantern = false;
    public static bool SnakePit = false;
    public static bool Ssspeedster = false;
    public static bool Applesweeper = false;
    public static bool DrunkSnek = false;
    public static bool SnakeInvaders = false;
    public static bool Tippy = false;
    public static bool Rainbowsss = false;
    public static bool SnakeInABoat = false; 

    public static float RattlesnakeMultiplier = 0.5f;
    public static float SnakeInABoxMultiplier = 1f;
    public static float GoldenApplesMultiplier = 0.5f;
    public static float SheddingMultiplier = 1.5f;
    public static float BombsssMultiplier = 2f;
    public static float SnakeOLanternMultiplier = 3f;
    public static float SnakePitMultiplier = 2f;
    public static float SsspeedsterMultiplier = 3f;
    public static float ApplesweeperMultiplier = 2f;
    public static float DrunkSnekMultiplier = 0.5f;
    public static float SnakeInvadersMultiplier = 2f;
    public static float TippyMultiplier = 1f;
    public static float RainbowsssMultiplier = 0.5f;
    public static float SnakeInABoatMultiplier = 0.5f;

    public static void SetHighScore(float score){
        StateManager.highScore = score;
    }
 
    public static void setGameModifiers(bool Rattlesnake, bool SnakeInABox, bool GoldenApples, bool Shedding, bool Bombsss, bool SnakeOLantern, bool SnakePit, bool Ssspeedster, bool Applesweeper, bool DrunkSnek, bool SnakeInvaders, bool Tippy, bool Rainbowsss, bool SnakeInABoat){
        StateManager.Rattlesnake = Rattlesnake;
        StateManager.SnakeInABox = SnakeInABox;
        StateManager.GoldenApples = GoldenApples;
        StateManager.Shedding = Shedding;
        StateManager.Bombsss = Bombsss;
        StateManager.SnakeOLantern = SnakeOLantern;
        StateManager.SnakePit = SnakePit;
        StateManager.Ssspeedster = Ssspeedster;
        StateManager.Applesweeper = Applesweeper;
        StateManager.DrunkSnek = DrunkSnek;
        StateManager.SnakeInvaders = SnakeInvaders;
        StateManager.Tippy = Tippy;
        StateManager.Rainbowsss = Rainbowsss;
        StateManager.SnakeInABoat = SnakeInABoat;
    }

    public static Dictionary<string, bool>  getGameModifiers(){
        Dictionary<string, bool> gameModifiers = new Dictionary<string, bool>();
        gameModifiers.Add("Rattlesnake", Rattlesnake);
        gameModifiers.Add("SnakeInABox", SnakeInABox);
        gameModifiers.Add("GoldenApples", GoldenApples);
        gameModifiers.Add("Shedding", Shedding);
        gameModifiers.Add("Bombsss", Bombsss);
        gameModifiers.Add("SnakeOLantern", SnakeOLantern);
        gameModifiers.Add("SnakePit", SnakePit);
        gameModifiers.Add("Ssspeedster", Ssspeedster);
        gameModifiers.Add("Applesweeper", Applesweeper);
        gameModifiers.Add("DrunkSnek", DrunkSnek);
        gameModifiers.Add("SnakeInvaders", SnakeInvaders);
        gameModifiers.Add("Tippy", Tippy);
        gameModifiers.Add("Rainbowsss", Rainbowsss);
        gameModifiers.Add("SnakeInABoat", SnakeInABoat);
        return gameModifiers;
    }

    public static float Multiplier(){
        float multiplier = 1f;
        if(Rattlesnake){multiplier += RattlesnakeMultiplier;}
        if(SnakeInABox){multiplier += SnakeInABoxMultiplier;}
        if(GoldenApples){multiplier += GoldenApplesMultiplier;}
        if(Shedding){multiplier += SheddingMultiplier;}
        if(Bombsss){multiplier += BombsssMultiplier;}
        if(SnakeOLantern){multiplier += SnakeOLanternMultiplier;}
        if(SnakePit){multiplier += SnakePitMultiplier;}
        if(Ssspeedster){multiplier += SsspeedsterMultiplier;}
        if(Applesweeper){multiplier += ApplesweeperMultiplier;}
        if(DrunkSnek){multiplier += DrunkSnekMultiplier;}
        if(SnakeInvaders){multiplier += SnakeInvadersMultiplier;}
        if(Tippy){multiplier += TippyMultiplier;}
        if(Rainbowsss){multiplier += RainbowsssMultiplier;}
        if(SnakeInABoat){multiplier += SnakeInABoatMultiplier;}

        return multiplier;
    }
}
 