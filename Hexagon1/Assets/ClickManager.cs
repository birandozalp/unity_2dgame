using UnityEngine;
using System.Collections;
using System;


public class ClickManager : MonoBehaviour {

    public static int turnCounter;
    public static GameObject tempGO1;
    public static GameObject tempGO2;
    public static GameObject tempGO3;
    public GameObject button;
    public GameObject selectedHexagon;
    public GameObject unselectedHexagon;
    public GameObject selectedBomb;
    public GameObject unselectedBomb;
    public static GameObject unsHexa;
    public static GameObject unsBomb;
    string tempGO1Name;
    string tempGO2Name;
    string tempGO3Name;

    Vector3 mousePos;
    Vector2 mousePos2D;

    RaycastHit2D hit;
    void Update() {
        if (Input.GetMouseButtonDown(0)) {

            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos2D = new Vector2(mousePos.x, mousePos.y);
            hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            chooseHexagons();
            moveHexagons();
        }
    }

    private void Start()
    {
        GameObject RightButton = Instantiate(button, new Vector3(7, -3, 2), Quaternion.identity) as GameObject;
        unsHexa = unselectedHexagon;
        unsBomb = unselectedBomb;
       
    }

    public void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 60;
        GUI.Label(new Rect(20, 20, 200, 200), HexagonController.score.ToString(), style);
    }

    void moveHexagons()
    {
        if (hit.collider != null)
        {
            if (tempGO2 != null && tempGO3 != null && tempGO1 != null && hit.collider.gameObject.name=="Button(Clone)")
            {

                Vector3 tempPos1 = tempGO1.transform.position;
                tempPos1.x += -1f;
                tempPos1.y += 0.5f;
                tempGO1.transform.position = tempPos1;

                Vector3 tempPos2 = tempGO2.transform.position;
                tempPos2.x += 1f;
                tempPos2.y += 0.5f;
                tempGO2.transform.position = tempPos2;

                Vector3 tempPos3 = tempGO3.transform.position;
                tempPos3.y += -1f;
                tempGO3.transform.position = tempPos3;

                string holder1 = tempGO1.name;
                string holder2 = tempGO2.name;
                string holder3 = tempGO3.name;
                tempGO1.name = holder2;
                tempGO2.name = holder3;
                tempGO3.name = holder1;

                tempGO1 = GameObject.Find(holder1);
                tempGO2 = GameObject.Find(holder2);
                tempGO3 = GameObject.Find(holder3);

                turnCounter++;
            }
        }

       
    }

    void chooseHexagons()
    {

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.name != "Button(Clone)")
            {
                if (tempGO1 != null)
                {
                    tempGO1.GetComponent<SpriteRenderer>().sprite = unselectedHexagon.GetComponent<SpriteRenderer>().sprite;
                    if (tempGO1.tag == "bomb")
                    { tempGO1.GetComponent<SpriteRenderer>().sprite = unselectedBomb.GetComponent<SpriteRenderer>().sprite; }
                }
                if (tempGO2 != null)
                {
                    tempGO2.GetComponent<SpriteRenderer>().sprite = unselectedHexagon.GetComponent<SpriteRenderer>().sprite;
                    if (tempGO2.tag == "bomb")
                    { tempGO2.GetComponent<SpriteRenderer>().sprite = unselectedBomb.GetComponent<SpriteRenderer>().sprite; }
                }
                if (tempGO3 != null)
                {
                    tempGO3.GetComponent<SpriteRenderer>().sprite = unselectedHexagon.GetComponent<SpriteRenderer>().sprite;
                    if (tempGO3.tag == "bomb")
                    { tempGO3.GetComponent<SpriteRenderer>().sprite = unselectedBomb.GetComponent<SpriteRenderer>().sprite; }
                }

                tempGO1 = hit.collider.gameObject;
                tempGO1Name = tempGO1.name;
                string[] tempName = tempGO1.name.Split(',');
                int y = Convert.ToInt32(tempName[0]);
                tempName[1] = tempName[1].Substring(0, 1);
                int x = Convert.ToInt32(tempName[1]);


                if (y % 2 == 0)
                {
                    tempGO3Name = (y + 2).ToString() + "," + (x).ToString() + "(Clone)";
                    tempGO3 = GameObject.Find(tempGO3Name);
                    tempGO2Name = (y + 1).ToString() + "," + (x - 1).ToString() + "(Clone)";
                    tempGO2 = GameObject.Find(tempGO2Name);
                }

                else if (y % 2 == 1)
                {
                    tempGO2Name = (y + 1).ToString() + "," + (x).ToString() + "(Clone)";
                    tempGO2 = GameObject.Find(tempGO2Name);
                    tempGO3Name = (y + 2).ToString() + "," + (x).ToString() + "(Clone)";
                    tempGO3 = GameObject.Find(tempGO3Name);
                }


                if(tempGO1!=null && tempGO2!=null && tempGO3!=null)
                {
                    
                    tempGO1.GetComponent<SpriteRenderer>().sprite = selectedHexagon.GetComponent<SpriteRenderer>().sprite;
                    tempGO2.GetComponent<SpriteRenderer>().sprite = selectedHexagon.GetComponent<SpriteRenderer>().sprite;
                    tempGO3.GetComponent<SpriteRenderer>().sprite = selectedHexagon.GetComponent<SpriteRenderer>().sprite;

                    if (tempGO1.tag == "bomb")
                    { tempGO1.GetComponent<SpriteRenderer>().sprite = selectedBomb.GetComponent<SpriteRenderer>().sprite; }
                    if (tempGO2.tag == "bomb")
                    { tempGO2.GetComponent<SpriteRenderer>().sprite = selectedBomb.GetComponent<SpriteRenderer>().sprite; }
                    if (tempGO3.tag == "bomb")
                    { tempGO3.GetComponent<SpriteRenderer>().sprite = selectedBomb.GetComponent<SpriteRenderer>().sprite; }
                }

            }


        }

    }
        
    }