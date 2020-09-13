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
            {0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 4, 0, 0, 0},
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
     
    public Sprite levelMap1;
    public Sprite levelMap2;
    public Sprite levelMap3;
    public Sprite levelMap4;
    public Sprite levelMap5;
    public Sprite levelMap6; //PLACEHOLDER! Replace Bonus Pellet with Power Pellet once confirmed functional
    public Sprite levelMap7;


    // Start is called before the first frame update
    void Start()
    {
        for (int yLoop = 0; yLoop < 14; yLoop++) 
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
        Vector3 q2pos = new Vector3(15-xLoop, 14-yLoop, 0);
        Quaternion q2rot = new Quaternion(0,0,0,0);

        switch (mapElement)
        {
            case 0:
                Debug.Log("Empty tile");
                break;

            case 1:
                Debug.Log("Corner tile");
                Instantiate(levelMap1, q2pos, q2rot);
                break;

            case 2:
                Debug.Log("Outer wall");
                Instantiate(levelMap2, q2pos, q2rot);
                break;
        }

            //don't mirror yet just get it working

    }
}
