using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class galutinis : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("veik", 3.00f);	
	}
    public void veik()
    {
        gameObject.SetActive(true);
    }
}
