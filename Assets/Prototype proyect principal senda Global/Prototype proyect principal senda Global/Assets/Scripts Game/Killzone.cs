using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Killzone : MonoBehaviour
{
    [Header("Tiempo de muerte")]
    public float tiempoMuerte = 2.5f;

    private bool muriendo = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !muriendo)
        {
            StartCoroutine(SecuenciaMuerte(other.gameObject));
        }

        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }

    IEnumerator SecuenciaMuerte(GameObject jugador)
    {
        muriendo = true;

        AnimatorPlayer control =
            jugador.GetComponentInChildren<AnimatorPlayer>();

        if (control != null)
        {
         
        }
        else
        {
            Debug.LogWarning(
                "No se encontró AnimatorPlayer en el jugador."
            );
        }

        // Esperar a que se reproduzca la animación.
        yield return new WaitForSeconds(tiempoMuerte);

        // Reiniciar el nivel.
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }
}