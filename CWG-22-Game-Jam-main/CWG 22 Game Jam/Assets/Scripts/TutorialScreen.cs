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
    public Sprite obstacles;

    void Awake()
    {
        Objective();
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
        tutorialScreen.SetActive(false);
    }

    public void Objective() {
        title.text = "Objective";
        description.text = "Objective Description";
        img.sprite = objective;
    }

    public void Controls() {
        title.text = "Controls";
        description.text = "Controls Description";
        img.sprite = controls;
    }

    public void Nightmares() {
        title.text = "Nightmares";
        description.text = "Nightmares Description";
        img.sprite = nightmares;
    }
    public void GoodDreams() {
        title.text = "Good Dreams";
        description.text = "Good Dreams Description";
        img.sprite = goodDreams;
    }
    public void Obstacles() {
        title.text = "Obstacles";
        description.text = "Obstacles Description";
        img.sprite = goodDreams;
    }
}
