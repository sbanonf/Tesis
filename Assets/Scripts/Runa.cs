using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runa : MonoBehaviour
{
    public ScriptableSeñas seña;
    private SpriteRenderer sprite;
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        sprite.sprite = seña.img;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            seña.Activo = true;
            RunesManager.Instance.Aumentar();
            Destroy(this.gameObject);
        }           
    }
}
