using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotationSpeed = 100f; // Velocidad de rotaci�n de la moneda

    void Update()
    {
        // Rotar la moneda continuamente en el eje Y
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si la colisi�n es con el jugador (u otro objeto con el tag "Player")
        if (other.CompareTag("Breaker"))
        {
            // Recolectar la moneda (puedes agregar aqu� cualquier l�gica adicional)

            // Destruir la moneda
            Destroy(gameObject);
        }
    }
}
