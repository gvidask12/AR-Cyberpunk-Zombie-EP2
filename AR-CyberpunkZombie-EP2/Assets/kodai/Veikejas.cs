using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Veikejas : MonoBehaviour
{
    int taskai;
    Text taskuTekstas;
    // Use this for initialization
    void Start()
    {
        taskai = 100;
        taskuTekstas = GetComponent<Text>();
        taskuTekstas.text = taskai.ToString(); 
    }
    public void Zmog(int amnountZmogeliukoZala) 
    {
        taskai = taskai - amnountZmogeliukoZala;
        if (taskai <= 30)
        {
            taskuTekstas.color = new Color(212f / 255.0f, 94f / 255.0f, 89f / 255.0f);
        }
        if (taskai <= 0)
        {
            taskai = 0;

            LoadScene();
        }
        taskuTekstas.text = taskai.ToString(); 
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(1);
    }
}
