using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void Comenzar(string nombreNivel)
    {
        SceneManager.LoadScene(nombreNivel);
    }
    public void Salir()
    {
        Application.Quit();
        Debug.Log("Programa Cerrado");
    }

    public void Opciones()
    {
        Debug.Log("Opciones no disponibles. Espera a la versión de pago =)");
    }

}
