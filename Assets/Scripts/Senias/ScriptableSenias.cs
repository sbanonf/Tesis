using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Senia", menuName = "Señas/Seña")]
public class ScriptableSenias : ScriptableObject
{
    [TextAreaAttribute]
    public string Descripcion;
    public Sprite img;
    public bool Activo;
}
