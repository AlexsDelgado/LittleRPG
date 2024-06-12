using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
    public static UI INS;

    public Text txtContadorEnemigos;
    public int NumDeTexto;
    string[] Textos = new string[] { "Utiliza W A S D para moverte ", "Utiliza las flechas para disparar", " Cuidado con los enemigos " };
    private float timer =0;
    private void Awake()
    {
        if (INS == null)
        {
            INS = this;
        }
        else
        {
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        NumDeTexto = -1;
    }

    private void Update()
    {
        timer += Time.deltaTime;
    }
    public void SigText()
    {

        NumDeTexto++;
        txtContadorEnemigos.text = Textos[NumDeTexto];
        timer = 0;
    }


}
