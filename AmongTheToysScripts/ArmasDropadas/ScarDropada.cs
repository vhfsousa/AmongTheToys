using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScarDropada : MonoBehaviour
{
    void OnTriggerEnter(Collider col){
        if(col.CompareTag("Player")){
            col.gameObject.GetComponent<Armas>().PegarScar();
            col.gameObject.GetComponent<Armas>().TrocarArmaAtual(Armas.ArmasPossiveis.SCAR);
            this.gameObject.SetActive(false);
        }
    }
}