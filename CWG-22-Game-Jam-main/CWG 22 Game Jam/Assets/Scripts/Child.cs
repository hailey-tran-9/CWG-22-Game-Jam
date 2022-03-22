using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Child : MonoBehaviour
{
    public int maxHp = 100;
    public int currHp;
    public HpBar hpBar;

    // Start is called before the first frame update
    void Start()
    {
        currHp = maxHp;
        hpBar.ResetHp();
    }

    // Update is called once per frame
    void Update()
    {
        if (currHp <= 0) {
            QuitGame();
        }
    }

    public void ReduceHp() {
        currHp -= 7;
        hpBar.SetHp(currHp);
        Debug.Log("Lost 5 hp: " + currHp);
    }

    public void GainHp() {
        int newHp = currHp + 2;
        if (newHp <= 100) {
            hpBar.SetHp(newHp);
            currHp = newHp;
        }
    }

    void QuitGame() {
<<<<<<< HEAD
        Application.Quit();
=======
        SceneManager.LoadScene("GameOverScreen");
>>>>>>> e10eeb4ff42d08e9a39c26b968153a404602acc9
    }
}