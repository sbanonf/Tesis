using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Runa : MonoBehaviour
{
    public ScriptableSenias senia;
    public ScriptablePuzzle seniaPuzzle;
    private SpriteRenderer sprite;
    //public LifeTime lifetime;
    
    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        if (senia.Activo == true) {
            senia.Activo = false;
            seniaPuzzle.Activo = false;
        }
    }

    private void Start()
    {
        sprite.sprite = senia.img;
        RunesManager.Instance.CountRuneUnits();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            //lifetime.gameObject.SetActive(true);
            //lifetime.Setear(senia);
            // Si esto tira error, busca que exista un LifeTime en la escena, caso contrario, crea una
            LifeTime._instance.Setear(senia);
            AudioManager.instance.Play("Rec");
            senia.Activo = true;
            seniaPuzzle.Activo = true;
            RunesManager.Instance.Aumentar();
            RunesManager.Instance.SaveRune(seniaPuzzle);
            Destroy(this.gameObject);
        }           
    }
    
}
