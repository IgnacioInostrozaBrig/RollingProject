using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotation : MonoBehaviour
{
    public Rigidbody carRigidbody; // Referencia al Rigidbody del auto

    void Update()
    {
        // Obtener la dirección de la velocidad del auto
        Vector3 carVelocityDirection = carRigidbody.velocity.normalized;

        // Calcular el ángulo de rotación en el eje Y
        float angle = Mathf.Atan2(carVelocityDirection.x, carVelocityDirection.z) * Mathf.Rad2Deg;

        // Aplicar la rotación a la rueda
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
    }
}
