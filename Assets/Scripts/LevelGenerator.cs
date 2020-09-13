﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    int[,] levelMap =
        {
            {1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 7},
            {2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 4},
            {2, 5, 3, 4, 4, 3, 5, 3, 4, 4, 4, 3, 5, 4},
            {2, 6, 4, 0, 0, 4, 5, 4, 0, 0, 0, 4, 5, 4},
            {2, 5, 3, 4, 4, 3, 5, 3, 4, 4, 4, 3, 5, 3},
            {2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5},
            {2, 5, 3, 4, 4, 3, 5, 3, 3, 5, 3, 4, 4, 4},
            {2, 5, 3, 4, 4, 3, 5, 4, 4, 5, 3, 4, 4, 3},
            {2, 5, 5, 5, 5, 5, 5, 4, 4, 5, 5, 5, 5, 4},
            {1, 2, 2, 2, 2, 1, 5, 4, 3, 4, 4, 3, 0, 4},
            {0, 0, 0, 0, 0, 2, 5, 4, 3, 4, 4, 3, 0, 3},
            {0, 0, 0, 0, 0, 2, 5, 4, 4, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 2, 5, 4, 4, 0, 3, 4, 4, 0},
            {2, 2, 2, 2, 2, 1, 5, 3, 3, 0, 4, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 4, 0, 0, 0}
        };

    // Key:
    // 0 - Blank space
    // 1 - Outer Corner
    // 2 - Outer Wall
    // 3 - Inside Corner
    // 4 - Inside Wall
    // 5 - Standard Pellet
    // 6 - Power Pellet
    // 7 - Outside Junction
     
    public GameObject levelMap1;
    public GameObject levelMap2;
    public GameObject levelMap3;
    public GameObject levelMap4;
    public GameObject levelMap5;
    public GameObject levelMap6; //PLACEHOLDER! Replace Bonus Pellet with Power Pellet once confirmed functional
    public GameObject levelMap7;


    // Start is called before the first frame update
    void Start()
    {
        for (int yLoop = 0; yLoop < 15; yLoop++) 
        {
            for (int xLoop = 0; xLoop < 14; xLoop++) 
            {
                int mapElement = levelMap[yLoop, xLoop];
                spawnMapElement(mapElement, xLoop, yLoop);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Spawns a specified map element, in all four quadrants
    void spawnMapElement(int mapElement, int xLoop, int yLoop) 
    {
        Vector3 q2pos = new Vector3(-15 + xLoop, 14 - yLoop, 0);
        Quaternion q2rot = new Quaternion(0,0,0,0);

        switch (mapElement)
        {
            case 0:
                break;

            case 1:
                Debug.Log("Corner tile");
                spawnOuterCorner(xLoop, yLoop);
                break;

            case 2:
                Debug.Log("Outer wall");
                Instantiate(levelMap2, new Vector3(-15 + xLoop, 14 - yLoop, 0), Quaternion.Euler(0, 0, 0));
                break;

            case 3:
                Instantiate(levelMap3, new Vector3(-15 + xLoop, 14 - yLoop, 0), Quaternion.Euler(0, 0, 0));
                break;

            case 4:
                Instantiate(levelMap4, new Vector3(-15 + xLoop, 14 - yLoop, 0), Quaternion.Euler(0, 0, 0));
                break;

            case 5:
                Instantiate(levelMap5, new Vector3(-15 + xLoop, 14 - yLoop, 0), Quaternion.Euler(0, 0, 0));
                break;

            case 6:
                Instantiate(levelMap6, new Vector3(-15 + xLoop, 14 - yLoop, 0), Quaternion.Euler(0, 0, 0));
                break;

            case 7:
                Instantiate(levelMap7, new Vector3(-15 + xLoop, 14 - yLoop, 0), Quaternion.Euler(0, 0, 0));
                break;

            default:
                break;
        }

            //don't mirror yet just get it working

    }

    void spawnOuterCorner(int xLoop, int yLoop) 
    {
        // I'm sure there are better approaches? A try-catch on OutOfBounds just moves the edge-case solving, without removing it

        if (xLoop == 0 && yLoop == 0)
        {
            Instantiate(levelMap1, new Vector3(-15 + xLoop, 14 - yLoop, 0), Quaternion.Euler(0, 0, 0));
        }

        else if (xLoop == 0 && yLoop < 14)
        {
            if (levelMap[yLoop - 1, xLoop] == 1 || levelMap[yLoop - 1, xLoop] == 2)
            {
                Instantiate(levelMap1, new Vector3(-15 + xLoop, 14 - yLoop, 0), Quaternion.Euler(0, 0, 90));
            }
            else
            {
                Instantiate(levelMap1, new Vector3(-15 + xLoop, 14 - yLoop, 0), Quaternion.Euler(0, 0, 0));
            }
        }

        else if (xLoop == 0 && yLoop == 14)
        {
            Instantiate(levelMap1, new Vector3(-15 + xLoop, 14 - yLoop, 0), Quaternion.Euler(0, 0, 90));
        }

        else if (yLoop == 0 && xLoop < 13)
        {
            if (levelMap[yLoop, xLoop - 1] == 1 || levelMap[yLoop, xLoop - 1] == 2)
            {
                Instantiate(levelMap1, new Vector3(-15 + xLoop, 14 - yLoop, 0), Quaternion.Euler(0, 0, 270));
            }
            else
            {
                Instantiate(levelMap1, new Vector3(-15 + xLoop, 14 - yLoop, 0), Quaternion.Euler(0, 0, 0));
            }
        }

        else if (yLoop == 0 && xLoop == 13)
        {
            Instantiate(levelMap1, new Vector3(-15 + xLoop, 14 - yLoop, 0), Quaternion.Euler(0, 0, 270));
        }

        else if (yLoop < 14 && xLoop == 13)
        {
            if (levelMap[yLoop + 1, xLoop] == 1 || levelMap[yLoop + 1, xLoop] == 2)
            {
                Instantiate(levelMap1, new Vector3(-15 + xLoop, 14 - yLoop, 0), Quaternion.Euler(0, 0, 270));
            }
            else
            {
                Instantiate(levelMap1, new Vector3(-15 + xLoop, 14 - yLoop, 0), Quaternion.Euler(0, 0, 180));
            }
        }

        else if (yLoop == 14 && xLoop == 13)
        {
            Instantiate(levelMap1, new Vector3(-15 + xLoop, 14 - yLoop, 0), Quaternion.Euler(0, 0, 180));
        }

        else if (yLoop == 14 && xLoop < 13) 
        {
            if (levelMap[yLoop, xLoop - 1] == 1 || levelMap[yLoop, xLoop - 1] == 2)
            {
                Instantiate(levelMap1, new Vector3(-15 + xLoop, 14 - yLoop, 0), Quaternion.Euler(0, 0, 180));
            }
            else 
            {
                Instantiate(levelMap1, new Vector3(-15 + xLoop, 14 - yLoop, 0), Quaternion.Euler(0, 0, 90));
            }
        }

        else if (xLoop > 0 && xLoop < 13 && yLoop > 0 && yLoop < 14)
        {
            if ((levelMap[yLoop, xLoop + 1] == 1 || levelMap[yLoop, xLoop + 1] == 2) && (levelMap[yLoop + 1, xLoop] == 1 || levelMap[yLoop + 1, xLoop] == 2))
            {
                Instantiate(levelMap1, new Vector3(-15 + xLoop, 14 - yLoop, 0), Quaternion.Euler(0, 0, 0));
            }
            else if ((levelMap[yLoop + 1, xLoop] == 1 || levelMap[yLoop + 1, xLoop] == 2) && (levelMap[yLoop, xLoop - 1] == 1 || levelMap[yLoop, xLoop - 1] == 2))
            {
                Instantiate(levelMap1, new Vector3(-15 + xLoop, 14 - yLoop, 0), Quaternion.Euler(0, 0, 270));
            }
            else if ((levelMap[yLoop, xLoop - 1] == 1 || levelMap[yLoop, xLoop - 1] == 2) && (levelMap[yLoop - 1, xLoop] == 1 || levelMap[yLoop - 1, xLoop] == 2))
            {
                Instantiate(levelMap1, new Vector3(-15 + xLoop, 14 - yLoop, 0), Quaternion.Euler(0, 0, 180));
            }
            else
            {
                Instantiate(levelMap1, new Vector3(-15 + xLoop, 14 - yLoop, 0), Quaternion.Euler(0, 0, 90));
            }
        }

    }
}