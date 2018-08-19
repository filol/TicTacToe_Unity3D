using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {



	public static int Play(List<string> tab, int depthMax)
    {
        return minimax(0,tab, GameUtils.AISign,depthMax);
    }

    public static int minimax(int depth, List<string> tab, string playerSign, int depthMax)
    {
        if (depth > depthMax)
            return 0;
        depth++;

        List<int> availSpots = availSpot(tab);
        //Check victory conditions
        if (GameUtils.isWin(tab) == GameUtils.humanSign)
            return -10;
        else
            if (GameUtils.isWin(tab) == GameUtils.AISign)
            return 10;
        if (availSpots.Count == 0)
            return 0;

        List<List<object>> moves = new List<List<object>>();

        for (int i = 0; i < availSpots.Count; i++)
        {
            List<object> move = new List<object>();
            move.Add(availSpots[i]);
            tab[availSpots[i]] = playerSign;

            if (playerSign == GameUtils.AISign)
            {
                int result = minimax(depth,tab, GameUtils.humanSign,depthMax);
                move.Add(result);
            } else
            {
                int result = minimax(depth,tab, GameUtils.AISign,depthMax);
                move.Add(result);
            }

            tab[availSpots[i]] = "";

            moves.Add(move);
        }

        int bestMove = 0;
        if (playerSign == GameUtils.AISign)
        {
            int bestScore = -99999;
            string log = "Moves IA : [";

            for (int i = 0; i < moves.Count; i++)
            {
                log += moves[i][1] + ",";
                if ((int)moves[i][1] > bestScore)
                {
                    bestScore = (int)moves[i][1];
                    bestMove = i;
                }
            }
            Debug.Log(log + "]");
        }
        else
        {
            int bestScore = 99999;
            string log = "Moves Player : [";
            for (int i = 0; i < moves.Count; i++)
            {
                log += moves[i][1] + ",";
                if ((int)moves[i][1] < bestScore)
                {
                    bestScore = (int)moves[i][1];
                    bestMove = i;
                }
            }
            Debug.Log(log + "]");
        }

        Debug.Log("Choise : " + moves[bestMove][0]);
        return (int)moves[bestMove][0];
    }

    public static List<int> availSpot(List<string> tab)
    {
        List<int> spots = new List<int>();
        for (int i =0; i<tab.Count;i++)
        {
            if (tab[i] != GameUtils.humanSign && tab[i] != GameUtils.AISign)
                spots.Add(i);
        }
        Debug.Log("Spots possible :");
        foreach (var item in spots)
            Debug.Log(item.ToString() + " ");
        return spots;
    }
}
