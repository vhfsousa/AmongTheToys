using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Armas : MonoBehaviour
{
    //Enum com as armas do jogador
    public enum ArmasPossiveis { DESARMADO, SCAR, BAZOOKA }
    public ArmasPossiveis armasDoJogador;

    //Verificar se o jogador possui as armas
    [SerializeField] private bool possuiScar;
    [SerializeField] private bool possuiBazooka;
    
    //GameObjects
    [SerializeField] private GameObject balaScar;
    [SerializeField] private GameObject balaBazooka;
    [SerializeField] private GameObject crosshair;
    [SerializeField] private GameObject hudMunicao;
    [SerializeField] private GameObject iconeBalasScar;
    [SerializeField] private GameObject iconeBalasBazooka;
    [SerializeField] private GameObject scar;
    [SerializeField] private GameObject bazooka;
    [SerializeField] private GameObject saidaBalaBazooka;
    [SerializeField] private GameObject saidaBalaScar;
    [SerializeField] private GameObject rastroBazooka;
    [SerializeField] private GameObject rastroScar;
    [SerializeField] private Text municaoNoPente;
    [SerializeField] private Text municaoTotal;
    [SerializeField] private AudioSource audioS;
    [SerializeField] private AudioSource somScar;
    [SerializeField] private AudioClip somReload;
    [SerializeField] private AudioClip tiroScar;
    [SerializeField] private AudioClip tiroBazooka;


    //Variáveis das armas
    [SerializeField] private int municaoScarPente;
    [SerializeField] private int municaoScarTotal;
    [SerializeField] private int municaoBazookaPente;
    [SerializeField] private int municaoBazookaTotal;
    [SerializeField] private bool scarLigada;
    [SerializeField] private Vector3 centroTela;


    void Start()
    {
        //Variáveis gerais
        centroTela = new Vector3 (Screen.width/2, Screen.height/2);

        //Deixar o jogador sem armas no começo
        scarLigada = false;
        possuiScar = false;
        possuiBazooka = false;

        //Munição Inicial
        municaoScarPente = 30;
        municaoScarTotal = 30;
        municaoBazookaPente = 5;
        municaoBazookaTotal = 5;

    }

    void Update()
    {
        if(possuiScar == true && Input.GetKeyDown("1")){
            TrocarArmaAtual(ArmasPossiveis.SCAR);
        }
        if(possuiBazooka == true && Input.GetKeyDown("2")){
            TrocarArmaAtual(ArmasPossiveis.BAZOOKA);
        }
        if(Input.GetKeyDown("3")){
            TrocarArmaAtual(ArmasPossiveis.DESARMADO);
        }

        switch (armasDoJogador){
            case ArmasPossiveis.DESARMADO:
                Desarmado();
            break;

            case ArmasPossiveis.SCAR:
                Scar();
            break;

            case ArmasPossiveis.BAZOOKA:
                Bazooka();
            break;
        }
    }

    public void TrocarArmaAtual(ArmasPossiveis armaAtual){
        armasDoJogador = armaAtual;
    }

    void Desarmado(){
        //Desativar outras armas e ativar a certa
        crosshair.SetActive(false);
        hudMunicao.SetActive(false);
        scar.SetActive(false);
        bazooka.SetActive(false);
        scarLigada = false;

        //Comportamento da arma

    }

    void Scar(){
        //Desativar outras armas e ativar a certa
        crosshair.SetActive(true);
        hudMunicao.SetActive(true);
        iconeBalasScar.SetActive(true);
        iconeBalasBazooka.SetActive(false);
        municaoNoPente.text = municaoScarPente.ToString();
        municaoTotal.text = municaoScarTotal.ToString();
        bazooka.SetActive(false);
        scar.SetActive(true);

        //Comportamento da arma
            //Recarregar
        if(municaoScarTotal > 0 && Input.GetKeyDown(KeyCode.R)){
            audioS.PlayOneShot(somReload);
            if(municaoScarTotal >= 30){
                municaoScarTotal -= (30 - municaoScarPente);
                municaoScarPente = 30;
            }else{
                if(municaoScarPente + municaoScarTotal > 30){
                    municaoScarTotal -= (30 - municaoScarPente);
                    municaoScarPente = 30;
                }
                else{
                    municaoScarPente += municaoScarTotal;
                    municaoScarTotal = 0;
                } 
            }
        }

            //Ligar Arma
        if(scarLigada == false && Input.GetButtonDown("Fire2")){
            somScar.Play();
            scarLigada = true;
        } else if (scarLigada == true && Input.GetButtonDown("Fire2")){
            somScar.Pause();
            scarLigada = false;
        }

            //Atirar
        if(municaoScarPente > 0 &&scarLigada == true && Input.GetButtonDown("Fire1")){
            Ray raio = Camera.main.ScreenPointToRay(centroTela);
            RaycastHit hit;

            if(Physics.Raycast(raio, out hit, 80)){
                //Tocar Som
                audioS.PlayOneShot(tiroScar);
                
                //TirarVidaInimigo
                VidaInimigo vidaInimigo = hit.transform.GetComponent<VidaInimigo>();
                if(vidaInimigo == true){
                    vidaInimigo.TirarVida(10);
                }
                
                Vector3 posicao = hit.point + hit.normal/5;
                Quaternion rotacao = Quaternion.LookRotation(-hit.normal);
                GameObject copia = Instantiate (balaScar, posicao, rotacao);
                copia.transform.parent = hit.transform;
                Destroy(copia, 5);

                //RastroBala
                Rigidbody rb = Instantiate(rastroScar, saidaBalaScar.transform.position + transform.forward/2, Quaternion.identity).GetComponent<Rigidbody>();
                Vector3 forca = (hit.point - rb.transform.position).normalized * 2000;
                rb.AddForce(forca);

                //Animação arma e descer bala
                municaoScarPente --;
                scar.transform.Rotate(-10, 0, 0);
                Invoke("DescerScar", 0.25f);
            }
        }
    }

    void Bazooka(){
        //Desativar outras armas e ativar a certa
        crosshair.SetActive(true);
        hudMunicao.SetActive(true);
        iconeBalasBazooka.SetActive(true);
        iconeBalasScar.SetActive(false);
        municaoNoPente.text = municaoBazookaPente.ToString();
        municaoTotal.text = municaoBazookaTotal.ToString();
        scar.SetActive(false);
        bazooka.SetActive(true);
        scarLigada = false;

        //Comportamento da arma
            //Recarregar
        if(municaoBazookaTotal > 0 && Input.GetKeyDown(KeyCode.R)){
            audioS.PlayOneShot(somReload);
            if(municaoBazookaTotal >= 5){
                municaoBazookaTotal -= (5 - municaoBazookaPente);
                municaoBazookaPente = 5;
            }else{
                if(municaoBazookaPente + municaoBazookaTotal > 5){
                    municaoBazookaTotal -= (5 - municaoBazookaPente);
                    municaoBazookaPente = 5;
                }
                else{
                    municaoBazookaPente += municaoBazookaTotal;
                    municaoBazookaTotal = 0;
                } 
            }
        }

            //Atirar
        if(municaoBazookaPente > 0 && Input.GetButtonDown("Fire1")){
            Ray raio = Camera.main.ScreenPointToRay(centroTela);
            RaycastHit hit;

            if(Physics.Raycast(raio, out hit, 80)){
                //Tocar Som
                audioS.PlayOneShot(tiroBazooka);

                //TirarVidaInimigo
                VidaInimigo vidaInimigo = hit.transform.GetComponent<VidaInimigo>();
                if(vidaInimigo == true){
                    vidaInimigo.TirarVida(50);
                }

                Vector3 posicao = hit.point + hit.normal/100;
                Quaternion rotacao = Quaternion.LookRotation(-hit.normal);
                GameObject copia = Instantiate (balaBazooka, posicao, rotacao);
                copia.transform.parent = hit.transform;
                Destroy(copia, 2);

                //RastroBala
                Rigidbody rb = Instantiate(rastroBazooka, saidaBalaBazooka.transform.position + transform.forward/2, Quaternion.identity).GetComponent<Rigidbody>();
                Vector3 forca = (hit.point - rb.transform.position).normalized * 2000;
                rb.AddForce(forca);

                //Animação arma e descer bala
                municaoBazookaPente --;
                bazooka.transform.Rotate(-30, 0, 0);
                Invoke("DescerBazooka", 0.25f);
            }
        }
    }

    void DescerScar(){
        scar.transform.Rotate(10, 0, 0);
    }

    void DescerBazooka(){
        bazooka.transform.Rotate(30, 0, 0);
    }

    public void PegarScar(){
        possuiScar = true;
    }

    public void PegarBazooka(){
        possuiBazooka = true;
    }

    public void RecarregarBalasScar(){
        municaoScarTotal += 30;
    }

    public void RecarregarBalasBazooka(){
        municaoBazookaTotal += 5;
    }
}