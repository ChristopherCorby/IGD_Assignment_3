using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoGen : MonoBehaviour
{

    public GameObject demoPacman;
    private Tweener tweener;
    private Vector3 pos1 = new Vector3(-13f, 13.5f, -1f);
    private Vector3 pos2 = new Vector3(-8f, 13.5f, -1f);
    private Vector3 pos3 = new Vector3(-8f, 9.5f, -1f);
    private Vector3 pos4 = new Vector3(-13f, 9.5f, -1f);

    float lastTime = 0.0f;
    float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        tweener = gameObject.GetComponent<Tweener>();
        //Instantiate(demoPacman, new Vector3(-13f, 13.5f, 0.0f), Quaternion.Euler(0, 0, 0));
        demoPacman.transform.position = demoPacman.transform.position + new Vector3(-13f, 13.5f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;

        //Debug.Log(demoPacman.transform.position);
        //Debug.Log(pos1);

        if (Vector3.Distance(demoPacman.transform.position, pos1) == 0)
        {
            tweener.AddTween(demoPacman.transform, demoPacman.transform.position, pos2, 2.5f);
            lastTime = timer;
        }
        else if (Vector3.Distance(demoPacman.transform.position, pos2) == 0) 
        { 
            tweener.AddTween(demoPacman.transform, demoPacman.transform.position, pos3, 2f);
            lastTime = timer;
        }
        else if (Vector3.Distance(demoPacman.transform.position, pos3) == 0)
        {
            tweener.AddTween(demoPacman.transform, demoPacman.transform.position, pos4, 2.5f);
            lastTime = timer;
        }
        else if (Vector3.Distance(demoPacman.transform.position, pos4) == 0)
        {
            tweener.AddTween(demoPacman.transform, demoPacman.transform.position, pos1, 2f);
            lastTime = timer;
        }

    }
}
