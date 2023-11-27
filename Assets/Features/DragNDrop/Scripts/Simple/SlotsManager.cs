using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotsManager : MonoBehaviour
{
    [SerializeField] private string word;

    [SerializeField] private List<string> possibleWords = new List<string>();
    [SerializeField] private List<SlotChecker> slots = new List<SlotChecker>();
    [SerializeField] private Transform initialPosition;
    [SerializeField] private float spaceBetweenPositions;
    [SerializeField] private List<Vector3> positions = new List<Vector3>();
    private Dictionary<string, DND_Symbol_Type> symbolDictionary = new Dictionary<string, DND_Symbol_Type>();

    public void Initialize()
    {
        symbolDictionary = SymbolUtilities.Initialize();
        //List<DND_Symbol_Type> splitted = SymbolUtilities.SplitSymbol(symbolDictionary, possibleWords[0].ToUpper());

        //Vector3 tempInitialPos = initialPosition.localPosition;
        //for(int i = 0; i < splitted.Count; i++)
        //{
        //    positions.Add(new Vector3(tempInitialPos.x+ (i*spaceBetweenPositions), tempInitialPos.y, tempInitialPos.z));
        //}

        //for(int i = 0; i < splitted.Count; i++)
        //{
        //    slots[i].gameObject.SetActive(true);
        //    slots[i].InitializeTargetSymbol(positions[i], splitted[i], i);
        //}
        //ValidateManager._instance.Initialize(splitted.Count);
    }
}
