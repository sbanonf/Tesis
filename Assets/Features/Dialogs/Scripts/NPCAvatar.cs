using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NPCAvatar : CharacterUITemplate
{
    [SerializeField] Image avatarImage;
    [SerializeField] Sprite tempSprite;

    public override void Initialize()
    {
        base.Initialize();
        avatarImage.sprite = tempSprite;
    }

}
