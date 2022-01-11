using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BazookaDropada : MonoBehaviour
{
    void OnTriggerEnter(Collider col){
        if(col.CompareTag("Player")){
            col.gameObject.GetComponent<Armas>().PegarBazooka();
            col.gameObject.GetComponent<Armas>().TrocarArmaAtual(Armas.ArmasPossiveis.BAZOOKA);
            this.gameObject.SetActive(false);
        }
    }
}