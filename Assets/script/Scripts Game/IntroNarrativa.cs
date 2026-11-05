using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class IntroNarrativa : MonoBehaviour
{
    [Header("Referencias UI")]
    public TextMeshProUGUI textoUI;

    [Header("Configuración de Texto")]
    [TextArea(3, 5)]
    public string[] lineasTexto; // Las frases de tu intro
    public float velocidadEscritura = 0.04f; // Tiempo entre cada letra (más pequeño = más rápido)
    public float tiempoEsperaEntreLineas = 2.5f; // Pausa cuando termina de escribir una frase
    public string nombrePrimerNivel = "Nivel1"; // Nombre EXACTO de la escena de tu nivel

    private bool cambiandoDeEscena = false;
    private bool estaEscribiendo = false;
    private string lineaActual = "";

    void Start()
    {
        StartCoroutine(ReproducirIntro());
    }

    void Update()
    {
        // Saltar frase o saltar intro completa con Espacio/Enter
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            if (estaEscribiendo)
            {
                // Si aún está escribiendo la línea, la muestra completa de un solo golpe
                StopAllCoroutines();
                textoUI.text = lineaActual;
                estaEscribiendo = false;
                StartCoroutine(EsperarYPasarSiguiente());
            }
            else if (!cambiandoDeEscena)
            {
                // Si ya terminó de escribir o presiona de nuevo, carga el juego
                CargarMenu();
            }
        }
    }

    IEnumerator ReproducirIntro()
    {
        foreach (string linea in lineasTexto)
        {
            lineaActual = linea;
            textoUI.text = ""; // Limpia el texto previo
            estaEscribiendo = true;

            // Escribe letra por letra
            foreach (char letra in linea.ToCharArray())
            {
                textoUI.text += letra;
                yield return new WaitForSeconds(velocidadEscritura);
            }

            estaEscribiendo = false;
            yield return new WaitForSeconds(tiempoEsperaEntreLineas);
        }

        CargarMenu();
    }

    IEnumerator EsperarYPasarSiguiente()
    {
        yield return new WaitForSeconds(tiempoEsperaEntreLineas);
        CargarMenu();
    }

    void CargarMenu()
    {
        if (cambiandoDeEscena) return;
        cambiandoDeEscena = true;
        SceneManager.LoadScene(nombrePrimerNivel);
    }
}