using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDamage : MonoBehaviour
{
    [SerializeField] private GameObject jogador;

    void Start()
    {
        jogador = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col){
        if(col.gameObject.CompareTag("Player")){
            jogador.GetComponent<VidaPlayer>().PerdeVida();
        }
    }
}
