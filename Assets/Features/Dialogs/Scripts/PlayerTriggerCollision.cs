using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerCollision : MonoBehaviour
{
    [SerializeField] string tagToCollideWith;

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag(tagToCollideWith))
        {
            return;
        }
        DialogMember temp = collision.gameObject.GetComponent<DialogMember>();
        DialogSystem._instance.CallSpeech(temp);
    }
}
