using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Inv : MonoBehaviour
{
    public Canvas inv;
    public Canvas vida;
    public void Hide() {
        if (inv.enabled) {
            inv.gameObject.SetActive(false);
            vida.gameObject.SetActive(true);
        }
    }
    public void Show() {
        if (vida.enabled) {
            vida.gameObject.SetActive(false);
            inv.gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Hide();
        }
    }
}
