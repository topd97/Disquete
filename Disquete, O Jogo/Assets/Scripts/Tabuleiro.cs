using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tabuleiro : MonoBehaviour {

    public int linhas = 40;
    public int colunas = 100;
    public GameObject chão;
    public GameObject fundo;

    private Transform boardHolder;
    private List<Vector3> gridPositions = new List<Vector3>();
    private GameObject ParaInstanciar;

    void InitialiseList()
    {
        gridPositions.Clear();

        for (int x = 1; x < colunas - 1; x++)
        {
            for (int y = 1; y < linhas - 1; y++)
            {
                gridPositions.Add(new Vector3(x, y, 0f));
            }
        }

    }

    public void SetupDoTabuleiro()
    {
        boardHolder = new GameObject("Board").transform;

        for(int i=0;i<linhas;i++)
        {
            for(int j=0;j<colunas;j++)
            {
                if(i<15)
                {
                    if (j < 30 || (j >= 70 && j < 90))
                    {
                        ParaInstanciar = chão;

                    }
                    else
                    {
                        ParaInstanciar = fundo;
                    }
                }
                else if(i>=15 && i<20)
                {
                    if (j < 15 || (j >= 70 && j < 90))
                    {
                        ParaInstanciar = chão;
                    }
                    else
                    {
                        ParaInstanciar = fundo;
                    }
                }
                else
                {
                    ParaInstanciar = fundo;
                }

                GameObject instancia = Instantiate(ParaInstanciar , new Vector3(j, i, 0f), Quaternion.identity) as GameObject;
                instancia.transform.SetParent(boardHolder);
            }
        }


    }
}
