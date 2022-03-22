using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject contextMenu;
    public Dialogue dialogue;
    public Text dialogueText; 
    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        Time.timeScale = 0;
        StartDialogue(dialogue);
    }

    public void StartDialogue(Dialogue dialogue) {
        sentences.Clear();

        foreach (string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence() {
        if (sentences.Count == 0) {
            EndDialogue();
            return;
        } else {
            string sentence = sentences.Dequeue();
            dialogueText.text = sentence;
        }
    }

    public void EndDialogue() {
        Destroy(contextMenu);
        Time.timeScale = 1;
    }
}
