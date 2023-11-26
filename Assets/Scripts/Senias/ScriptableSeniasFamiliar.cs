using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Senia", menuName = "Senias/FamiliaSenia")]
public class ScriptableSeniasFamiliar : ScriptableObject
{
    [TextAreaAttribute]
    public string Descripcion;
    public List<Sprite> imgs=new List<Sprite>();
    public bool Activo;
}
