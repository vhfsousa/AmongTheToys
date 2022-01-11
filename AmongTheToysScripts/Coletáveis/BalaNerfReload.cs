using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaNerfReload : MonoBehaviour
{
    [SerializeField] private GameObject jogador;
    [SerializeField] private AudioSource audioS;
    [SerializeField] private AudioClip somAmmo;

    void Start()
    {
        
    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider col){
        audioS.PlayOneShot(somAmmo);
        jogador.GetComponent<Armas>().RecarregarBalasScar();
        this.gameObject.SetActive(false);
    }
}