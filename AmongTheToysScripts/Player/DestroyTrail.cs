using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTrail : MonoBehaviour
{
    void Start()
    {
        Destroy(this.gameObject, 1f);
    }
}