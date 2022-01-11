using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentacao : MonoBehaviour
{
    [SerializeField] private float velocidade;
    [SerializeField] private float gravidade;
    [SerializeField] private float pulo;
    [SerializeField] private CharacterController charController;
    [SerializeField] private Vector3 movimento;
    [SerializeField] private int puloDuplo;


    void Start()
    {
        movimento = Vector3.zero;
        charController = GetComponent<CharacterController>();
        puloDuplo = 0;
    }

    void Update()
    {
        //Pulo e Pulo Duplo
        if(charController.isGrounded == true){
            movimento.y = 0;
            puloDuplo = 0;
        }
        if(charController.isGrounded == true && Input.GetKeyDown(KeyCode.Space)){
            puloDuplo = 1;
            movimento.y = pulo;
        }else if(puloDuplo == 1 && Input.GetKeyDown(KeyCode.Space)){
            puloDuplo = 2;
            movimento.y = pulo;
        }
        

        movimento.x = 0;
        movimento.z = 0;
        movimento += Input.GetAxis("Horizontal") * transform.right * velocidade;
        movimento += Input.GetAxis("Vertical") * transform.forward * velocidade;
        movimento.y -= gravidade * Time.deltaTime;
        charController.Move(movimento * Time.deltaTime);
    }
}