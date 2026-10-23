using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueCanvas;
    public TMP_Text dialogueText;

    public string[] dialogues;

    private int currentDialogue = 0;

    void Start()
    {
        dialogueCanvas.SetActive(false);
    }

    public void StartDialogue()
    {
        dialogueCanvas.SetActive(true);
        currentDialogue = 0;
        dialogueText.text = dialogues[currentDialogue];
    }

    void Update()
    {
        if (dialogueText != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                NextDialogue();
            }
        }
    }

    void NextDialogue()
    {
        currentDialogue++;
        if (currentDialogue < dialogues.Length)
        {
            dialogueText.text = dialogues[currentDialogue];
        }
        else
        {
            EndDialogue();
        }
    }
    void EndDialogue()
    {
        dialogueCanvas.SetActive(false);
    }
}  