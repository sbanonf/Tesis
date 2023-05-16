using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public List<Image> heartImages = new List<Image>();

    public Sprite fullSprite, halfSprite, emptySprite;

    public int currentLife;
    public int maxLife;

    void Awake()
    {
        Init();
    }

    public void Init()
    {
        for (int i = 0; i < heartImages.Count; i++)
        {
            heartImages[i].sprite = fullSprite;
            currentLife += 2;
        }
        maxLife = currentLife;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            DealDamage();
    }

    public void DealDamage()
    {
        currentLife = Mathf.Clamp(currentLife - 1, 0, maxLife);
        int tempIndex = currentLife / 2;
        print(tempIndex);

        if (currentLife % 2 == 0)
            heartImages[tempIndex].sprite = emptySprite;
        else if (currentLife % 2 == 1)
            heartImages[tempIndex].sprite = halfSprite;

        if (currentLife > 0)
            return;
        else
        {
            
            maxLife = 0;
            currentLife = 0;
            Init();
            GetComponent<Transform>().position = CheckpointManager.Instance.GetCurrentPoint().position;            
        }
    }
    public void Respawn() {
        DealDamage();
        GetComponent<Transform>().position = CheckpointManager.Instance.GetCurrentPoint().position;
    }
}
