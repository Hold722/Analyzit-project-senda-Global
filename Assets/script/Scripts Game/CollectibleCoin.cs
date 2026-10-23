using UnityEngine;

public class CollectibleCoin : MonoBehaviour
{
    [Header("Settings")]
    public int coinValue = 1; // Cuánto vale esta moneda (por defecto 1)
    public float rotationSpeed = 50f; // Velocidad opcional para que la moneda gire

    [Header("Effects (Optional)")]
    public AudioClip collectSound; // Sonido al recogerla

    void Update()
    {
        // Hace que la moneda gire sobre su propio eje (efecto visual clásico)
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que chocó tiene la etiqueta "Player" (Asegúrate que tu jugador tenga esa Tag)
        if (other.CompareTag("Player"))
        {
            // Busca el GameManager en la escena y llama a la función de sumar monedas
            GameManager gameManager = FindObjectOfType<GameManager>();

            if (gameManager != null)
            {
                // Si quieres sumar de 1 en 1, puedes llamar a AddCollectible() las veces que valga la moneda
                // O adaptar el GameManager para recibir un parámetro. Por ahora llamamos al método:
                gameManager.AddCollectible();
            }
            else
            {
                Debug.LogWarning("No se encontró el GameManager en la escena.");
            }

            // Reproducir sonido si está asignado (opcional)
            if (collectSound != null)
            {
                AudioSource.PlayClipAtPoint(collectSound, transform.position);
            }

            // Destruye la moneda de la escena
            Destroy(gameObject);
        }
    }
}
