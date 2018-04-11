using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {

    public Button button;
    public Text buttonText;

    private GameController gameController;

    public void SetUsed()
    {
        buttonText.text = gameController.getPlayerSide();
        button.interactable = false;
        gameController.endTurn();
    }

    public void setGameController(GameController gameController)
    {
        this.gameController = gameController;
    }
}
