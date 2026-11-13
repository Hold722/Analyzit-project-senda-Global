using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el que choca es el Jugador
        if (other.CompareTag("Player"))
        {
            // Buscar el GameManager en la escena (compatible con GameManagerPirana o GameManagerPiraña)
            GameManagerPirana gameManager = Object.FindFirstObjectByType<GameManagerPirana>();

            if (gameManager != null)
            {
                gameManager.Addcollectible();
            }
            else
            {
                Debug.LogWarning("No se encontró el GameManagerPirana en la escena.");
            }

            // Destruir este objeto coleccionable (la piraña)
            Destroy(gameObject);
        }
    }
}