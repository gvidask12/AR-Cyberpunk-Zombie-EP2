using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class laikmatis : MonoBehaviour
{
    [SerializeField] float laikas;
    public Text laikoTekstas;
    bool jauBuvo = false;
    bool jauBuvo2 = false;

    int min;
    int sec;
    bool JauPradet = false;

    // Use this for initialization
    void Start()
    {

    }
    void PrasidedaLaikas()
    {
        JauPradet = true;
    }

    // Update is called once per frame
    void Update()
    {
        laikas = laikas - Time.deltaTime;

            int min = Mathf.FloorToInt(laikas / 60);
            int sec = Mathf.FloorToInt(laikas % 60);

            laikoTekstas.GetComponent<Text>().text = min.ToString("00") + ":" + sec.ToString("00");
            if (laikas <= 0 && jauBuvo2 == false)
            {
            laikoTekstas.GetComponent<Text>().text = ("00:00");
            print("pasibaige laikas");
           
                jauBuvo2 = true;
            LoadScene();

            }
                if (laikas <= 31)
                {
            laikoTekstas.color = new Color(212f / 255.0f, 94f / 255.0f, 89f / 255.0f);
                }
        /*
        if (laikas >= 0 && jauBuvo == false)
        {
           // laikas = laikas - Time.deltaTime;
            laikoTekstas.text = laikas.ToString("f0");
        }
        else if (laikas <= 0 && jauBuvo2 == false)
        {
            print("pasibaige laikas");
            jauBuvo2 = true;
            jauBuvo = true;
        }*/
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(1);
    }
}
