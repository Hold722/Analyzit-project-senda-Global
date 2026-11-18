using UnityEngine;
using UnityEngine.UI; // Necesario para trabajar con componentes UI Image

public class TalkingImage : MonoBehaviour
{
    private Image imageComponent;

    [Header("Sprites de la boca")]
    public Sprite mouthClosed; // Imagen con la boca cerrada
    public Sprite mouthOpen;   // Imagen con la boca abierta

    [Header("Configuración de Velocidad")]
    public float speakSpeed = 0.1f; // Tiempo entre cada cambio de sprite (en segundos)
    private float timer;

    [Header("Estado")]
    public bool isTalking = false; // Actívalo desde otro script o ponlo en true para probar

    void Start()
    {
        // Obtiene automáticamente el componente Image del objeto
        imageComponent = GetComponent<Image>();

        if (imageComponent == null)
        {
            Debug.LogError("El script TalkingImage necesita un componente Image en el mismo GameObject.");
        }
    }

    void Update()
    {
        // Si está hablando, alterna los sprites según el tiempo transcurrido
        if (isTalking && mouthClosed != null && mouthOpen != null)
        {
            timer += Time.deltaTime;

            if (timer >= speakSpeed)
            {
                timer = 0f;
                // Alterna entre cerrado y abierto
                if (imageComponent.sprite == mouthClosed)
                {
                    imageComponent.sprite = mouthOpen;
                }
                else
                {
                    imageComponent.sprite = mouthClosed;
                }
            }
        }
        else if (!isTalking && mouthClosed != null && imageComponent != null)
        {
            // Si no está hablando, se queda con la boca cerrada por defecto
            imageComponent.sprite = mouthClosed;
        }
    }

    // Métodos públicos para controlar el estado desde otros scripts (como un sistema de diálogos)
    public void StartTalking()
    {
        isTalking = true;
    }

    public void StopTalking()
    {
        isTalking = false;
        if (mouthClosed != null)
        {
            imageComponent.sprite = mouthClosed;
        }
    }
}
