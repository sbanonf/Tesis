using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Seña", menuName = "Señas/Seña")]
public class ScriptableSeñas : ScriptableObject
{
    [TextAreaAttribute]
    public string Descripcion;
    public Sprite img;
    public bool Activo;
}
