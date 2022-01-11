using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarroF1 : MonoBehaviour
{
    [SerializeField] private Transform jogador;
    [SerializeField] private Transform[] pontosPatrulha;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float delay;
    [SerializeField] private AudioSource audioS;
    [SerializeField] private AudioClip somCarro;

    void Start(){
        agent = GetComponent<NavMeshAgent>();
    }

    void Update(){
        if(Vector3.Distance(transform.position, jogador.position) < 15){
            Ray raio = new Ray(transform.position, jogador.position - transform.position);
            RaycastHit hit;
            if (Physics.Raycast(raio, out hit, 15)){
                if (hit.transform == jogador){
                    audioS.PlayOneShot(somCarro);
                    agent.SetDestination(jogador.position);
                }
            }
        }else{
            if(agent.remainingDistance > 0.1f){
                delay = 2;
            } else{
                delay -= Time.deltaTime;
                if(delay < 0){
                    Vector3 destino = pontosPatrulha[Random.Range(0, pontosPatrulha.Length)].position;
                    destino.x += Random.Range(-0.5f, 0.5f);
                    destino.z += Random.Range(-0.5f, 0.5f);
                    agent.SetDestination(destino);
                }
            }
        }
    }

    void OnCollisionEnter(Collision col){
        if(col.gameObject.CompareTag("Player")){
            jogador.GetComponent<VidaPlayer>().PerdeVida();
        }
    }
}