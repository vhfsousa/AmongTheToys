using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChaveSotao : MonoBehaviour
{
    public GameObject portaSotao;
    public Vector3 posFinal;
    public bool executando = false;
    [SerializeField] private Image cilindroCheck;
    
    void Start()
    {
        
    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider col){
        StartCoroutine(MoverObjetoMovel());
        cilindroCheck.gameObject.SetActive(true);
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    IEnumerator MoverObjetoMovel(){
        if(executando == true){
            yield break;
        }

        executando = true;

        while (Vector3.Distance(portaSotao.transform.position, posFinal) > 0.01f){
            portaSotao.transform.position = Vector3.Lerp(portaSotao.transform.position, posFinal, 0.5f * Time.deltaTime);
            yield return null;
        }
        portaSotao.transform.position = posFinal;
        this.gameObject.SetActive(false);

        executando = false;
    }
}