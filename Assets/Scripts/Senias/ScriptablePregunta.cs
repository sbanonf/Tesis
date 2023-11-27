using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Pregunta", menuName = "Senias/Pregunta")]
public class ScriptablePregunta : ScriptableObject
{
    [TextAreaAttribute]
    public string pregunta;
    public ScriptableSenias[] rptas;
    public ScriptableSenias rptac;

}
