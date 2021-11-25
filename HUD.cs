using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //precisa importar

public class HUD : MonoBehaviour {

    public Text score; //referência para objeto na cena
    public Text vidas;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        score.text = "Score: " + Globais.score; //atualiza pontos
        vidas.text = "Vidas: " + Globais.vidas;
	}
}
