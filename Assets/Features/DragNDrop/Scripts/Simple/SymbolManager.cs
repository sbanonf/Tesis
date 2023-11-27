using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolManager : MonoBehaviour
{
    public static SymbolManager _instance;

    [SerializeField] private List<SymbolSelectable> _selectables = new List<SymbolSelectable>();

    public Camera main;
    public LayerMask collisionLayer;
    public LayerMask checkEmptyLayer;

    private Dictionary<string, SymbolSelectable> initialPosDictionary = new Dictionary<string, SymbolSelectable>();

    //public bool version2;

    [SerializeField] SlotsManager slotsManager;
    
    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        main = Camera.main;
    }

    public void Initialize()
    {
        for(int i=0;i<_selectables.Count;i++)
            _selectables[i].Initialize();
        
        for (int i = 0; i < _selectables.Count; i++)
        {
            initialPosDictionary.Add(_selectables[i].UniqueID, _selectables[i]);
        }

        slotsManager.Initialize();
    }

    public void SetSelectable_Active(SymbolSelectable _selectable)
    {
        for (int i = 0; i < _selectables.Count; i++)
        {
            //if (version2)
            //{
                if (_selectables[i].SymbolState != DND_Symbol_State.InTarget)
                    SymbolUtils.SetSymbolState_Placed(_selectables[i]);
            //}
            //else
            //{
            //    if (_selectables[i].SymbolState != DND_Symbol_State.InTarget)
            //        SymbolUtils.SetSymbolState_Placed(_selectables[i]);
            //    else
            //        _selectables[i]._Reset();
            //}
        }
        SymbolUtils.SetSymbolState_Active(_selectable);
    }

    public Vector3 GetInitialPos(string _selectable)
    {
        SymbolSelectable temp;
        if (initialPosDictionary.TryGetValue(_selectable, out temp))
        {
            Debug.Log("Found!");
            return temp.InitialPosition;
        }

        return Vector3.zero;
    }

    public Vector3 GetTargetPos(string _selectable)
    {
        SymbolSelectable temp;
        if (initialPosDictionary.TryGetValue(_selectable, out temp))
        {
            Debug.Log("Found!");
            return temp.TargetTransform.position;
        }

        return Vector3.zero;
    }

    public void ResetAll()
    {
        for (int i = 0; i < _selectables.Count; i++)
        {
            _selectables[i]._Reset();

        }
    }

    public void ResetSelectable(SymbolSelectable _selectable)
    {
        _selectable._Reset();
    }

    //public void DisableColliders()
    //{
    //    for (int i = 0; i < _selectables.Count; i++)
    //        _selectables[i].Collider_Deactivate();
    //}
    
    //public void EnableColliders()
    //{
    //    for (int i = 0; i < _selectables.Count; i++)
    //        _selectables[i].Collider_Activate();
    //}
}
