using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selection : MonoBehaviour {

    GameManagerScript gm;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

    public void WriteX()
    {
        GetComponentInChildren<Text>().text = "X";
        GetComponent<Button>().interactable = false;
        gm.Tab[int.Parse(gameObject.name)] = "X";

        if(gm.isWinner("X"))
        {
            Debug.Log("X a gagné...");
            gm.panel.SetActive(true);
        }
        else if(gm.ArrayIsFull())
        {
            Debug.Log("Match Nul...");
            gm.TabColorBlue();
            gm.panel.SetActive(true);
        }
        else
        {
            gm.ComputerPlay();
        }

        
    }
}
