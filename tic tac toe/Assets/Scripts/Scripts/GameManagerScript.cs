using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {

    public string[] Tab = new string[9];
    
    public GameObject panel;

    AI ai = new AI();

    private void Start()
    {
        int turn = Random.Range(0, 2);
        if (turn == 0) ComputerPlay();
        
    }

    public void ComputerPlay()
    {

        int button = ai.BestPosition();

        Button btn = GameObject.Find(button.ToString()).GetComponent<Button>();

        btn.interactable = false;

        btn.GetComponentInChildren<Text>().text = "O";

        Tab[button] = "O";

        if(isWinner("O"))
        {
            Debug.Log("O à gagné...");
            panel.SetActive(true);
            return;
        }

        if(ArrayIsFull())
        {
            Debug.Log("Match Nul...");
            panel.SetActive(true);
            TabColorBlue();
            return;
        }
    }

    public bool isWinner(string p)
    {

        //Horizontale
        if (Tab[0] == p && Tab[1] == p && Tab[2] == p)
        {
            ColorTabRed(0, 1, 2);
            return true;
        }

        if (Tab[3] == p && Tab[4] == p && Tab[5] == p)
        {
            ColorTabRed(3, 4, 5);
            return true;
        }

        if (Tab[6] == p && Tab[7] == p && Tab[8] == p)
        {
            ColorTabRed(6, 7, 8);
            return true;
        }

        //Verticale
        if (Tab[0] == p && Tab[3] == p && Tab[6] == p)
        {
            ColorTabRed(0, 3, 6);
            return true;
        }

        if (Tab[1] == p && Tab[4] == p && Tab[7] == p)
        {
            ColorTabRed(1, 4, 7);
            return true;
        }

        if (Tab[2] == p && Tab[5] == p && Tab[8] == p)
        {
            ColorTabRed(2, 5, 8);
            return true;
        }

        //Diagonale
        if (Tab[0] == p && Tab[4] == p && Tab[8] == p)
        {
            ColorTabRed(0, 4, 8);
            return true;
        }

        if (Tab[2] == p && Tab[4] == p && Tab[6] == p)
        {
            ColorTabRed(2, 4, 6);
            return true;
        }
       

        return false;
            
    }

    public bool ArrayIsFull()
    {
        for (int i=0; i<Tab.Length; i++)
        {
            if (Tab[i] == string.Empty) return false;
        }

        return true;
    }

    void ColorTabRed(int c1, int c2, int c3)
    {
        GameObject.Find(c1.ToString()).GetComponent<Button>().GetComponent<Image>().color = Color.red;
        GameObject.Find(c2.ToString()).GetComponent<Button>().GetComponent<Image>().color = Color.red;
        GameObject.Find(c3.ToString()).GetComponent<Button>().GetComponent<Image>().color = Color.red;
    }

    public void TabColorBlue()
    {
        for(int i=0; i<Tab.Length; i++)
        {
            GameObject.Find(i.ToString()).GetComponent<Button>().GetComponent<Image>().color = Color.blue;
        }
    }
}
