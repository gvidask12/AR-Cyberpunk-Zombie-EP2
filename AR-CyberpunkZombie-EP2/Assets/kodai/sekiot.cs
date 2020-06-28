using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sekiot : MonoBehaviour
{
    public Transform[] target;
    private int current;
    public float speed = 0f;
    const float EPSILON = 0f;
    // bool JUDEDIMAS = true;
    bool aktyvus = true;
    // Use this for initialization
    void Start()
    {
        target[current] = GameObject.Find("sekimoKubikas").transform;
        //target[current] = Camera.main.transform;
        //target[current] = GameObject.Find("sekimoKubikas");
    }
    void Nebesekioja()
    {
        print("zombis mire1111");
        aktyvus = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != target[current].position && aktyvus == true)
        {
            //if(Vector3.Distance(transform.position, target[current].transform.position) <= 0.25f) { 
            Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, Time.deltaTime);
            pos.y = 0;
            //GetComponent<Animator> ();	
            GetComponent<Rigidbody>().MovePosition(pos);
            //transform.LookAt (target [current].position);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(target[current].transform.position - transform.position), 0.03f);
            if ((transform.position - target[current].position).magnitude > EPSILON)
                transform.Translate(0.0f, 0.0f, speed * Time.deltaTime);
            else current = (current + 1) % target.Length;
        }
    }
}

