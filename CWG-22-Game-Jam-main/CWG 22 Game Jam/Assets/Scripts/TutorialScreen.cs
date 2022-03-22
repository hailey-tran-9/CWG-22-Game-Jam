using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TutorialScreen : MonoBehaviour
{
    [SerializeField] public GameObject tutorialScreen;
    [SerializeField] public TextMeshProUGUI title;
    [SerializeField] public TextMeshProUGUI description;
    [SerializeField] public Image img;

    public Sprite objective;
    public Sprite controls;
    public Sprite nightmares;
    public Sprite goodDreams;
    public Sprite powerUp;
    public Sprite obstacles;
    public AudioSource buttonSource;
    public AudioClip buttonSound;

    void Awake()
    {
        buttonSource = gameObject.AddComponent<AudioSource>();
        buttonSource.clip = buttonSound;
        buttonSource.volume = 0.4f;
        title.text = "Objective";
        description.text = "Protect your client from nightmares and allow their good dreams to pass through sunrise. The goal is to keep the gauge mostly blue FIX";
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Exit() {
        buttonSource.Play();
        tutorialScreen.SetActive(false);
    }

    public void Objective() {
        buttonSource.Play();
        img.enabled = true;
        title.text = "Objective";
        description.text = "Protect your client from nightmares and allow their good dreams to pass through sunrise. The goal is to keep the gauge mostly blue until your shift is over. (5 minutes)";
        img.sprite = objective;
    }

    public void Controls() {
        buttonSource.Play();
        title.text = "Controls";
        description.text = "Move with WASD. Press J when close to a dream to catch it.";
        img.enabled = false;
    }

    public void Nightmares() {
        buttonSource.Play();
        img.enabled = true;
        title.text = "Nightmares";
        description.text = "Nightmares are red and triangular! Catch these before they harm your client!";
        img.sprite = nightmares;
    }
    public void GoodDreams() {
        buttonSource.Play();
        img.enabled = true;
        title.text = "Good Dreams";
        description.text = "Good dreams are blue and circular! Do not catch these, for they increase your client's health!";
        img.sprite = goodDreams;
    }
    public void Obstacles() {
        buttonSource.Play();
        img.enabled = true;
        title.text = "Obstacles";
        description.text = "There are obstacles in the client's bedroom that you cannot pass through!";
        img.sprite = obstacles;
    }

    public void Items() {
        buttonSource.Play();
        img.enabled = true;
        title.text = "Items";
        description.text = "Walk over powerups to consume them! ";
        img.sprite = powerUp;
    }
}

