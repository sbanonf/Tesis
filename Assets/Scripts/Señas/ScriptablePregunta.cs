using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Pregunta", menuName = "Señas/Pregunta")]
public class ScriptablePregunta : ScriptableObject
{
    [TextAreaAttribute]
    public string pregunta;
    public ScriptableSeñas[] rptas;
    public ScriptableSeñas rptac;

}
