using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class cellScript : MonoBehaviour
{
    public GameObject blackStone;
    public GameObject whiteStone;
    public logicScript logic;
    public GameObject board;
    public int flag=0;//none=0,black=1,white=2
    public int xSpot, ySpot;
    // Start is called before the first frame update
    void Start()
    {
        logic= GameObject.FindGameObjectWithTag("logic").GetComponent<logicScript>();
        board= GameObject.FindGameObjectWithTag("board");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        placingStone();
    }
    public void placingStone()//black=false,white=ture
    {
        Debug.Log("Cell clicked!");
        if (flag == 0 && logic.winner==0)
        {
            if (logic.whoIsP == false)
            {
                Instantiate(blackStone, transform.position, transform.rotation);
                flag = 1;
                logic.winner=board.GetComponent<BoardScript>().checkWinner(xSpot, ySpot, 1);
                logic.roundText.text = "¥Õ´Ñ¸¨¤l";
                logic.roundText.color = Color.white;
            }
            else
            {
                Instantiate(whiteStone, transform.position, transform.rotation);
                flag = 2;
                logic.winner = board.GetComponent<BoardScript>().checkWinner(xSpot, ySpot, 2);
                logic.roundText.text = "¶Â´Ñ¸¨¤l";
                logic.roundText.color = Color.black;
            }
            logic.whoIsP = !logic.whoIsP;
        }    
    }
}
