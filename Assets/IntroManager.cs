using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{
    [Header("Botón Continuar")]
    public Button botonContinuar;

    [Header("Escena del Menú")]
    public bool usarNombreEscena = true;
    public string nombreEscenaMenu = "Menu";

    private bool cargandoEscena = false;

    void Start()
    {
        if (botonContinuar != null)
        {
            botonContinuar.onClick.RemoveAllListeners();
            botonContinuar.onClick.AddListener(IrAlMenu);
        }
    }

    public void IrAlMenu()
    {
        if (cargandoEscena) return;

        cargandoEscena = true;
        Time.timeScale = 1f;

        if (botonContinuar != null)
            botonContinuar.interactable = false;

        if (usarNombreEscena && !string.IsNullOrEmpty(nombreEscenaMenu))
        {
            SceneManager.LoadScene(nombreEscenaMenu);
        }
        else
        {
            int siguienteIndice = SceneManager.GetActiveScene().buildIndex + 1;
            if (siguienteIndice < SceneManager.sceneCountInBuildSettings)
                SceneManager.LoadScene(siguienteIndice);
            else
                Debug.LogWarning("No hay más escenas agregadas en Build Settings.");
        }
    }
}