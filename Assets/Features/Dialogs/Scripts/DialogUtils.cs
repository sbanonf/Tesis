using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DialogCharactersEnum
{
    MainCharacter,
    NPC
}

public static class DialogUtils
{
    public static float maxTime = 2f;
    [Range(1f, 2f)] public static float timeScaler=1f;
    public static float waitTime = 0.09f;
}
