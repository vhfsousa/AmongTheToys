using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bateria : MonoBehaviour
{
    [SerializeField] private GameObject jogador;
    [SerializeField] private AudioSource audioS;
    [SerializeField] private AudioClip somVida;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.CompareTag("Player")){
            audioS.PlayOneShot(somVida);
            jogador.gameObject.GetComponent<VidaPlayer>().GanhaVidaPilhaPequena();
            gameObject.SetActive(false);
        }
    }
}