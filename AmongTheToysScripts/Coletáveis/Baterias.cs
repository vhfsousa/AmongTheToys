using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baterias : MonoBehaviour
{
    [SerializeField] private GameObject jogador;
    [SerializeField] private AudioSource audioS;
    [SerializeField] private AudioClip somVida;

    void Start()
    {
        jogador = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.CompareTag("Player")){
            audioS.PlayOneShot(somVida);
            jogador.gameObject.GetComponent<VidaPlayer>().GanhaVidaPilhaGrande();
            gameObject.SetActive(false);
        }
    }
}