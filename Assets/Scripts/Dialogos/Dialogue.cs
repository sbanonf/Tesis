using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogues/Dialogue")]
public class Dialogue : ScriptableObject
{
    [TextArea(3, 10)] // Esto permite editar el arreglo en un cuadro de texto grande en el Inspector
    public string[] sentences;
}