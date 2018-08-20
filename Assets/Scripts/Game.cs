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
        RawImage rawImage = button.GetComponent<RawImage>();
        if (gameController.getPlayerSide()=="X")
        {
           
           rawImage.texture = gameController.croix;
        }
        else
        {
            rawImage.texture = gameController.rond;
        }
        rawImage.color = Color.white;
        buttonText.text = gameController.getPlayerSide();
        buttonText.color = Color.clear; 
        button.interactable = false;
        gameController.endTurn();
    }

    public void setGameController(GameController gameController)
    {
        this.gameController = gameController;
    }
}
