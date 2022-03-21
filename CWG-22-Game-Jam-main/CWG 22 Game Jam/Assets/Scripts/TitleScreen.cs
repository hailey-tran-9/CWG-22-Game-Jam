using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public GameObject tutorialScreen;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame() {
       // SceneManager.LoadScene("PlayerMovementWithEnemies");
    }

    public void OpenTutorial() {
        // SceneManager.LoadScene();
        tutorialScreen.SetActive(true);
    }

    public void ExitTutorial() {
        tutorialScreen.SetActive(false); 
    }
}
