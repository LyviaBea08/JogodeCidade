using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricCam : MonoBehaviour
{
    public float moveSpeed = 150f;
    public float zoomSpeed = 150f;

    void Update()
    {
        // Movimento Horizontal e Vertical
        if (Input.GetMouseButton(1))
        {
            float horizontal = Input.GetAxis("Mouse X");
            float vertical = Input.GetAxis("Mouse Y");

            // Obtenha a direção de movimento com base na rotação da câmera
            Vector3 moveDirection = new Vector3(horizontal, 0f, vertical);
            moveDirection = transform.TransformDirection(moveDirection).normalized;

            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        }

        // Zoom (profundidade) com Scroll do Mouse
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            // Ajuste a posição da câmera ao longo do eixo Z com base no scroll
            transform.Translate(Vector3.forward * scroll * zoomSpeed, Space.Self);
        }

        // Imprimir a posição da câmera para debug
        Debug.Log("Posição da Câmera: " + transform.position);
    }
}
