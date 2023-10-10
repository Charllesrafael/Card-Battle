using System;
using System.Collections;
using UnityEngine;

public class WaitSystem : MonoBehaviour
{
    public static WaitSystem instance;

    private void Awake()
    {
        instance = this;
    }

    public static void Wait(float time, Action callback)
    {
        instance?.StartCoroutine(instance.IEWait(time, callback));
    }

    private IEnumerator IEWait(float time, Action callback)
    {
        yield return new WaitForSeconds(time);
        callback?.Invoke();
    }

}
