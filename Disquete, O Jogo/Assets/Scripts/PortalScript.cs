using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour {
    // Use this for initialization
    private bool open=false;
    public string nextSceane;
	void Start ()
    {
        
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        if(PlayerScript.getFita)
        {
            open = true;
        }
		
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            if (open)
            {
                SceneManager.LoadScene(nextSceane);
            }
        }
    }
}
