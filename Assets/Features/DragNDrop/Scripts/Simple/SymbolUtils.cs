using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public enum DND_Symbol_Type
{
   A, B, C, D, E, F, G, H, I, J, K, L, M, N, N_, O, P, Q, R, S, T, U, V, W, X, Y, Z,
   Father_1, Father_2, Father_3, Father_4,
   Mother_1, Mother_2, Mother_3,
   Sister_1,Sister_2, Sister_3,Sister_4,
   Brother_1,Brother_2,Brother_3,Brother_4,
   Granny_1,Granny_2,Granny_3,
   Granf_1,Granf_2, Granf_3,
   Z_
}

public enum Genealogic_Type
{
    Father,
    Mother,
    Brother,
    Sister,
    Granf_Mother,
    Granny_Mother,
    Granf_Father,
    Granny_Father
}

public enum DND_Symbol_State
{
    Placed,Active,InTarget
}

public class SymbolUtils : MonoBehaviour
{
    public static float collisionRadius = .6f;
    public static Vector2 collisionCapsule = new Vector2(1f, 2f);
    public static float checkEmptyRadius = .65f;

    public static float minScale = 1f;
    public static float maxScale = 1.25f;
    public static float timeStep = 1f;

    public static float moveSpeed = 10f;
    public static float uiMoveSpeed = 1000f;


    public static int resetLayer = 8;
    public static int placedLayer = 10;
    
    public static void SetSymbolState_Placed(SymbolSelectable _selectable)
    {
        _selectable.SymbolState = DND_Symbol_State.Placed;
    }
    public static void SetSymbolState_Active(SymbolSelectable _selectable)
    {
        _selectable.SymbolState = DND_Symbol_State.Active;
    }
    public static void SetSymbolState_InTarget(SymbolSelectable _selectable)
    {
        _selectable.SymbolState = DND_Symbol_State.InTarget;
    }
}
