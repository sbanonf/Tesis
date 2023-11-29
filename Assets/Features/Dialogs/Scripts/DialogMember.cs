using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CharacterSpeech
{
    public ScriptableObjectCharacterSpeech character;
    public List<string> speech = new List<string>();
}

//public string characterName;
//public DialogCharactersEnum dialogCharacter;
//public Sprite characterSprite;

public class DialogMember : MonoBehaviour
{
    //[SerializeField] List<CharacterSpeech> dialogCharacters = new List<CharacterSpeech>();
    //public List<CharacterSpeech> DialogCharacters { get { return dialogCharacters; } }
    [SerializeField] SOConversation dialogCharacters;
    public SOConversation DialogCharacters => dialogCharacters;
    [SerializeField] List<Sprite> tempSprites = new List<Sprite>();

    public (Sprite, Sprite) ConversationMembersImages()
    {
        for (int i = 0; i < dialogCharacters.Conversation.Count; i++)
        {
            Sprite tempSprite = dialogCharacters.Conversation[i].character.characterSprite;
            if (!tempSprites.Contains(tempSprite))
                tempSprites.Add(tempSprite);

            //For testing
            if(i==dialogCharacters.Conversation.Count-1 && tempSprites.Count == 1)
            {
                tempSprites.Add(tempSprite);
            }
        }

        // Here always we should have 2 elements
        // Refering that conversations should be between 2 people and no more (at least for now)
        return (tempSprites[0], tempSprites[1]);
    }
}