using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    public static GameManager instance = null;
    public Tabuleiro scriptTabuleiro;

    private bool doingSetup;

    void Awake ()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        scriptTabuleiro = GetComponent<Tabuleiro>();
        InitGame();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void InitGame()
    {
        scriptTabuleiro.SetupDoTabuleiro();
    }
}
