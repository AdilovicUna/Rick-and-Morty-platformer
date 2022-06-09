using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject help;
    public AudioClip click;

    private bool showHelp = false;

    // Start is called before the first frame update
    void Start()
    {
        SoundManager.instance.playLoop();
    }

    // Update is called once per frame
    void Update()
    {
        if(!showHelp)
        {
            help.active = false;
        }
    }

    public void playButton()
    {
        SoundManager.instance.play(click);
        SceneManager.LoadScene("Level1");
    }

    public void helpButton()
    {
        SoundManager.instance.play(click);
        showHelp = true;
        help.active = true;
    }

    public void backButton()
    {
        SoundManager.instance.play(click);
        showHelp = false;
        help.active = false;
    }

    public void quitButton()
    {
        SoundManager.instance.play(click);
        Application.Quit();
    }
}
