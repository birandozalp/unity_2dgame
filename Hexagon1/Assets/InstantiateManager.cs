using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateManager : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject newHexa;
    public GameObject newBomb;
    public int gridWidth;
    public int gridHeight;
    public Color color1;
    public Color color2;
    public Color color3;
    public Color color4;
    public Color color5;

    public int topYCord;
    public int topXCord;
    public int cnt;
    public static bool shouldBeBomb = false;

    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
         topYCord= gridHeight * 2 - 1;
         topXCord = gridWidth - 1;
         cnt = 0;

        // Instantiate at position (0, 0, 0) and zero rotation.

        for (float count1 = 0; count1 < gridHeight; count1 = count1 + 0.5f)
        {
            if (count1 % 1 == 0)
            {
                for (float count2 = 0; count2 < gridWidth; count2++)
                {
                    
                    newHexa.gameObject.name = count1*2 + "," + count2;
                    GameObject currentHexa = Instantiate(newHexa, new Vector3(count2 * 2, count1, 1), Quaternion.identity) as GameObject;
                    //currentHexa.name = count1 * 2 + "," + count2;
                    int rnd = Random.Range(1, 6);
                    switch(rnd)
                    {
                        case 1:
                            currentHexa.GetComponent<SpriteRenderer>().color = color1;
                            break;
                        case 2:
                            currentHexa.GetComponent<SpriteRenderer>().color = color2;
                            break;
                        case 3:
                            currentHexa.GetComponent<SpriteRenderer>().color = color3;
                            break;
                        case 4:
                            currentHexa.GetComponent<SpriteRenderer>().color = color4;
                            break;
                        case 5:
                            currentHexa.GetComponent<SpriteRenderer>().color = color5;
                            break;
                    }
                }
            }

            else
            {
                for (float count2 = 0; count2 < gridWidth; count2++)
                {
                    newHexa.gameObject.name = count1*2 + "," + count2;
                    GameObject currentHexa = Instantiate(newHexa, new Vector3((count2*2)+1, count1, 1), Quaternion.identity) as GameObject;
                    int rnd = Random.Range(1, 6);
                    switch (rnd)
                    {
                        case 1:
                            currentHexa.GetComponent<SpriteRenderer>().color = color1;
                            break;
                        case 2:
                            currentHexa.GetComponent<SpriteRenderer>().color = color2;
                            break;
                        case 3:
                            currentHexa.GetComponent<SpriteRenderer>().color = color3;
                            break;
                        case 4:
                            currentHexa.GetComponent<SpriteRenderer>().color = color4;
                            break;
                        case 5:
                            currentHexa.GetComponent<SpriteRenderer>().color = color5;
                            break;
                    }
                }
            }
        }
        
    }

    void Update()
    {


        for (int count = 0; count <= topXCord; count++)
        {
            if (GameObject.Find("16," + count + "(Clone)") == null)
            {
                if (shouldBeBomb == false)
                {
                    GameObject currentHexa = Instantiate(newHexa, new Vector3(count * 2, 8, 1), Quaternion.identity);
                    currentHexa.name = "16," + count + "(Clone)";

                    int rnd = Random.Range(1, 6);
                    switch (rnd)
                    {
                        case 1:
                            currentHexa.GetComponent<SpriteRenderer>().color = color1;
                            break;
                        case 2:
                            currentHexa.GetComponent<SpriteRenderer>().color = color2;
                            break;
                        case 3:
                            currentHexa.GetComponent<SpriteRenderer>().color = color3;
                            break;
                        case 4:
                            currentHexa.GetComponent<SpriteRenderer>().color = color4;
                            break;
                        case 5:
                            currentHexa.GetComponent<SpriteRenderer>().color = color5;
                            break;
                    }
                }

                else
                {

                    GameObject currentHexa = Instantiate(newBomb, new Vector3(count * 2, 8, 1), Quaternion.identity);
                    currentHexa.name = "16," + count + "(Clone)";

                    int rnd = Random.Range(1, 6);
                    switch (rnd)
                    {
                        case 1:
                            currentHexa.GetComponent<SpriteRenderer>().color = color1;
                            break;
                        case 2:
                            currentHexa.GetComponent<SpriteRenderer>().color = color2;
                            break;
                        case 3:
                            currentHexa.GetComponent<SpriteRenderer>().color = color3;
                            break;
                        case 4:
                            currentHexa.GetComponent<SpriteRenderer>().color = color4;
                            break;
                        case 5:
                            currentHexa.GetComponent<SpriteRenderer>().color = color5;
                            break;
                    }
                    shouldBeBomb = false;

                }

            }

            else if (GameObject.Find("17," + count + "(Clone)") == null)
            {
                if (shouldBeBomb == false)
                {

                    GameObject currentHexa = Instantiate(newHexa, new Vector3(((count * 2) + 1), 8.5f, 1), Quaternion.identity);
                    currentHexa.name = "17," + count + "(Clone)";

                    int rnd = Random.Range(1, 6);
                    switch (rnd)
                    {
                        case 1:
                            currentHexa.GetComponent<SpriteRenderer>().color = color1;
                            break;
                        case 2:
                            currentHexa.GetComponent<SpriteRenderer>().color = color2;
                            break;
                        case 3:
                            currentHexa.GetComponent<SpriteRenderer>().color = color3;
                            break;
                        case 4:
                            currentHexa.GetComponent<SpriteRenderer>().color = color4;
                            break;
                        case 5:
                            currentHexa.GetComponent<SpriteRenderer>().color = color5;
                            break;
                    }
                }


                else
                {
                    GameObject currentHexa = Instantiate(newBomb, new Vector3(((count * 2) + 1), 8.5f, 1), Quaternion.identity);
                    currentHexa.name = "17," + count + "(Clone)";

                    int rnd = Random.Range(1, 6);
                    switch (rnd)
                    {
                        case 1:
                            currentHexa.GetComponent<SpriteRenderer>().color = color1;
                            break;
                        case 2:
                            currentHexa.GetComponent<SpriteRenderer>().color = color2;
                            break;
                        case 3:
                            currentHexa.GetComponent<SpriteRenderer>().color = color3;
                            break;
                        case 4:
                            currentHexa.GetComponent<SpriteRenderer>().color = color4;
                            break;
                        case 5:
                            currentHexa.GetComponent<SpriteRenderer>().color = color5;
                            break;
                    }
                    shouldBeBomb = false;
                }
            }
        }

        
    }
}
