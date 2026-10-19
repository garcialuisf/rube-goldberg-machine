using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    [Header("Configuración del Objetivo")]
    [Tooltip("El objeto que la cámara debe mirar.")]
    public Transform target;

    [Header("Configuración de Rotación")]
    [Tooltip("Velocidad de suavizado al girar. Ponlo en 0 para rotación instantánea.")]
    public float rotationSpeed = 5.0f;

    void LateUpdate()
    {
        // Si no se ha asignado un objetivo, no hacemos nada
        if (target == null) return;

        // Calculamos la dirección desde la cámara hacia el objetivo
        Vector3 direction = target.position - transform.position;

        // Si la dirección es cero (están en la misma posición), evitamos errores
        if (direction.sqrMagnitude < 0.0001f) return;

        // Calculamos la rotación necesaria para orientarse hacia esa dirección
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        if (rotationSpeed > 0)
        {
            // Rotación suave usando Slerp
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            // Rotación instantánea sin suavizado
            transform.rotation = targetRotation;
        }
    }
}