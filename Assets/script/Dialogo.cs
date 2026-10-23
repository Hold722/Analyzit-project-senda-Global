using System.Collections;
using TMPro;
using UnityEngine;

public class Dialogo : MonoBehaviour
{
    [SerializeField] private GameObject dialogoPanel;
    [SerializeField] private TMP_Text dialogoText;
    [SerializeField, TextArea(2, 3)] private string[] dialogueLines;

    private bool estaJugadorEnRango;
    private bool didDialogoStart;
    private int lineIndex;

    // Update is called once per frame
    void Update()
    {
        if (estaJugadorEnRango == true)
        {
            if (!didDialogoStart)
            {
                StartDialogo();
            }
        }
        else if (estaJugadorEnRango == false)
        {   
                didDialogoStart = false;
                dialogoPanel.SetActive(false);
        }
    }

    private void StartDialogo()
    {
        didDialogoStart = true;
        dialogoPanel.SetActive(true);
        lineIndex = 0;
        StartCoroutine(ShowLine());
    }


    private IEnumerator ShowLine()
    {
        dialogoText.text = string.Empty;

        foreach (char ch in dialogueLines[lineIndex].ToCharArray())
        {
            dialogoText.text += ch;
            yield return new WaitForSeconds(0.05f);
        }   
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            estaJugadorEnRango = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            estaJugadorEnRango = false;
        }
    }
}
