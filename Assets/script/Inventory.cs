using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private int nbCoin =0;
    public static Inventory Instance;
    public Text CoinCountText;
    public GameObject Victory;
   
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("il y a plusieur instance de l'inventaire");
            return;
        }
        Instance = this;
        CoinCountText.text = nbCoin.ToString();
    }

    public void AddCoins(int count)
    {
        nbCoin += count;
        CoinCountText.text = nbCoin.ToString();
    }

    private void Update()
    {
        if (nbCoin == 6)
        { 
            var tempColor = Victory.GetComponent<Image>().color;
            tempColor.a = 255f;
            Victory.GetComponent<Image>().color = tempColor;
        }
    }
}
