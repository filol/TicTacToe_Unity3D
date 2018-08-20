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
    public Texture clear;


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
        deepthSlider.onValueChanged.AddListener(changeAIDeepth);
        deepthSlider.value = 1;
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
            buttonList[indexToPLay].color = Color.clear;
            RawImage rawImage = buttonList[indexToPLay].GetComponentInParent<Button>().GetComponent<RawImage>();
            rawImage.texture = rond;
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

            RawImage rawImage = buttonList[i].GetComponentInParent<Button>().GetComponent<RawImage>();
            rawImage.texture = clear;
            rawImage.color = Color.black;
        }

        winnerText.enabled = false;
    }


    void changeAIDeepth(float value)
    {
        depth = (int)value;
        switch ((int)value)
        {
            case 0:
                textSlider.text = "Aucune IA";
                depth = 0;
                break;
            case 1:
                textSlider.text = "IA facile";
                depth = 2;
                break;
            case 2:
                textSlider.text = "IA modéré";
                depth = 25;
                break;
            case 3:
                textSlider.text = "IA difficile";
                depth = 150;
                break;
        }
    }

 
    
}
