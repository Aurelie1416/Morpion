using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AI {

    List<int> choice = new List<int>();
    string[] TabAI = new string[9];

    public int BestPosition()
    {
        //Récuperation du tableau
        string[] source = GameObject.Find("GameManager").GetComponent<GameManagerScript>().Tab;
        Array.Copy(source, TabAI, source.Length);

        choice.Clear();
        for (int i = 0; i < TabAI.Length; i++)
        {
            if (TabAI[i] == string.Empty) choice.Add(i);
        }

        //Y a t-il un coup gagnant ?

        for(int i=0; i<TabAI.Length; i++)
        {
            if(TabAI[i]==String.Empty)
            {
                TabAI[i] = "O";
                if(isWinner("O"))
                {
                    Debug.Log("Coup Gagnant");
                    return i;
                }
                TabAI[i] = string.Empty;
            }
        }

        // Y a t-il un coup gagnant pour l'adverssaire

        for( int i =0; i<TabAI.Length; i++)
        {
            if(TabAI[i]==String.Empty)
            {
                TabAI[i] = "X";
                if(isWinner("X"))
                {
                    Debug.Log("Coup Gagnant pour l'adverssaire");
                    return i;
                }
                TabAI[i] = string.Empty;
            }
        }


        //Aléatoire
        return choice[UnityEngine.Random.Range(0, choice.Count)];


    }

    bool isWinner(string p)
    {
        if ( TabAI[0] == p && TabAI[1] == p && TabAI[2] == p ||
             TabAI[3] == p && TabAI[4] == p && TabAI[5] == p ||
             TabAI[6] == p && TabAI[7] == p && TabAI[8] == p ||
             TabAI[0] == p && TabAI[3] == p && TabAI[6] == p ||
             TabAI[1] == p && TabAI[4] == p && TabAI[7] == p ||
             TabAI[2] == p && TabAI[5] == p && TabAI[8] == p ||
             TabAI[0] == p && TabAI[4] == p && TabAI[8] == p ||
             TabAI[2] == p && TabAI[4] == p && TabAI[6] == p)
        {
            return true;
        }
        return false;
    }
}
