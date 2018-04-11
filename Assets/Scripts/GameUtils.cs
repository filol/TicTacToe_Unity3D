using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUtils : MonoBehaviour {

    readonly int SIZE_TAB = 3;
    public static string humanSign = "O";
    public static string AISign = "X";

	/**
         * Retourne le signe du joueur ou -1 si personne ne gagne
         **/
     public static string isWin(List<string> list)
{
    //Lignes
    if (list[0] == list[1] && list[1] == list[2] && list[1]!="")
        return list[0];
    if (list[3] == list[4] && list[4] == list[5] && list[5] != "")
        return list[3];
    if (list[6] == list[7] && list[7] == list[8] && list[8] != "")
        return list[6];
    //colonnes
    if (list[0] == list[3] && list[3] == list[6] && list[6] != "")
        return list[0];
    if (list[1] == list[4] && list[4] == list[7] && list[7] != "")
        return list[1];
    if (list[2] == list[5] && list[5] == list[8] && list[8] != "")
        return list[2];
    //diagos
    if (list[0] == list[4] && list[4] == list[8] && list[8] != "")
        return list[0];
    if (list[2] == list[4] && list[4] == list[6] && list[6] != "")
        return list[2];
    return "-1";
}

public static List<string> buttonListToStringList(Text[] texts)
{
    List<string> list = new List<string>();
    foreach (Text text in texts)
    {
        list.Add(text.text);
    }
    return list;
}
}
