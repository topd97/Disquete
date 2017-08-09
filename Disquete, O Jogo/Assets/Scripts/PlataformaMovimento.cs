using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovimento : MonoBehaviour {

    public float velocidade;
    private Rigidbody2D rigidbody;
	// Use this for initialization
	void Start ()
    {
        rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()//plataforma de movimento vertical
    {
        Vector2 moviment = new Vector2(0f, velocidade);
        rigidbody.MovePosition(rigidbody.position + moviment * Time.deltaTime);
    }
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="ColisorPlataforma")
        {
            velocidade = velocidade * -1;
        }
    }
}
