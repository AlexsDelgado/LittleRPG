using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Scenes : MonoBehaviour
{




    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.win.AddListener(Ganar);
        GameManager.Instance.lose.AddListener(Perder);
        GameManager.Instance.menu.AddListener(Menu);
    }

    public void Ganar()
    {
        SceneManager.LoadScene("Win");
    }

    public void Perder()
    {
        SceneManager.LoadScene("Defeat");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Main Menu");
        //GameManager.Instance.resetGame();

}

    public void Play()
    {
        SceneManager.LoadScene("Outworld");

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
