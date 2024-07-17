using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button play;
    [SerializeField] private Button quit;
    [SerializeField] private Button credits;
    [SerializeField] private Button volumen;
    [SerializeField] private Button volumenExit;
    [SerializeField] private Button creditsExit;
    
    
    [SerializeField] private GameObject creditsCanvas;
    [SerializeField] private GameObject volumeCanvas;
    [SerializeField] private AudioClip uiSfx;
    
    // Start is called before the first frame update
    void Start()
    {
        play.onClick.AddListener(Play);
        quit.onClick.AddListener(Quit);
        credits.onClick.AddListener(CreditCanvas);
        volumen.onClick.AddListener(VolumeCanvas);
    }

    public void SFXMenu()
    {
        AudioManager.Instance.PlaySound(uiSfx);
    }
    
    
    public void HideButtons()
    {
        play.gameObject.SetActive(false);
        quit.gameObject.SetActive(false);
        volumen.gameObject.SetActive(false);
        credits.gameObject.SetActive(false);
    }
    public void ShowButtons()
    {
        play.gameObject.SetActive(true);
        quit.gameObject.SetActive(true);
        volumen.gameObject.SetActive(true);
        credits.gameObject.SetActive(true); 
        
    }
    public void VolumeCanvas()
    {
        SFXMenu();
        HideButtons();
        volumeCanvas.SetActive(true);
        volumenExit.onClick.AddListener(VolumeCanvasExit);
        
    }
    public void VolumeCanvasExit()
    {
        SFXMenu();
        volumenExit.onClick.RemoveAllListeners();
        volumeCanvas.SetActive(false);
        ShowButtons();
    }
    
    
    public void CreditCanvas()
    {
        SFXMenu();
        HideButtons();
        creditsCanvas.SetActive(true);
        creditsExit.onClick.AddListener(CreditCanvasExit);
        
    }
    public void CreditCanvasExit()
    {
        SFXMenu();
        creditsExit.onClick.RemoveAllListeners();
        creditsCanvas.SetActive(false);
        ShowButtons();
    }
    
    
    
    public void Quit()
    {
        SFXMenu();
        Application.Quit();
    }
    public void Play()
    {
        SFXMenu();
        SceneManager.LoadScene("NewOutworld");

    }
}
