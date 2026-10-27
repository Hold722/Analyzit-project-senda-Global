using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el que choca es el Jugador
        if (other.CompareTag("Player"))
        {
            // Buscar el GameManager en la escena y sumar el coleccionable
            GameManagerPiraña gameManager = FindObjectOfType<GameManagerPiraña>();
            if (gameManager != null)
            {
                gameManager.Addcollectible();
            }

            // Destruir este objeto coleccionable (el pez)
            Destroy(gameObject);
        }
    }
}