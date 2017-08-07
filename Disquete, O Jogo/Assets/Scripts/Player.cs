using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Sprite mario;
    public int velocidade;


    private Rigidbody2D rb;


    // Use this for initialization
    void Awake ()
    {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {

        float MoveHorizontal = Input.GetAxis("Horizontal");
        if(MoveHorizontal>0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            rb.AddForce(new Vector2(MoveHorizontal, 0) * velocidade);
        }
        else if(MoveHorizontal<0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            rb.AddForce(new Vector2(MoveHorizontal, 0) * velocidade);
        }
       
     
    }
}
