using UnityEngine;

public class CoinCollectible : MonoBehaviour
{
    [Header("Configuración de la Moneda")]
    [SerializeField] private int valorMoneda = 1; // Cuántos puntos da esta moneda
    [SerializeField] private float velocidadRotacion = 100f; // Velocidad de giro

    [Header("Efectos (Opcional)")]
    [SerializeField] private GameObject efectoRecogido; // Prefab de partículas para cuando se recoge

    void Update()
    {
        // Hace que la moneda gire continuamente sobre su propio eje Y para que sea llamativa
        transform.Rotate(Vector3.up * velocidadRotacion * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que tocó la moneda es el Jugador
        if (other.CompareTag("Player"))
        {
            RecolectarMoneda();
        }
    }

    private void RecolectarMoneda()
    {
        // 1. Aquí llamamos al sistema de puntuación global de Senda Global
        // Si tienes un GameManager, descomenta la línea de abajo o adáptala a tu sistema:
        // GameManager.instancia.SumarMonedas(valorMoneda);

        Debug.Log("¡Moneda recolectada! +" + valorMoneda);

        // 2. Si asignaste un efecto visual, lo crea en la posición de la moneda
        if (efectoRecogido != null)
        {
            Instantiate(efectoRecogido, transform.position, Quaternion.identity);
        }

        // 3. Destruye el objeto de la moneda de la escena
        Destroy(gameObject);
    }
}