using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Conversation", menuName = "Dialog/Conversation")]
public class SOConversation : ScriptableObject
{
    [SerializeField] List<CharacterSpeech> conversation = new List<CharacterSpeech>();

    public List<CharacterSpeech> Conversation => conversation;
}
