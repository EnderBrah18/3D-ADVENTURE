using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform target;            // O transform do jogador
    public Vector3 offset = new Vector3(0, 3, 7); // Offset da câmera em relação ao jogador
    public float sensitivity = 3f;      // Sensibilidade do mouse
    public float distance = 6f;         // Distância da câmera
    public float height = 3f;           // Altura da câmera
    public float smoothSpeed = 10f;     // Suavidade na rotação

    float yaw; // Rotação horizontal
    float pitch; // Rotação vertical

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Trava o cursor no centro da tela
    }

    private void Update()
    {
        Debug.Log($"Mouse X: {Input.GetAxis("Mouse X")}, Mouse Y: {Input.GetAxis("Mouse Y")}");
    }

    void LateUpdate()
    {
        yaw += Input.GetAxis("Mouse X") * sensitivity;
        pitch += Input.GetAxis("Mouse Y") * sensitivity;
        pitch = Mathf.Clamp(pitch, -30f, 60f); // Limita o ângulo vertical

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        Vector3 desiredPosition = target.position + rotation * new Vector3(0, height, -distance);

        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.LookAt(target.position + Vector3.up * 1.5f); // Olha para o peito/cabeça do personagem
    }
}
