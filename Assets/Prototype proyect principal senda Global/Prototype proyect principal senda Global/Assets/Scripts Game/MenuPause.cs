using UnityEngine;
using UnityEngine.SceneManagement;

public class CodiigoPausa : MonoBehaviour
{
    public GameObject ObjetoMenuPausa; // Arrastra aquí tu Panel_Pausa en el Inspector
    public bool pausa = false;

    private void Update()
    {
        // Detecta la tecla Escape tanto si está en pausa como si no
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausa)
            {
                Resumir();
            }
            else
            {
                Pausar();
            }
        }
    }

    public void Pausar()
    {
        ObjetoMenuPausa.SetActive(true);
        pausa = true;

        Time.timeScale = 0f; // Congela el tiempo
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Resumir()
    {
        ObjetoMenuPausa.SetActive(false);
        pausa = false;

        Time.timeScale = 1f; // Devuelve el tiempo a la normalidad
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayGame()
    {
        Time.timeScale = 1f; // Descongelar antes de cambiar de escena
        SceneManager.LoadScene("Menu");
    }
}


