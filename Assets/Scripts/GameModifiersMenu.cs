using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameModifiersMenu : MenuController
{
    public void Start(){
        RattlesnakeToggle.isOn = StateManager.Rattlesnake;
        SnakeInABoxToggle.isOn = StateManager.SnakeInABox;
        GoldenApplesToggle.isOn = StateManager.GoldenApples;
        SheddingToggle.isOn = StateManager.Shedding;
        BombsssToggle.isOn = StateManager.Bombsss;
        SnakeOLanternToggle.isOn = StateManager.SnakeOLantern;
        SnakePitToggle.isOn = StateManager.SnakePit;
        SsspeedsterToggle.isOn = StateManager.Ssspeedster;
        ApplesweeperToggle.isOn = StateManager.Applesweeper;
        DrunkSnekToggle.isOn = StateManager.DrunkSnek;
        SnakeInvadersToggle.isOn = StateManager.SnakeInvaders;
        TippyToggle.isOn = StateManager.Tippy;
        RainbowsssToggle.isOn = StateManager.Rainbowsss;
        SnakeInABoatToggle.isOn = StateManager.SnakeInABoat;
    }

    public Toggle RattlesnakeToggle;
    public Toggle SnakeInABoxToggle;
    public Toggle GoldenApplesToggle;
    public Toggle SheddingToggle;
    public Toggle BombsssToggle;
    public Toggle SnakeOLanternToggle;
    public Toggle SnakePitToggle;
    public Toggle SsspeedsterToggle;
    public Toggle ApplesweeperToggle;
    public Toggle DrunkSnekToggle;
    public Toggle SnakeInvadersToggle;
    public Toggle TippyToggle;
    public Toggle RainbowsssToggle;
    public Toggle SnakeInABoatToggle;

    public override void LoadGameScene()
    {
        StateManager.Rattlesnake = RattlesnakeToggle.isOn ? true : false;
        StateManager.SnakeInABox = SnakeInABoxToggle.isOn ? true : false;
        StateManager.GoldenApples = GoldenApplesToggle.isOn ? true : false;
        StateManager.Shedding = SheddingToggle.isOn ? true : false;
        StateManager.Bombsss = BombsssToggle.isOn ? true : false;
        StateManager.SnakeOLantern = SnakeOLanternToggle.isOn ? true : false;
        StateManager.SnakePit = SnakePitToggle.isOn ? true : false;
        StateManager.Ssspeedster = SsspeedsterToggle.isOn ? true : false;
        StateManager.Applesweeper = ApplesweeperToggle.isOn ? true : false;
        StateManager.DrunkSnek = DrunkSnekToggle.isOn ? true : false;
        StateManager.SnakeInvaders = SnakeInvadersToggle.isOn ? true : false;
        StateManager.Tippy = TippyToggle.isOn ? true : false;
        StateManager.Rainbowsss = RainbowsssToggle.isOn ? true : false;
        StateManager.SnakeInABoat = SnakeInABoatToggle.isOn ? true : false;

        SceneManager.LoadScene("Jeu");
    }

}
