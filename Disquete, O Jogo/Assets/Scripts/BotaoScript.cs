using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotaoScript : MonoBehaviour
{
    public string sceane;
    private void OnMouseDown()
    {
        print("oi");
        SceneManager.LoadScene(sceane);
    }
}
