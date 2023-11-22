using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectableManager : MonoBehaviour
{
    public static CollectableManager Instance;

    [Header("Coins Properties")]
    [SerializeField] int coins;
    [SerializeField] TextMeshProUGUI coinsText;
    [SerializeField] Animator coinAnimator;

    [Header("Gems Properties")]
    [SerializeField] int gems;
    [SerializeField] TextMeshProUGUI gemsText;
    [SerializeField] Animator gemsAnimator;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);

        coinsText.text = "x " + coins;
        gemsText.text = "x " + gems;
    }

    #region Coins
    public void UpdateCoinText(bool isAdding=true)
    {
        if (isAdding)
            AddCoin();
        else
            TakeCoin();

        coinsText.text = "x " + coins;
    }

    void AddCoin()
    {
        coinAnimator.SetTrigger("Animate");
        coins += 10;
    }

    void TakeCoin()
    {
        coins -= 5;
    }

    #endregion

    #region Gems
    public void UpdateGemsText(bool isAdding = true)
    {
        if (isAdding)
            AddGem();
        else
            TakeGem();

        gemsText.text = "x " + gems;
    }

    void AddGem()
    {
        gemsAnimator.SetTrigger("Animate");
        gems += 10;
    }

    void TakeGem()
    {
        gems -= 5;
    }
    #endregion

}
