using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChaveGaveta : MonoBehaviour
{
    public GameObject gavetaAberta;
    public Vector3 posFinal;
    public bool executando = false;
    [SerializeField] private Image trianguloCheck;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col){
        StartCoroutine(MoverObjetoMovel());
        trianguloCheck.gameObject.SetActive(true);
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    IEnumerator MoverObjetoMovel(){
        if(executando == true){
            yield break;
        }

        executando = true;

        while (Vector3.Distance(gavetaAberta.transform.position, posFinal) > 0.01f){
            gavetaAberta.transform.position = Vector3.Lerp(gavetaAberta.transform.position, posFinal, 0.5f * Time.deltaTime);
            yield return null;
        }
        gavetaAberta.transform.position = posFinal;
        this.gameObject.SetActive(false);

        executando = false;
    }
}