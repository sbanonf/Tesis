using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollectableType
{
    Coin,Gem,Key
}

public class Collectable : MonoBehaviour
{
    public CollectableType collectableType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //Aumentar un contador
            switch (collectableType)
            {
                case CollectableType.Coin:
                    CollectableManager.Instance.UpdateCoinText(true);
                    break;
                case CollectableType.Gem:
                    CollectableManager.Instance.UpdateGemsText(true);
                    break;
                case CollectableType.Key:
                    print("Collected a key");
                    break;
            }

            Destroy(this.gameObject);
        }
    }
}
