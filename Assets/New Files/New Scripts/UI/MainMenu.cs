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
        faq.gameObject.SetActive(false);
        bossFight.gameObject.SetActive(false);
        
    }
    public void ShowButtons()
    {
        play.gameObject.SetActive(true);
        quit.gameObject.SetActive(true);
        volumen.gameObject.SetActive(true);
        credits.gameObject.SetActive(true); 
        faq.gameObject.SetActive(true); 
        bossFight.gameObject.SetActive(true); 
        
    }

    public void BossCave()
    {
        SFXMenu();
        SceneManager.LoadScene("NewCave");
    }
    
    public void VolumeCanvas()
    {
        SFXMenu();
        HideButtons();
        volumeCanvas.SetActive(true);
        volumenExit.onClick.AddListener(VolumeCanvasExit);
        
    }
    
    
    public void ShowFaqCanvas()
    {
        SFXMenu();
        HideButtons();
        faqCanvas.SetActive(true);
        faqExit.onClick.AddListener(FaqCanvasExit);
        
    }
    public void FaqCanvasExit()
    {
        SFXMenu();
        faqExit.onClick.RemoveAllListeners();
        faqCanvas.SetActive(false);
        ShowButtons();
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
