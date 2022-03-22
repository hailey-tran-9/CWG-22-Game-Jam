using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public AudioSource buttonSource;
    public AudioClip buttonSound;

    public GameObject pauseMenu;
    // Start is called before the first frame update

    public void OpenMenu() {
        buttonSource.Play();
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }
    void Start()
    {
        buttonSource = gameObject.AddComponent<AudioSource>();
        buttonSource.clip = buttonSound;
        buttonSource.volume = 0.4f;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Restart() {
        buttonSource.Play();
        Time.timeScale = 1;
       SceneManager.LoadScene("Bedroom");
    }
    public void Resume() {
        buttonSource.Play();
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void Quit() {
        buttonSource.Play();
        Application.Quit();
    }
}
