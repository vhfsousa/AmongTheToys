using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Fantasma : MonoBehaviour
{
    [SerializeField] private Transform jogador;
    [SerializeField] private Transform[] pontosPatrulha;
    [SerializeField] private MeshRenderer meshFantasma;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float delay;

    void Start()
    {
        jogador = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Invoke("FantasmaDesaparece", 2f);

        if(Vector3.Distance(transform.position, jogador.position) < 15){
            Ray raio = new Ray(transform.position, jogador.position - transform.position);
            RaycastHit hit;
            if (Physics.Raycast(raio, out hit, 15)){
                if (hit.transform == jogador){
                    agent.SetDestination(jogador.position);
                }
            }
        }
    }

    void FantasmaDesaparece(){
        meshFantasma.enabled = false;
        Invoke("FantasmaAparece", 2f);
    }

    void FantasmaAparece(){
        meshFantasma.enabled = true;
        Invoke("FantasmaDesaparece", 2f);
    }
}
