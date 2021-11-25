using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    public GameObject bloco;
    public GameObject bloco1;

	// Use this for initialization
	void Start () {
        //Random.Range(-3, 10); //aleatorio
        GerarBlocos(3);
        Globais.score = 0;
        Globais.vidas = 3;

    }

    void GerarBlocos(int linhas)
    {
        float x = -3.1f;
        float y = 3;
        //várias linhas
        for (int j = 1; j <= linhas; j++)
        {
            //cria linha
            for (int i = 1; i <= 6; i++)
            {
                //cria bloco
                if(j == linhas)
                    Instantiate(bloco1, new Vector2(x, y), Quaternion.identity);
                else
                    Instantiate(bloco, new Vector2(x, y), Quaternion.identity);
                x += 1.2f; //próximo bloco
            }
            //reposiciona
            y -= 0.7f;
            x = -3.1f;
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
