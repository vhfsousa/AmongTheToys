using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private AudioSource audioS;
    [SerializeField] private AudioClip checkpoint;

    public void OnTriggerEnter(Collider col){
        if(col.gameObject.CompareTag("Player")){
            audioS.PlayOneShot(checkpoint);
            col.gameObject.GetComponent<VidaPlayer>().PegouCheckpoint(this.gameObject);
        }
    }
}