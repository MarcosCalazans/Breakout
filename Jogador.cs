using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour {
	public float velx;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float x;
        
		//verifica a tecla
		if(Input.GetKey(KeyCode.RightArrow))
				transform.Translate(velx, 0, 0);
		else if(Input.GetKey(KeyCode.LeftArrow))
				transform.Translate(-velx, 0, 0);

        //testa o limite
        x = Mathf.Clamp(transform.position.x, -3.25f, 3.25f);        
        //mudar a posição de forma absoluta
        transform.position = new Vector2(x, transform.position.y);

	}
}
