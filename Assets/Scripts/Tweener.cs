using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweener : MonoBehaviour
{

    // Variables
    //private Tween activeTween;
    private Tween activeTween;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activeTween != null) 
        {
            float timeFraction = (Time.time - activeTween.StartTime) / activeTween.Duration;
            float timeFractionCubed = Mathf.Pow(timeFraction, 3.0f);

                if (Vector3.Distance(activeTween.Target.position, activeTween.EndPos) > 0.1f)
                {
                    //Debug.Log("Lerping");
                    activeTween.Target.position = Vector3.Lerp(activeTween.StartPos, activeTween.EndPos, timeFractionCubed);
                }
                else
                {
                    //Debug.Log("Jumping");
                    activeTween.Target.position = activeTween.EndPos;
                    activeTween = null;
                }
         }
    }

    // AddTween
    public bool AddTween(Transform targetObject, Vector3 startPos, Vector3 endPos, float duration) 
    {
        if (TweenExists(targetObject) == false)
        {
            Debug.Log("Tween added");
            activeTween = new Tween(targetObject, startPos, endPos, Time.time, duration);
            return true;
        }
        else 
        {
            //Debug.Log("Tween exists?");
            return false;
        }

    }

    public bool TweenExists(Transform target) 
    {
        if (activeTween != null) 
        {
            //Debug.Log("Active tween is not null!");
            return true;
        }
        //Debug.Log("Active tween is null!");
        return false;
    }
}
