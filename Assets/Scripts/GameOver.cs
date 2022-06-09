using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text txt;
    public AudioClip winSound;
    public AudioClip loseSound;
    public AudioClip click;
    private bool end = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!end)
        {
            this.gameObject.active = false;
        }
    }

    public void endGame(int mortysCount)
    {
        string s = "";
        switch(mortysCount)
        {
            case 0:
                SoundManager.instance.playEnd(winSound);
                s = "You win!" + '\n' + "Congratulations!";
                break;
            case 1:
                SoundManager.instance.playEnd(loseSound);
                s = "Game Over" + '\n' + "1 Morty left";
                break;
            default:
                SoundManager.instance.playEnd(loseSound);
                s = "Game Over" + '\n' + mortysCount + " Morty's left";
                break;
        }

        end = true;
        this.gameObject.active = true;
        txt.text = s;
    }

    public void restartButton()
    {
        SoundManager.instance.play(click);
        end = false;
        this.gameObject.active = true;
        SceneManager.LoadScene("Level1");   
    }

    public void menuButton()
    {
        SoundManager.instance.play(click);
        end = false;
        this.gameObject.active = true;
        SceneManager.LoadScene("MainMenu");
    }
}
