using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Runa : MonoBehaviour
{
    public ScriptableSenias senia;
    private SpriteRenderer sprite;
    public LifeTime lifetime;
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        if (senia.Activo == true) {
            senia.Activo = false;
        }
    }
    private void Start()
    {
        sprite.sprite = senia.img;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            lifetime.gameObject.SetActive(true);
            lifetime.Setear(senia);
            AudioManager.instance.Play("Rec");
            senia.Activo = true;
            RunesManager.Instance.Aumentar();
            Destroy(this.gameObject);
        }           
    }
    
}
