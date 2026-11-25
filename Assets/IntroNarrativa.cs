using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroNarrativa : MonoBehaviour
{
    [Header("Texto de la introducción")]
    public TMP_Text textoPantalla;

    [TextArea(3, 6)]
    public string[] lineas;

    [Header("Velocidad")]
    public float tiempoEntreLetras = 0.05f;
    public float pausaEntreLineas = 2f;

    [Header("Botón continuar")]
    public GameObject botonContinuar;

    [Header("Escena de destino")]
    public string nombreEscenaMenu = "Menu";

    private void Start()
    {
        if (botonContinuar != null)
            botonContinuar.SetActive(false);

        StartCoroutine(MostrarNarrativa());
    }

    IEnumerator MostrarNarrativa()
    {
        if (textoPantalla == null || lineas == null)
            yield break;

        foreach (string linea in lineas)
        {
            textoPantalla.text = "";

            foreach (char letra in linea)
            {
                textoPantalla.text += letra;
                yield return new WaitForSeconds(tiempoEntreLetras);
            }

            yield return new WaitForSeconds(pausaEntreLineas);
        }

        if (botonContinuar != null)
            botonContinuar.SetActive(true);
    }

    public void Continuar()
    {
        SceneManager.LoadScene(nombreEscenaMenu);
    }
}