using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNDropManager : MonoBehaviour
{
    [SerializeField] SlotsManagerUI slotsManagerUI;
    Coroutine currentCoroutine = null;

    public void Initialize()
    {
        if (currentCoroutine == null)
        {
            currentCoroutine = StartCoroutine(Initialize_Coroutine());
        }
    }

    IEnumerator Initialize_Coroutine()
    {
        yield return null;
        slotsManagerUI.Initialize();
        currentCoroutine = null;
    }


    public void Reset()
    {
        slotsManagerUI.Reset();
    }
}
