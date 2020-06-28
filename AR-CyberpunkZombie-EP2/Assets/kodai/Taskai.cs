using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Taskai : MonoBehaviour
{
    public Button yourButton;
    static int taskai = 0;
    Text taskuTekstas;
    // Use this for initialization
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        taskuTekstas = GetComponent<Text>();
        taskuTekstas.text = taskai.ToString();
    }

    public void HitoTaskai(int taskiukai)
    {
        //int sita = SceneManager.GetActiveScene().buildIndex;
        taskai = taskai + taskiukai;
        taskuTekstas.text = taskai.ToString();
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
   
    void TaskOnClick()
    {
        taskai = 0;
    }
}
