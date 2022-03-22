using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public GameObject tutorialScreen;
    public AudioSource buttonSource;
    public AudioClip buttonSound;

    public AudioSource musicSource;
    public AudioClip music;
    void Start()
    {
        buttonSource = gameObject.AddComponent<AudioSource>();
        buttonSource.clip = buttonSound;
        buttonSource.volume = 0.4f;

        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.clip = music;
        musicSource.volume = 0.3f;

        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame() {
        buttonSource.Play();
       SceneManager.LoadScene("Bedroom");
    }

    public void OpenTutorial() {
        // SceneManager.LoadScene();
        tutorialScreen.SetActive(true);
    }

    public void ExitTutorial() {
        buttonSource.Play();
        tutorialScreen.SetActive(false); 
    }
}
