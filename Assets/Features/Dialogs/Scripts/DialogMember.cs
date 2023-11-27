using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CharacterSpeech
{
    public string characterName;
    public DialogCharactersEnum dialogCharacter;
    public Sprite characterSprite;
    public List<string> speech = new List<string>();
}

public class DialogMember : MonoBehaviour
{
    [SerializeField] List<CharacterSpeech> dialogCharacters = new List<CharacterSpeech>();
    public List<CharacterSpeech> DialogCharacters { get { return dialogCharacters; } }
}
