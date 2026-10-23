using UnityEngine;

public class NPcinteraction : MonoBehaviour

{
    public GameObject dialoguevisualCue;
    public DialogueManager dialogueManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Start()
    {
     if (dialoguevisualCue != null)
        {
            dialoguevisualCue.SetActive(false); //Desactiva el visual cue al inicio del juego
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (dialoguevisualCue != null)
            {
                dialoguevisualCue.SetActive(true); // Activa el visual cue cuando el jugador entra en el trigger
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
                if (other.CompareTag("Player"))
        {
            if (dialoguevisualCue != null)
            {
                dialoguevisualCue.SetActive(false); // Desactiva el visual cue cuando el jugador sale del trigger
            }
        } 
    }

    // Update is called once per frame

}
