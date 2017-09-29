using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotaoScript : MonoBehaviour
{
    public void CarregarCena(string sceane)
    {
        SceneManager.LoadScene(sceane);
    }
}
