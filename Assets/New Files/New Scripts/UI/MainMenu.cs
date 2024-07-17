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
    [SerializeField] private Button faq;
    [SerializeField] private Button volumenExit;
    [SerializeField] private Button creditsExit;
    [SerializeField] private Button faqExit;
    [SerializeField] private Button bossFight;
    
    
    [SerializeField] private GameObject creditsCanvas;
    [SerializeField] private GameObject volumeCanvas;
    [SerializeField] private GameObject faqCanvas;
    [SerializeField] private AudioClip uiSfx;
    
    // Start is called before the first frame update
    void Start()
    {
        play.onClick.AddListener(Play);
        quit.onClick.AddListener(Quit);
        credits.onClick.AddListener(CreditCanvas);
        volumen.onClick.AddListener(VolumeCanvas);
        bossFight.onClick.AddListener(BossCave);
        faq.onClick.AddListener(ShowFaqCanvas);
    }

    private void SFXMenu()
    {
        AudioManager.Instance.PlaySound(uiSfx);
    }
    
    
    private void HideButtons()
    {
        play.gameObject.SetActive(false);
        quit.gameObject.SetActive(false);
        volumen.gameObject.SetActive(false);
        credits.gameObject.SetActive(false);
        faq.gameObject.SetActive(false);
        bossFight.gameObject.SetActive(false);
        
    }
    private void ShowButtons()
    {
        play.gameObject.SetActive(true);
        quit.gameObject.SetActive(true);
        volumen.gameObject.SetActive(true);
        credits.gameObject.SetActive(true); 
        faq.gameObject.SetActive(true); 
        bossFight.gameObject.SetActive(true); 
        
    }

    private void BossCave()
    {
        SFXMenu();
        SceneManager.LoadScene("NewCave");
    }
    
    private void VolumeCanvas()
    {
        SFXMenu();
        HideButtons();
        volumeCanvas.SetActive(true);
        volumenExit.onClick.AddListener(VolumeCanvasExit);
        
    }
    
    
    private void ShowFaqCanvas()
    {
        SFXMenu();
        HideButtons();
        faqCanvas.SetActive(true);
        faqExit.onClick.AddListener(FaqCanvasExit);
        
    }
    private void FaqCanvasExit()
    {
        SFXMenu();
        faqExit.onClick.RemoveAllListeners();
        faqCanvas.SetActive(false);
        ShowButtons();
    }
    private void VolumeCanvasExit()
    {
        SFXMenu();
        volumenExit.onClick.RemoveAllListeners();
        volumeCanvas.SetActive(false);
        ShowButtons();
    }
    
    
    private void CreditCanvas()
    {
        SFXMenu();
        HideButtons();
        creditsCanvas.SetActive(true);
        creditsExit.onClick.AddListener(CreditCanvasExit);
        
    }
    private void CreditCanvasExit()
    {
        SFXMenu();
        creditsExit.onClick.RemoveAllListeners();
        creditsCanvas.SetActive(false);
        ShowButtons();
    }
    
    
    
    private void Quit()
    {
        SFXMenu();
        Application.Quit();
    }
    private void Play()
    {
        SFXMenu();
        NewGameManager.Instance.ResetGame();
        //AudioManager.Instance.StopMusic();
        SceneManager.LoadScene("NewOutworld");

    }
}
