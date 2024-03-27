using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotation : MonoBehaviour
{
    public Rigidbody carRigidbody; // Referencia al Rigidbody del auto

    void Update()
    {
        // Obtener la direcci�n de la velocidad del auto
        Vector3 carVelocityDirection = carRigidbody.velocity.normalized;

        // Calcular el �ngulo de rotaci�n en el eje Y
        float angle = Mathf.Atan2(carVelocityDirection.x, carVelocityDirection.z) * Mathf.Rad2Deg;

        // Aplicar la rotaci�n a la rueda
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
    }
}
