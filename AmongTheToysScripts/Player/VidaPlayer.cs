using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaPlayer : MonoBehaviour
{
    public int vidaJogador;
    [SerializeField] private GameObject jogador;
    [SerializeField] private GameObject ultimoCheckpointRespawn;
    [SerializeField] private Quaternion ultimoCheckpointRotation;
    [SerializeField] private bool respawning;
    [SerializeField] private Image telaPreta;
    [SerializeField] private Text textoVida;
    [SerializeField] private bool invulneravel;
    [SerializeField] private AudioSource audioS;
    [SerializeField] private AudioClip gameOver;
    [SerializeField] private AudioClip jogadorTomandoDano;

    void Start()
    {
        vidaJogador = 3;
        invulneravel = false;
        ultimoCheckpointRespawn = this.gameObject;
        ultimoCheckpointRotation = this.transform.rotation;
    }

    void Update()
    {
        textoVida.text = vidaJogador.ToString();
        Morreu();
    }

    void Morreu(){
        if(vidaJogador == 0){
            audioS.PlayOneShot(gameOver);
            StartCoroutine(Respawn());
            return;
        }
    }

    public void PerdeVida(){
        if(invulneravel == false){
            audioS.PlayOneShot(jogadorTomandoDano);
            vidaJogador --;
            invulneravel = true;
            Invoke("InvulnerabilidadeAcaba", 3f);
        }
    }

    public void GanhaVidaPilhaPequena(){
        vidaJogador += 1;
    }

    public void GanhaVidaPilhaGrande(){
        vidaJogador += 3;
    }

    private void InvulnerabilidadeAcaba(){
        invulneravel = false;
    }

    public void PegouCheckpoint(GameObject checkpoint){
        ultimoCheckpointRespawn = checkpoint;
        ultimoCheckpointRotation = Quaternion.identity;
    }

    IEnumerator Respawn(){
        if(respawning == true){
            yield break;
        }else{
            respawning = true;

            GetComponent<Movimentacao>().enabled = false;
            GetComponent<Visao>().enabled = false;

            Color cor = Color.black;
            cor.a = 0;
            while (cor.a < 1) {
                cor.a += Time.deltaTime / 2;
                telaPreta.color = cor;
                yield return null;
            }

            jogador.transform.position = ultimoCheckpointRespawn.transform.position;
            jogador.transform.rotation = ultimoCheckpointRotation;
            vidaJogador = 3;
            
            yield return new WaitForSeconds(2);

            while (cor.a > 0){
                cor.a -= Time.deltaTime;
                telaPreta.color = cor;
                yield return null;
            }

            GetComponent<Movimentacao>().enabled = true;
            GetComponent<Visao>().enabled = true;

            respawning = false; 
        }
    }
}
