using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sounds : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField] AudioClip coin;
    [SerializeField] AudioClip arrow;
    [SerializeField] AudioClip stones;
    public static sounds Instance;
    public AudioSource src;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        GameManager.Instance.sumCoins.AddListener(Coins);
        GameManager.Instance.arrow.AddListener(Arrows);
        GameManager.Instance.nextLevel.AddListener(Stones);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayOneShot(AudioClip p_clip)
    {
        src.PlayOneShot(p_clip);
    }
    public void Coins()
    {

        
        src.PlayOneShot(coin);
    }


    public void Arrows()
    {

        src.PlayOneShot(arrow);
    }
    public void Stones()
    {
        src.PlayOneShot(stones);
    }
}
