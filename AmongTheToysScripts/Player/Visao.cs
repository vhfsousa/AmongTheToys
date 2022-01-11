using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visao : MonoBehaviour
{
    [SerializeField] private float sensibilidade;
    [SerializeField] private Transform cabeca;
    Vector3 rotacaoCabeca;

    void Start()
    {
        sensibilidade = 2;
        rotacaoCabeca = Vector3.zero;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Vector3 rotacao = transform.eulerAngles;
        rotacao.y += Input.GetAxis("Mouse X") * sensibilidade;
        transform.eulerAngles = rotacao;

        rotacaoCabeca.x -= Input.GetAxis("Mouse Y") * sensibilidade;
        rotacaoCabeca.x = Mathf.Clamp(rotacaoCabeca.x, -90, 90);
        cabeca.localEulerAngles = rotacaoCabeca;
    }
}