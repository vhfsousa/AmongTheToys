using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaInimigo : MonoBehaviour
{
    [SerializeField] public int vidaInimigo;
    [SerializeField] private GameObject fumacaBrinquedo;

    void Start()
    {
        fumacaBrinquedo.SetActive(false);
    }

    void Update()
    {
        MatarInimigo();
    }

    public void TirarVida(int vida){
        vidaInimigo -= vida;
    }

    private void MatarInimigo(){
        if(vidaInimigo <= 0){
            fumacaBrinquedo.SetActive(true);

            if (GetComponent<Robo>() == true){
                GetComponent<Robo>().enabled = false;
            }
            if(GetComponent<CarroF1>() == true){
                GetComponent<CarroF1>().enabled = false;
            }
            if(GetComponentInParent<Torreta>() == true){
                GetComponentInParent<Torreta>().enabled = false;
            }
            if(GetComponentInParent<Fantasma>() == true){
                GetComponentInParent<Fantasma>().enabled = false;
            }
        }
    }
}