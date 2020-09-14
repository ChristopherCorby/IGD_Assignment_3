using System.Collections;
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
                makeOuterCorner(xLoop, yLoop);
                break;

            case 2:
                makeOuterWall(xLoop, yLoop);
                break;

            case 3:
                makeInnerCorner(xLoop, yLoop);
                break;

            case 4:
                makeInnerWall(xLoop, yLoop);
                break;

            case 5:
                spawnPellet(xLoop, yLoop);
                break;

            case 6:
                spawnPowerPellet(xLoop, yLoop);
                break;

            case 7:
                spawnJunction(xLoop, yLoop);
                break;

            default:
                break;
        }
    }

    void makeOuterCorner(int xLoop, int yLoop) 
    {
        // I'm sure there are better approaches? A try-catch on OutOfBounds just moves the edge-case solving, without removing it
        // Could rewrite to have one big, convoluted 'If' for each form, but my instinct is that those would get big and ugly

        if (xLoop == 0 && yLoop == 0)
        {
            spawnOuterCorner(xLoop, yLoop, 1);
        }

        else if (xLoop == 0 && yLoop < 14)
        {
            if (levelMap[yLoop - 1, xLoop] == 1 || levelMap[yLoop - 1, xLoop] == 2)
            {
                spawnOuterCorner(xLoop, yLoop, 4);
            }
            else
            {
                spawnOuterCorner(xLoop, yLoop, 1);
            }
        }

        else if (xLoop == 0 && yLoop == 14)
        {
            spawnOuterCorner(xLoop, yLoop, 4);
        }

        else if (yLoop == 0 && xLoop < 13)
        {
            if (levelMap[yLoop, xLoop - 1] == 1 || levelMap[yLoop, xLoop - 1] == 2)
            {
                spawnOuterCorner(xLoop, yLoop, 2);
            }
            else
            {
                spawnOuterCorner(xLoop, yLoop, 1);
            }
        }

        else if (yLoop == 0 && xLoop == 13)
        {
            spawnOuterCorner(xLoop, yLoop, 2);
        }

        else if (yLoop < 14 && xLoop == 13)
        {
            if (levelMap[yLoop + 1, xLoop] == 1 || levelMap[yLoop + 1, xLoop] == 2)
            {
                spawnOuterCorner(xLoop, yLoop, 2);
            }
            else
            {
                spawnOuterCorner(xLoop, yLoop, 3);
            }
        }

        else if (yLoop == 14 && xLoop == 13)
        {
            spawnOuterCorner(xLoop, yLoop, 3);
        }

        else if (yLoop == 14 && xLoop < 13) 
        {
            if (levelMap[yLoop, xLoop - 1] == 1 || levelMap[yLoop, xLoop - 1] == 2)
            {
                spawnOuterCorner(xLoop, yLoop, 3);
            }
            else 
            {
                spawnOuterCorner(xLoop, yLoop, 4);
            }
        }

        else if (xLoop > 0 && xLoop < 13 && yLoop > 0 && yLoop < 14)
        {
            if ((levelMap[yLoop, xLoop + 1] == 1 || levelMap[yLoop, xLoop + 1] == 2) && (levelMap[yLoop + 1, xLoop] == 1 || levelMap[yLoop + 1, xLoop] == 2))
            {
                spawnOuterCorner(xLoop, yLoop, 1);
            }
            else if ((levelMap[yLoop + 1, xLoop] == 1 || levelMap[yLoop + 1, xLoop] == 2) && (levelMap[yLoop, xLoop - 1] == 1 || levelMap[yLoop, xLoop - 1] == 2))
            {
                spawnOuterCorner(xLoop, yLoop, 2);
            }
            else if ((levelMap[yLoop, xLoop - 1] == 1 || levelMap[yLoop, xLoop - 1] == 2) && (levelMap[yLoop - 1, xLoop] == 1 || levelMap[yLoop - 1, xLoop] == 2))
            {
                spawnOuterCorner(xLoop, yLoop, 3);
            }
            else
            {
                spawnOuterCorner(xLoop, yLoop, 4);
            }
        }

    }

    void spawnOuterCorner(int xLoop, int yLoop, int form) 
    {
        Vector3 q1pos = new Vector3(13.5f - xLoop, 14 - yLoop, 0);     // top right / horizontal mirror
        Vector3 q2pos = new Vector3(-13.5f + xLoop, 14 - yLoop, 0);    // top left / no change
        Vector3 q3pos = new Vector3(-13.5f + xLoop, -14 + yLoop, 0);   // bottom left / vertical mirror
        Vector3 q4pos = new Vector3(13.5f - xLoop, -14 + yLoop, 0);    // bottom right / horizontal+vertical mirror

        switch (form) 
        {
            case 1:
                Instantiate(levelMap1, q1pos, Quaternion.Euler(0, 0, 270));
                Instantiate(levelMap1, q2pos, Quaternion.Euler(0, 0, 0));
                Instantiate(levelMap1, q3pos, Quaternion.Euler(0, 0, 90));
                Instantiate(levelMap1, q4pos, Quaternion.Euler(0, 0, 180));
                break;

            case 2:
                Instantiate(levelMap1, q1pos, Quaternion.Euler(0, 0, 0));
                Instantiate(levelMap1, q2pos, Quaternion.Euler(0, 0, 270));
                Instantiate(levelMap1, q3pos, Quaternion.Euler(0, 0, 180));
                Instantiate(levelMap1, q4pos, Quaternion.Euler(0, 0, 90)); 
                break;

            case 3:
                Instantiate(levelMap1, q1pos, Quaternion.Euler(0, 0, 90));
                Instantiate(levelMap1, q2pos, Quaternion.Euler(0, 0, 180));
                Instantiate(levelMap1, q3pos, Quaternion.Euler(0, 0, 270));
                Instantiate(levelMap1, q4pos, Quaternion.Euler(0, 0, 0));                
                break;

            case 4:
                Instantiate(levelMap1, q1pos, Quaternion.Euler(0, 0, 180));
                Instantiate(levelMap1, q2pos, Quaternion.Euler(0, 0, 90));
                Instantiate(levelMap1, q3pos, Quaternion.Euler(0, 0, 0));
                Instantiate(levelMap1, q4pos, Quaternion.Euler(0, 0, 270));
                break;

            default:
                break;
        }
    }

    void makeOuterWall(int xLoop, int yLoop) 
    {
        if (levelMap[yLoop, xLoop + 1] == 1 || levelMap[yLoop, xLoop + 1] == 2 || levelMap[yLoop, xLoop + 1] == 7)
        {
            spawnOuterWall(xLoop, yLoop, 2);
        }
        else 
        {
            spawnOuterWall(xLoop, yLoop, 1);
        }

    }

    void spawnOuterWall(int xLoop, int yLoop, int form)
    {
        Vector3 q1pos = new Vector3(13.5f - xLoop, 14 - yLoop, 0);     // top right / horizontal mirror
        Vector3 q2pos = new Vector3(-13.5f + xLoop, 14 - yLoop, 0);    // top left / no change
        Vector3 q3pos = new Vector3(-13.5f + xLoop, -14 + yLoop, 0);   // bottom left / vertical mirror
        Vector3 q4pos = new Vector3(13.5f - xLoop, -14 + yLoop, 0);    // bottom right / horizontal+vertical mirror

        switch (form)
        {
            case 1:
                Instantiate(levelMap2, q1pos, Quaternion.Euler(0, 0, 0));
                Instantiate(levelMap2, q2pos, Quaternion.Euler(0, 0, 0));
                Instantiate(levelMap2, q3pos, Quaternion.Euler(0, 0, 0));
                Instantiate(levelMap2, q4pos, Quaternion.Euler(0, 0, 0));
                break;

            case 2:
                Instantiate(levelMap2, q1pos, Quaternion.Euler(0, 0, 90));
                Instantiate(levelMap2, q2pos, Quaternion.Euler(0, 0, 90));
                Instantiate(levelMap2, q3pos, Quaternion.Euler(0, 0, 90));
                Instantiate(levelMap2, q4pos, Quaternion.Euler(0, 0, 90));
                break;

            default:
                break;
        }
    }

    void makeInnerCorner(int xLoop, int yLoop) 
    {
        if (levelMap[yLoop + 1, xLoop] == 3 && levelMap[yLoop, xLoop + 1] == 4 && levelMap[yLoop, xLoop - 1] == 4)
        {
            spawnInnerCorner(xLoop, yLoop, 4);
        }
        else if (levelMap[yLoop - 1, xLoop] == 3 && levelMap[yLoop, xLoop + 1] == 4 && levelMap[yLoop, xLoop - 1] == 4)
        {
            spawnInnerCorner(xLoop, yLoop, 1);
        }
        else if (levelMap[yLoop - 1, xLoop] == 4 && levelMap[yLoop + 1, xLoop] == 4 && levelMap[yLoop, xLoop - 1] == 4)
        {
            spawnInnerCorner(xLoop, yLoop, 2);
        }
        else if (levelMap[yLoop - 1, xLoop] == 3 || levelMap[yLoop - 1, xLoop] == 4)
        {
            if (levelMap[yLoop, xLoop - 1] == 3 || levelMap[yLoop, xLoop - 1] == 4)
            {
                spawnInnerCorner(xLoop, yLoop, 3);
            }
            else 
            {
                spawnInnerCorner(xLoop, yLoop, 4);
            }
        }
        else if (levelMap[yLoop, xLoop - 1] == 3 || levelMap[yLoop, xLoop - 1] == 4)
        {
            spawnInnerCorner(xLoop, yLoop, 2);
        }
        else
        {
            spawnInnerCorner(xLoop, yLoop, 1);
        }

    }

    void spawnInnerCorner(int xLoop, int yLoop, int form)
    {
        Vector3 q1pos = new Vector3(13.5f - xLoop, 14 - yLoop, 0);     // top right / horizontal mirror
        Vector3 q2pos = new Vector3(-13.5f + xLoop, 14 - yLoop, 0);    // top left / no change
        Vector3 q3pos = new Vector3(-13.5f + xLoop, -14 + yLoop, 0);   // bottom left / vertical mirror
        Vector3 q4pos = new Vector3(13.5f - xLoop, -14 + yLoop, 0);    // bottom right / horizontal+vertical mirror

        switch (form)
        {
            case 1:
                Instantiate(levelMap3, q1pos, Quaternion.Euler(0, 0, 270));
                Instantiate(levelMap3, q2pos, Quaternion.Euler(0, 0, 0));
                Instantiate(levelMap3, q3pos, Quaternion.Euler(0, 0, 90));
                Instantiate(levelMap3, q4pos, Quaternion.Euler(0, 0, 180));
                break;

            case 2:
                Instantiate(levelMap3, q1pos, Quaternion.Euler(0, 0, 0));
                Instantiate(levelMap3, q2pos, Quaternion.Euler(0, 0, 270));
                Instantiate(levelMap3, q3pos, Quaternion.Euler(0, 0, 180));
                Instantiate(levelMap3, q4pos, Quaternion.Euler(0, 0, 90));
                break;

            case 3:
                Instantiate(levelMap3, q1pos, Quaternion.Euler(0, 0, 90));
                Instantiate(levelMap3, q2pos, Quaternion.Euler(0, 0, 180));
                Instantiate(levelMap3, q3pos, Quaternion.Euler(0, 0, 270));
                Instantiate(levelMap3, q4pos, Quaternion.Euler(0, 0, 0));
                break;

            case 4:
                Instantiate(levelMap3, q1pos, Quaternion.Euler(0, 0, 180));
                Instantiate(levelMap3, q2pos, Quaternion.Euler(0, 0, 90));
                Instantiate(levelMap3, q3pos, Quaternion.Euler(0, 0, 0));
                Instantiate(levelMap3, q4pos, Quaternion.Euler(0, 0, 270));
                break;

            default:
                break;
        }
    }

    void makeInnerWall(int xLoop, int yLoop) 
    {
        if (yLoop == 0)
        {
            spawnInnerWall(xLoop, yLoop, 2);
        }
        else if (yLoop == 14)
        {
            spawnInnerWall(xLoop, yLoop, 1);
        }
        else if ((levelMap[yLoop - 1, xLoop] == 3 || levelMap[yLoop - 1, xLoop] == 4 || levelMap[yLoop - 1, xLoop] == 7) &&
            (levelMap[yLoop + 1, xLoop] == 3 || levelMap[yLoop + 1, xLoop] == 4))
        {
            spawnInnerWall(xLoop, yLoop, 1);
        }
        else if ((levelMap[yLoop - 1, xLoop] == 3 || levelMap[yLoop - 1, xLoop] == 4 || levelMap[yLoop - 1, xLoop] == 7) &&
            (levelMap[yLoop + 1, xLoop] != 3 && levelMap[yLoop + 1, xLoop] != 4))
        {
            spawnInnerWall(xLoop, yLoop, 2);
        }
        else 
        {
            spawnInnerWall(xLoop, yLoop, 2);
        }
    }

    void spawnInnerWall(int xLoop, int yLoop, int form)
    {
        Vector3 q1pos = new Vector3(13.5f - xLoop, 14 - yLoop, 0);     // top right / horizontal mirror
        Vector3 q2pos = new Vector3(-13.5f + xLoop, 14 - yLoop, 0);    // top left / no change
        Vector3 q3pos = new Vector3(-13.5f + xLoop, -14 + yLoop, 0);   // bottom left / vertical mirror
        Vector3 q4pos = new Vector3(13.5f - xLoop, -14 + yLoop, 0);    // bottom right / horizontal+vertical mirror

        switch (form)
        {
            case 1:
                Instantiate(levelMap4, q1pos, Quaternion.Euler(0, 0, 0));
                Instantiate(levelMap4, q2pos, Quaternion.Euler(0, 0, 0));
                Instantiate(levelMap4, q3pos, Quaternion.Euler(0, 0, 0));
                Instantiate(levelMap4, q4pos, Quaternion.Euler(0, 0, 0));
                break;

            case 2:
                Instantiate(levelMap4, q1pos, Quaternion.Euler(0, 0, 90));
                Instantiate(levelMap4, q2pos, Quaternion.Euler(0, 0, 90));
                Instantiate(levelMap4, q3pos, Quaternion.Euler(0, 0, 90));
                Instantiate(levelMap4, q4pos, Quaternion.Euler(0, 0, 90));
                break;

            default:
                break;
        }
    }

    void spawnPellet(int xLoop, int yLoop) 
    {
        Vector3 q1pos = new Vector3(13.5f - xLoop, 14 - yLoop, 0);     // top right / horizontal mirror
        Vector3 q2pos = new Vector3(-13.5f + xLoop, 14 - yLoop, 0);    // top left / no change
        Vector3 q3pos = new Vector3(-13.5f + xLoop, -14 + yLoop, 0);   // bottom left / vertical mirror
        Vector3 q4pos = new Vector3(13.5f - xLoop, -14 + yLoop, 0);    // bottom right / horizontal+vertical mirror

        Instantiate(levelMap5, q1pos, Quaternion.Euler(0, 0, 0));
        Instantiate(levelMap5, q2pos, Quaternion.Euler(0, 0, 0));
        if (yLoop != 14)
        {
            Instantiate(levelMap5, q3pos, Quaternion.Euler(0, 0, 0));
            Instantiate(levelMap5, q4pos, Quaternion.Euler(0, 0, 0));
        }
    }

    void spawnPowerPellet(int xLoop, int yLoop) 
    {
        Vector3 q1pos = new Vector3(13.5f - xLoop, 14 - yLoop, 0);     // top right / horizontal mirror
        Vector3 q2pos = new Vector3(-13.5f + xLoop, 14 - yLoop, 0);    // top left / no change
        Vector3 q3pos = new Vector3(-13.5f + xLoop, -14 + yLoop, 0);   // bottom left / vertical mirror
        Vector3 q4pos = new Vector3(13.5f - xLoop, -14 + yLoop, 0);    // bottom right / horizontal+vertical mirror

        Instantiate(levelMap6, q1pos, Quaternion.Euler(0, 0, 0));
        Instantiate(levelMap6, q2pos, Quaternion.Euler(0, 0, 0));
        Instantiate(levelMap6, q3pos, Quaternion.Euler(0, 0, 0));
        Instantiate(levelMap6, q4pos, Quaternion.Euler(0, 0, 0));
    }

    void spawnJunction(int xLoop, int yLoop) 
    {
        Vector3 q1pos = new Vector3(13.5f - xLoop, 14 - yLoop, 0);     // top right / horizontal mirror
        Vector3 q2pos = new Vector3(-13.5f + xLoop, 14 - yLoop, 0);    // top left / no change
        Vector3 q3pos = new Vector3(-13.5f + xLoop, -14 + yLoop, 0);   // bottom left / vertical mirror
        Vector3 q4pos = new Vector3(13.5f - xLoop, -14 + yLoop, 0);    // bottom right / horizontal+vertical mirror

        Instantiate(levelMap7, q1pos, Quaternion.Euler(0, 0, 0));
        Instantiate(levelMap7, q2pos, Quaternion.Euler(0, 0, 0));
        Instantiate(levelMap7, q3pos, Quaternion.Euler(0, 0, 180));
        Instantiate(levelMap7, q4pos, Quaternion.Euler(0, 0, 180));
    }
}
