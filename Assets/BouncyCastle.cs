using UnityEngine;

public class BouncyCastle : MonoBehaviour
{
    [Header("Configuración de Rebote")]
    [Tooltip("Fuerza de impulso vertical que se aplicará al objeto.")]
    public float bounceForce = 15.0f;

    [Tooltip("Si es true, sustituye la velocidad vertical actual por la fuerza de rebote. Si es false, se suma.")]
    public bool resetVerticalVelocity = true;

    private void OnCollisionEnter(Collision collision)
    {
        // Obtenemos el Rigidbody del objeto que cayó sobre la cama elástica
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

        if (rb != null)
        {
            // Solo rebotamos si el objeto viene cayendo (dirección hacia abajo)
            // o si choca con la parte superior
            Vector3 currentVelocity = rb.linearVelocity;

            if (resetVerticalVelocity)
            {
                // Reiniciamos la velocidad en Y para que el rebote sea constante
                currentVelocity.y = 0;
                rb.linearVelocity = currentVelocity;
            }

            // Aplicamos un impulso hacia arriba
            rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
        }
    }
}