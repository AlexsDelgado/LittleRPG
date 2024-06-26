using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Scenes : MonoBehaviour
{




    // Start is called before the first frame update
    void Start()
    {
        NewGameManager.Instance.win.AddListener(Ganar);
        NewGameManager.Instance.lose.AddListener(Perder);
        NewGameManager.Instance.menu.AddListener(Menu);
        NewGameManager.Instance.cave.AddListener(LoadCave);
    }

    public void Ganar()
    {
        SceneManager.LoadScene("NewWin");
    }

    public void Perder()
    {
        SceneManager.LoadScene("NewDefeat");
    }

    public void Menu()
    {
        SceneManager.LoadScene("NewMainMenu");
        //GameManager.Instance.resetGame();

}

    public void Play()
    {
        SceneManager.LoadScene("NewOutworld");

    }
    public void LoadCave()
    {
        SceneManager.LoadScene("NewCave");

    }


    public void Quit()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
