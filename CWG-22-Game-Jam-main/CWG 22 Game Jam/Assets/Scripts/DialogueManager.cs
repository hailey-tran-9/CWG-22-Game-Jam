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
    public AudioSource buttonSource;
    public AudioClip buttonSound;
    public bool started;

    // Start is called before the first frame update
    void Start()
    {
        buttonSource = gameObject.AddComponent<AudioSource>();
        buttonSource.clip = buttonSound;
        buttonSource.volume = 0.4f;
        sentences = new Queue<string>();
        Time.timeScale = 0;
        started = false;
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
        if (started) {
            buttonSource.Play();
        }
        if (sentences.Count == 0) {
            EndDialogue();
            return;
        } else {
            string sentence = sentences.Dequeue();
            dialogueText.text = sentence;
        }
        started = true;
    }

    public void EndDialogue() {
        Destroy(contextMenu);
        Time.timeScale = 1;
    }
}
