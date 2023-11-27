using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Senia Puzzle", menuName = "Senias/Puzzle")]
public class ScriptablePuzzle : ScriptableObject
{
    [TextAreaAttribute]
    public string Descripcion;
    public Sprite img;
    public DND_Symbol_Type type;
    public bool Activo;
}
