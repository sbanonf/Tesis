using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SO_SetearPregunta : MonoBehaviour
{
    public ScriptablePregunta pregunta;
    private TextMeshProUGUI texto;
    public  Image[] images;

    // Start is called before the first frame update
    void Start()
    {
        texto = GetComponentInChildren<TextMeshProUGUI>();
        texto.text = pregunta.pregunta;
        for (int i = 0; i < images.Length; i++) {
            images[i].sprite = pregunta.rptas[i].img;
            if (pregunta.rptas[i].img == pregunta.rptac.img)
            {
                images[i].GetComponent<Button>().onClick.AddListener(PeleaManager.Instance.Aumentar);
                images[i].GetComponent<Button>().onClick.AddListener(Destruirse);
            }
            else {
                images[i].GetComponent<Button>().onClick.AddListener(PeleaManager.Instance.Disminuir);
                images[i].GetComponent<Button>().onClick.AddListener(Destruirse);
            }
        }
       
    }
    void Destruirse() {
        PeleaManager.Instance.Seteo();
        Destroy(this.gameObject);
    }

}
