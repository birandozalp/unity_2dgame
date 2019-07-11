using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HexagonController : MonoBehaviour
{
    public static int score;

    GameObject neighborGO1;
    GameObject neighborGO2;
    GameObject neighborGO3;
    GameObject neighborGO4;
    GameObject neighborGO5;
    GameObject neighborGO6;
    void Update()
    {
            checkMatches();
            dropDown();    
    }

    public void updateScore()
    {
        score += 20;
        if(score%1000==0)
        {
            InstantiateManager.shouldBeBomb = true;
        }
    }
    public void dropDown()
    {
        string myName = gameObject.name;
        int yCord = Convert.ToInt32(myName.Split(',')[0]);
        int xCord = Convert.ToInt32(myName.Split(',')[1].Split('(')[0]);
        int count = 0;
        while (GameObject.Find((yCord - 2) + "," + xCord + "(Clone)") == null && gameObject.transform.position.y>=1 && count<20)
        {
            yCord -= 2;
            Vector3 tempPos = gameObject.transform.position;
            tempPos.y += -1f;
            gameObject.transform.position = tempPos;
            gameObject.name = yCord + "," + xCord + "(Clone)";
            count++;
        }

    }

    public void cleanSelection()
    {
        if(ClickManager.tempGO1!=null)
            ClickManager.tempGO1.GetComponent<SpriteRenderer>().sprite = ClickManager.unsHexa.GetComponent<SpriteRenderer>().sprite;
        if (ClickManager.tempGO2 != null)
            ClickManager.tempGO2.GetComponent<SpriteRenderer>().sprite = ClickManager.unsHexa.GetComponent<SpriteRenderer>().sprite;
        if (ClickManager.tempGO3 != null)
            ClickManager.tempGO3.GetComponent<SpriteRenderer>().sprite = ClickManager.unsHexa.GetComponent<SpriteRenderer>().sprite;
    }

    public void checkMatches()
    {

        Color myColor = gameObject.GetComponent<SpriteRenderer>().color;
        string myName = gameObject.name;
        int yCord = Convert.ToInt32(myName.Split(',')[0]);
        int xCord = Convert.ToInt32(myName.Split(',')[1].Split('(')[0]);
        if (yCord % 2 == 0)
        {
            neighborGO1 = GameObject.Find((yCord - 2) + "," + xCord + "(Clone)");  //DOWN
            neighborGO2 = GameObject.Find((yCord - 1) + "," + (xCord - 1) + "(Clone)");  //LEFT-DOWN
            neighborGO3 = GameObject.Find((yCord + 1) + "," + (xCord - 1) + "(Clone)");  //LEFT-UP
            neighborGO4 = GameObject.Find((yCord + 2) + "," + xCord + "(Clone)"); //UP
            neighborGO5 = GameObject.Find((yCord + 1) + "," + (xCord) + "(Clone)");    //RIGHT-UP
            neighborGO6 = GameObject.Find((yCord - 1) + "," + (xCord) + "(Clone)");  //RIGHT-DOWN
        }
        else
        {
            neighborGO1 = GameObject.Find((yCord - 2) + "," + xCord + "(Clone)");  //DOWN
            neighborGO2 = GameObject.Find((yCord - 1) + "," + xCord + "(Clone)");  //LEFT-DOWN
            neighborGO3 = GameObject.Find((yCord + 1) + "," + xCord + "(Clone)");  //LEFT-UP
            neighborGO4 = GameObject.Find((yCord + 2) + "," + xCord + "(Clone)"); //UP
            neighborGO5 = GameObject.Find((yCord + 1) + "," + (xCord + 1) + "(Clone)");    //RIGHT-UP
            neighborGO6 = GameObject.Find((yCord - 1) + "," + (xCord + 1) + "(Clone)");  //RIGHT-DOWN
        }

        if (neighborGO1!=null && neighborGO2!= null && myColor == neighborGO1.GetComponent<SpriteRenderer>().color && myColor == neighborGO2.GetComponent<SpriteRenderer>().color)
        {
            Destroy(gameObject);
            Destroy(neighborGO1);
            Destroy(neighborGO2);
            updateScore();
            cleanSelection();
        }

        else if (neighborGO2 != null && neighborGO3 != null && myColor == neighborGO2.GetComponent<SpriteRenderer>().color && myColor == neighborGO3.GetComponent<SpriteRenderer>().color)
        {
            Destroy(gameObject);
            Destroy(neighborGO2);
            Destroy(neighborGO3);
            updateScore();
            cleanSelection();
        }

        else if (neighborGO3 != null && neighborGO4 != null && myColor == neighborGO3.GetComponent<SpriteRenderer>().color && myColor == neighborGO4.GetComponent<SpriteRenderer>().color)
        {
            Destroy(gameObject);
            Destroy(neighborGO3);
            Destroy(neighborGO4);
            updateScore();
            cleanSelection();
        }

        else if (neighborGO4 != null && neighborGO5 != null && myColor == neighborGO4.GetComponent<SpriteRenderer>().color && myColor == neighborGO5.GetComponent<SpriteRenderer>().color)
        {
            Destroy(gameObject);
            Destroy(neighborGO4);
            Destroy(neighborGO5);
            updateScore();
            cleanSelection();
        }

        else if (neighborGO5 != null && neighborGO6 != null && myColor == neighborGO5.GetComponent<SpriteRenderer>().color && myColor == neighborGO6.GetComponent<SpriteRenderer>().color)
        {
           

            Destroy(gameObject);
            Destroy(neighborGO5);
            Destroy(neighborGO6);
            updateScore();
            cleanSelection();
        }

        else if (neighborGO6 != null && neighborGO1 != null && myColor == neighborGO6.GetComponent<SpriteRenderer>().color && myColor == neighborGO1.GetComponent<SpriteRenderer>().color)
        {
            Destroy(gameObject);
            Destroy(neighborGO6);
            Destroy(neighborGO1);
            updateScore();
            cleanSelection();
        }


    }
}
