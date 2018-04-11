using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Text[] buttonList;
    private string playerSide;

    public string getPlayerSide()
    {
        return playerSide;
    }

    public void endTurn()
    {
        if (GameUtils.isWin(GameUtils.buttonListToStringList(buttonList)) != "-1")
            gameFinish();

        changePlayer();
    }

    void Awake(){
        setGameControllerReferenceOnButtons();
        playerSide = "X";
    }

    void setGameControllerReferenceOnButtons()
    {
        for (int i =0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Game>().setGameController(this);
        }
    }

    void gameFinish()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = false;
        }
    }

    void changePlayer()
    {
        playerSide = (playerSide == "X") ? "O" : "X";

        if (playerSide == "O")
        {
            int indexToPLay = AI.Play(GameUtils.buttonListToStringList(buttonList));
            buttonList[indexToPLay].text = "O";
            buttonList[indexToPLay].GetComponentInParent<Button>().interactable = false;
            endTurn();
        }
        
    }

 
    
}
