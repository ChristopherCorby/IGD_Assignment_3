using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoGen : MonoBehaviour
{

    public GameObject demoPacman;


    // Start is called before the first frame update
    void Start()
    {
        Instantiate(demoPacman, new Vector3(-20.0f, 0.0f, 0.0f), Quaternion.Euler(0, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
