using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torreta : MonoBehaviour
{
    [SerializeField] private GameObject projetil;
    [SerializeField] private Transform spawnProjetil;
    [SerializeField] private Transform jogador;
    [SerializeField] private float resfriamento;
    [SerializeField] private bool monitorando;
    [SerializeField] private AudioSource audioS;
    [SerializeField] private AudioClip somTorreta;

    void Start(){
        jogador = GameObject.FindWithTag("Player").transform;
    }

    void Update(){
        
        monitorando = true;

        if(Vector3.Distance(transform.position, jogador.position) < 30){

            Ray raio = new Ray(transform.position, jogador.position - transform.position);

            if(Vector3.Angle(transform.forward, raio.direction) < 30){

                RaycastHit hit;

                if (Physics.Raycast(raio, out hit, 30)){

                    if (hit.transform == jogador){
                        monitorando = false;
                        audioS.Play();
                        transform.LookAt(jogador);

                        if(resfriamento < Time.time) {
                            resfriamento = Time.time + 0.3f;
                            spawnProjetil.LookAt(jogador);
                            Vector3 posicaoProjetil = spawnProjetil.position;
                            Quaternion rotacaoProjetil = Quaternion.FromToRotation(Vector3.zero, spawnProjetil.forward);
                            GameObject clone = Instantiate(projetil, posicaoProjetil, rotacaoProjetil);
                            clone.GetComponent<Rigidbody>().AddForce(spawnProjetil.forward * 500);
                            Destroy (clone, 3);
                        }
                    }
                }
            }
        }

        if(monitorando == true){
            audioS.Pause();
            transform.Rotate(0, 120 * Time.deltaTime, 0);
        }
    }
}