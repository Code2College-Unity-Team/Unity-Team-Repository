using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class BallController : MonoBehaviour
{
    public float totalCoins;
    public float coinsCollected = 0;
    public TMP_Text coinText;
    public TMP_Text winText;
    public string coinSymbol = "₵";

    void Start()
    {
        totalCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
        winText.gameObject.SetActive(false);
        CoinTextUpdate();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("touched" + other.gameObject.tag);
        if (other.gameObject.CompareTag("Coin"))
        {
            coinsCollected++;
            CoinTextUpdate();
            other.gameObject.SetActive(false);
            CoinCheck();
        }

    }
    void CoinCheck()
    {
        if (coinsCollected != totalCoins)
        {
            return;
        }
        else
        {
            winText.gameObject.SetActive(true);
        }
    }

    void CoinTextUpdate() => coinText.text = coinSymbol + " " + coinsCollected + "/" + totalCoins;
}
