using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runa : MonoBehaviour
{
    public ScriptableSe�as se�a;
    private SpriteRenderer sprite;
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        if (se�a.Activo == true) {
            se�a.Activo = false;
        }
    }
    private void Start()
    {
        sprite.sprite = se�a.img;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            AudioManager.instance.Play("Rec");
            se�a.Activo = true;
            RunesManager.Instance.Aumentar();
            Destroy(this.gameObject);
        }           
    }
}
