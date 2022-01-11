using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private int tomoCoins;
    [SerializeField] private Text tomoCoinsText;

    void Start()
    {
        tomoCoins = 0;
    }

    void Update()
    {
        tomoCoinsText.text = tomoCoins.ToString();
    }

    public void PegouTomoCoin(){
        tomoCoins ++;
    }
}