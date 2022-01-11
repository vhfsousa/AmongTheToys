using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomoCoins : MonoBehaviour
{
    [SerializeField] private GameObject gameController;
    [SerializeField] private AudioSource audioS;
    [SerializeField] private AudioClip somMoeda;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.CompareTag("Player")){
            audioS.PlayOneShot(somMoeda);
            gameController.gameObject.GetComponent<GameController>().PegouTomoCoin();
            gameObject.SetActive(false);
        }
    }
}