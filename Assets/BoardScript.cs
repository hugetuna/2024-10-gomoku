using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardScript : MonoBehaviour
{
    //setup
    public GameObject cell;
    public logicScript logic;
    public int numOfCell = 15;
    public float startX=-4.57f, startY=4.419f;
    public float Xgap=0.662f,Ygap=0.608f;


    private GameObject[,] gridCells;
    // Start is called before the first frame update
    void Start()
    {
        gridCells = new GameObject[numOfCell, numOfCell];
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<logicScript>();
        GenerateBoard();
    }

    void GenerateBoard()
    {
        int i, j;
        
        for(i=0;i< numOfCell; i++)
        {
            for (j = 0; j < numOfCell; j++)
            {
                //generate by position
                Vector3 cellPosition = new Vector3(startX+Xgap*i, startY-Ygap*j, 0);
                GameObject newCell=Instantiate(cell, cellPosition, transform.rotation);
                //naming
                newCell.name = $"Cell_{i}_{j}";
                //spot it
                newCell.GetComponent<cellScript>().xSpot = i;
                newCell.GetComponent<cellScript>().ySpot = j;
                gridCells[i, j] = newCell;
            }
        }
    }
    public int checkWinner(int x,int y,int player)//1=black,2=white
    {
        if (checkDirection(x, y, 1, 0)|| checkDirection(x, y, 1, 1)|| checkDirection(x, y, 0, 1)|| checkDirection(x, y, -1, 1))
        {
            return player;
        }
        else
        {
            return 0;
        }
    }
    private bool checkDirection(int startX,int startY,int directionX,int directionY)
    {
        int i;
        int checkCount=1;
        int checkingFlag = gridCells[startX, startY].GetComponent<cellScript>().flag;
        int pathFlag;
        for (i = 1; i < 5; i++)//正方向
        {
            if(startX + directionX * i <= 14 && startY + directionY * i <= 14&& startX + directionX * i>=0&& startY + directionY * i >= 0)
            {
                pathFlag = gridCells[startX + directionX * i, startY + directionY * i].GetComponent<cellScript>().flag;
                if (checkingFlag == pathFlag)
                {
                    checkCount++;
                }
                else
                {
                    break;
                }
            }
            else
            {
                break;
            }
        }
        for (i = 1; i < 5; i++)//反方向
        {
            if (startX - directionX * i <= 14 && startY - directionY * i <= 14 && startX - directionX * i >= 0 && startY - directionY * i >= 0)
            {
                pathFlag = gridCells[startX - directionX * i, startY - directionY * i].GetComponent<cellScript>().flag;
                if (checkingFlag == pathFlag)
                {
                    checkCount++;
                }
                else
                {
                    break;
                }
            }
            else
            {
                break;
            }
        }
        if (checkCount >= 5)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }
}
