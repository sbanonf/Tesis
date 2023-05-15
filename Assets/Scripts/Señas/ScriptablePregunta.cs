using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Pregunta", menuName = "Se�as/Pregunta")]
public class ScriptablePregunta : ScriptableObject
{
    [TextAreaAttribute]
    public string pregunta;
    public ScriptableSe�as[] rptas;
    public ScriptableSe�as rptac;

}
