using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverTrigger : MonoBehaviour
{
    private bool gameOverActivado = false;

    private void OnTriggerEnter(Collider other)
    {
        VerificarJugador(other.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        VerificarJugador(collision.gameObject);
    }

    private void VerificarJugador(GameObject objeto)
    {
        if (gameOverActivado) return;

        if (objeto.CompareTag("Player") ||
            objeto.transform.root.CompareTag("Player"))
        {
            gameOverActivado = true;
            SceneManager.LoadScene("Defeat");
        }
    }
}