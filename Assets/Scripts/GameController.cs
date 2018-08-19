using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Text[] buttonList;
    public Button restartButton;
    public Slider deepthSlider;
    public Text textSlider;
    public Text winnerText;
    public Texture croix;
    public Texture rond;


    private string playerSide;
    private int depth = 3;

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

    void Start()
    {
        //init slider
        changeTextSlider(3);
        deepthSlider.value = 3;
        deepthSlider.onValueChanged.AddListener(changeAIDeepth);
        winnerText.enabled = false;
    }

    void Awake(){
        setGameControllerReferenceOnButtons();
        playerSide = "X";
        restartButton.onClick.AddListener(Restart);
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

        winnerText.text = playerSide + " Win !";
        winnerText.enabled = true;

    }

    void changePlayer()
    {
        playerSide = (playerSide == "X") ? "O" : "X";

        if (playerSide == "O" && depth>0)
        {
            int indexToPLay = AI.Play(GameUtils.buttonListToStringList(buttonList),depth);
            buttonList[indexToPLay].text = "O";
            buttonList[indexToPLay].GetComponentInParent<Button>().interactable = false;
            endTurn();
        }
    }

    void Restart()
    {
        playerSide = "X";
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].text = "";
            buttonList[i].GetComponentInParent<Button>().interactable = true;
        }

        winnerText.enabled = false;
    }

    void changeTextSlider(int i)
    {
        textSlider.text = "Deepth = " + i;
    }

    void changeAIDeepth(float value)
    {
        depth = (int)value;
        changeTextSlider((int)value);
    }

 
    
}
