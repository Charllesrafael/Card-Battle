using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public static MoveController instance;

    void Awake()
    {
        instance = this;
    }

    public static void MoveTo(RectTransform cardParent, float _time, Action callback)
    {
        if(instance == null){
            Debug.LogWarning("'instance' em 'MoveController' esta nulo");
            return;
        }
        //instance.StartCoroutine(instance.IMoveTo(cardParent, _time, callback));
    }
    
}
