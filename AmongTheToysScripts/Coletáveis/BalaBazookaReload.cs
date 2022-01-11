using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaBazookaReload : MonoBehaviour
{
    [SerializeField] private GameObject jogador;
    [SerializeField] private AudioSource audioS;
    [SerializeField] private AudioClip somAmmo;

    void Start()
    {
        jogador = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col){
        audioS.PlayOneShot(somAmmo);
        jogador.GetComponent<Armas>().RecarregarBalasBazooka();
        this.gameObject.SetActive(false);
    }
}