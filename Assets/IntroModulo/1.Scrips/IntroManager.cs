using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    [Header("Referencias de UI")]
    [Tooltip("Arrastra aquí el objeto TextMeshPro donde saldrá el texto")]
    public TextMeshProUGUI textoUI;

    [Tooltip("Arrastra aquí el botón para avanzar")]
    public Button botonContinuar;

    [Header("Configuración de la Intro")]
    [Tooltip("Escribe aquí cada párrafo o frase de tu intro")]
    [TextArea(3, 6)]
    public string[] frases;

    [Tooltip("Tiempo en segundos entre cada letra (menor = más rápido)")]
    public float velocidadEscritura = 0.04f;

    [Header("Sonidos")]
    [Tooltip("Arrastra aquí el componente AudioSource para los efectos")]
    public AudioSource fuenteEfectos;

    [Tooltip("Arrastra aquí el clip de audio del clic del botón")]
    public AudioClip sonidoBoton;

    [Header("Al terminar la intro")]
    [Tooltip("Si está marcado, cargará la siguiente escena al terminar")]
    public bool cargarEscenaAlTerminar = true;

    [Tooltip("Nombre exacto de la escena a cargar")]
    public string nombreSiguienteEscena = "SampleScene";

    private int indiceFrase = 0;
    private bool escribiendo = false;
    private Coroutine rutinaEscritura;

    void Start()
    {
        if (botonContinuar != null)
        {
            botonContinuar.onClick.AddListener(AlPulsarContinuar);
        }

        if (frases.Length > 0)
        {
            IniciarFrase();
        }
    }

    void IniciarFrase()
    {
        if (rutinaEscritura != null)
        {
            StopCoroutine(rutinaEscritura);
        }

        rutinaEscritura = StartCoroutine(EscribirLetraPorLetra(frases[indiceFrase]));
    }

    IEnumerator EscribirLetraPorLetra(string fraseCompleta)
    {
        escribiendo = true;
        textoUI.text = "";

        foreach (char letra in fraseCompleta.ToCharArray())
        {
            textoUI.text += letra;
            yield return new WaitForSeconds(velocidadEscritura);
        }

        escribiendo = false;
    }

    public void AlPulsarContinuar()
    {
        // Reproducir el sonido del botón cada vez que se pulsa
        if (fuenteEfectos != null && sonidoBoton != null)
        {
            fuenteEfectos.PlayOneShot(sonidoBoton);
        }

        // 1. Si todavía se están escribiendo las letras, completamos la frase de golpe
        if (escribiendo)
        {
            StopCoroutine(rutinaEscritura);
            textoUI.text = frases[indiceFrase];
            escribiendo = false;
            return;
        }

        // 2. Si ya terminó de escribirse, pasamos a la siguiente frase
        indiceFrase++;

        if (indiceFrase < frases.Length)
        {
            IniciarFrase();
        }
        else
        {
            TerminarIntro();
        }
    }

    void TerminarIntro()
    {
        if (cargarEscenaAlTerminar && !string.IsNullOrEmpty(nombreSiguienteEscena))
        {
            SceneManager.LoadScene(nombreSiguienteEscena);
        }
        else
        {
            textoUI.gameObject.SetActive(false);
            if (botonContinuar != null) botonContinuar.gameObject.SetActive(false);
        }
    }
}