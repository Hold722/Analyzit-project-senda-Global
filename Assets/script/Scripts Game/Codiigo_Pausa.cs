using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CodigoPausa : MonoBehaviour
{
    public GameObject ObjetoMenuPausa; //Referenciar los panales del menu 
    public bool pausa = false;         //Crear una variale booleano

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))  //condicional que dice al presionar la tecla escape 
        {
            if (pausa == false)
            {
                ObjetoMenuPausa.SetActive(true); // Se activa el menu pausa.  //el juego se pone en pausa 
                pausa = true;

                Time.timeScale = 0; //velocidad del juego donde 1 es normal y 0 se congela 
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None; //evitar que el mouse se bloque al activar el pausa
            }
           
        }
    }
    public void Resumir()
    {
        ObjetoMenuPausa.SetActive(false);
        pausa = false;

        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    //Funcion para salir del videojuego 
    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayGame()
    {                                                                   //Funcion para ir al menu de nuevo 
        SceneManager.LoadScene("Menu");
    }

   
}
