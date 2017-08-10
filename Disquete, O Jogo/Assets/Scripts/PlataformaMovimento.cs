using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovimento : MonoBehaviour {

    public float velocidade;
    public int tipo; //1 = vertical, 2 = horizontal

    private Vector2 moviment;
    private Rigidbody2D rigidbody;
    private GameObject gameobject;

	// Use this for initialization
	void Start ()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        gameobject = GetComponent<GameObject>();
	}
	
	// Update is called once per frame
	void Update ()//plataforma de movimento vertical
    {
        if(tipo == 2 && (transform.position.x >= 60 || transform.position.x <= 47))
        {
            velocidade = velocidade * (-1);
        }
        if(tipo == 1 && transform.position.y>=40)
        {
            transform.position = new Vector3(transform.position.x,0,0);
        }
      
        switch (tipo)
        {
            case 1:
                moviment = new Vector2(0f, velocidade);
                break;
            case 2:
                moviment = new Vector2(velocidade, 0f);
                break;
        }
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
