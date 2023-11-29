using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character Speech", menuName = "Dialog/CharacterSpeech")]
public class ScriptableObjectCharacterSpeech : ScriptableObject
{
    public string characterName;
    public DialogCharactersEnum dialogCharacter;
    public Sprite characterSprite;
}
