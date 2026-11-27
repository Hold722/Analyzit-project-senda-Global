using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{
    public TMP_Text textoIntro;
    public Button botonContinuar;
    public Button botonOmitir;

    [TextArea(2, 5)]
    public string[] frases;
    public float velocidadLetra = 0.04f;

    public AudioSource audioSource;
    public AudioClip sonidoClick;

    public string escenaDestino = "Menu";

    private int indiceActual = 0;
    private bool escribiendo = false;
    private bool cargando = false;
    private Coroutine rutinaActual;

    void Start()
    {
        if (botonContinuar != null)
        {
            botonContinuar.onClick.AddListener(AlPulsarContinuar);
        }

        if (botonOmitir != null)
        {
            botonOmitir.onClick.AddListener(OmitirIntro);
        }

        if (frases != null && frases.Length > 0)
        {
            MostrarSiguienteFrase();
        }
    }

    void MostrarSiguienteFrase()
    {
        if (rutinaActual != null)
        {
            StopCoroutine(rutinaActual);
        }

        rutinaActual = StartCoroutine(EscribirFrase(frases[indiceActual]));
    }

    IEnumerator EscribirFrase(string frase)
    {
        escribiendo = true;

        if (textoIntro != null)
        {
            textoIntro.text = "";
        }

        foreach (char c in frase)
        {
            if (textoIntro != null)
            {
                textoIntro.text += c;
            }

            yield return new WaitForSeconds(velocidadLetra);
        }

        escribiendo = false;
    }

    public void AlPulsarContinuar()
    {
        if (cargando) return;

        ReproducirClick();

        if (escribiendo)
        {
            if (rutinaActual != null)
            {
                StopCoroutine(rutinaActual);
            }

            if (textoIntro != null && frases != null && indiceActual < frases.Length)
            {
                textoIntro.text = frases[indiceActual];
            }

            escribiendo = false;
            return;
        }

        indiceActual++;

        if (frases != null && indiceActual < frases.Length)
        {
            MostrarSiguienteFrase();
        }
        else
        {
            IrAEscenaDestino();
        }
    }

    public void OmitirIntro()
    {
        if (cargando) return;

        ReproducirClick();

        if (rutinaActual != null)
        {
            StopCoroutine(rutinaActual);
        }

        IrAEscenaDestino();
    }

    void IrAEscenaDestino()
    {
        cargando = true;
        Time.timeScale = 1f;

        if (botonContinuar != null) botonContinuar.interactable = false;
        if (botonOmitir != null) botonOmitir.interactable = false;

        if (!string.IsNullOrEmpty(escenaDestino))
        {
            SceneManager.LoadScene(escenaDestino);
        }
    }

    void ReproducirClick()
    {
        if (audioSource != null && sonidoClick != null)
        {
            audioSource.PlayOneShot(sonidoClick);
        }
    }
}