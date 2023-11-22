using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Runa : MonoBehaviour
{
    public ScriptableSeñas seña;
    private SpriteRenderer sprite;
    public LifeTime lifetime;
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        if (seña.Activo == true) {
            seña.Activo = false;
        }
    }
    private void Start()
    {
        sprite.sprite = seña.img;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            lifetime.gameObject.SetActive(true);
            lifetime.Setear(seña);
            AudioManager.instance.Play("Rec");
            seña.Activo = true;
            RunesManager.Instance.Aumentar();
            Destroy(this.gameObject);
        }           
    }
    
}
