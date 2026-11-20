using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverTrigger : MonoBehaviour
{
    [Header("Configuración de Game Over")]
    public string defeatSceneName = "Defeat"; // Nombre exacto de tu escena de Game Over
    public AudioSource gameOverAudioSource;

    private bool isGameOver = false;

    void OnCollisionEnter(Collision collision)
    {
        CheckHazard(collision.gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        CheckHazard(other.gameObject);
    }

    void CheckHazard(GameObject hitObject)
    {
        if (isGameOver) return;

        if (hitObject.CompareTag("Rio") || hitObject.CompareTag("Enemigo"))
        {
            isGameOver = true;
            Time.timeScale = 1f;

            if (gameOverAudioSource != null)
            {
                // Mantiene el AudioSource vivo al cambiar de escena para que suene la música de Game Over
                DontDestroyOnLoad(gameOverAudioSource.gameObject);
                if (!gameOverAudioSource.isPlaying)
                {
                    gameOverAudioSource.Play();
                }
            }

            SceneManager.LoadScene(defeatSceneName);
        }
    }
}