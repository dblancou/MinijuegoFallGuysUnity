using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class señalHelice : MonoBehaviour
{
    public float velocidadRotacion = 15f;
    public Transform centroDeRotacion; // El GameObject vacío alrededor del cual quieres rotar

    void Update()
    {

        // Obtén la posición del centro de rotación
        Vector3 centroPosition = centroDeRotacion.position;

        // Calcula el vector desde el centro de rotación hasta la posición actual del objeto
        Vector3 direccionDesdeCentro = transform.position - centroPosition;

        // Rota el objeto alrededor del centro de rotación
        transform.RotateAround(centroPosition, Vector3.up, velocidadRotacion * Time.deltaTime);

    }
}