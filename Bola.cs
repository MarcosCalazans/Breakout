// puxa as bibliotecas do unity que serão utilizadas neste script:
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour { // os dois pontos significa que a classe "Bola" herda da classe "MonoBehaviour"
    private Rigidbody2D rb; // relembrando (nunca se esqueça): private só pode ser acessado pela mesma classe (se nada é usado, é automaticamente private), funções internas e locais da classe podem acessar
    public float forca; // relembrando (nunca se esqueça): public pode ser acessado por qualquer outro código e aparece no unity pra vc editar
    public GameObject bloco;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>(); // pega o componente "Rigidbody2D" do game object ao qual for atribuído este script
        rb.AddForce(Vector2.up * forca);
        // o único parâmetro obrigatório na função "AddForce" é o vetor que representa a direção e a força, ou seja, cima (up) multiplicado pela variável com o valor da força https://www.youtube.com/watch?v=MBDWTjn05eg
        // se tivesse mais um parâmetro na função, seria separado por uma vírgula
        // o que é "Vector2"? https://www.youtube.com/watch?v=0KUhzde-INY
	}

    void OnCollisionEnter2D(Collision2D collision) // "void" significa que a função não tem retorno, dentro do parênteses estão os parâmetros que ela recebe (um objeto da classe "Collision2D")
    {
        if(collision.gameObject.name == "jogador") // se o nome do objeto em que colide for "jogador" executa o código entre chaves abaixo
        {
            float dist = transform.position.x - collision.gameObject.transform.position.x;
            // pega a posição no eixo x do objeto ao qual foi atribuído este script e subtrai a posição no eixo x do gameobject "collision" que a função recebe como parâmetro (ou seja, tem que ter um Collider2D no objeto para essa função funcionar com ele)
            // pega o valor da variável "x" dentro de "position" do componente "transform" do game object collision 
            // quando tem pontos é sempre pegando uma coisa dentro da outra, dentro da outra, dentro da outra...
            rb.AddForce(Vector2.right * dist*forca);
            Debug.Log(dist); // imprime o valor da variável "dist" no console
        }

        if (collision.gameObject.tag == "casca") // se o objeto ao qual este script foi atribuído (bola) se colidir com um objeto com a tag "casca", executa o código entre parênteses
        {
            Instantiate(bloco, collision.gameObject.transform.position, Quaternion.identity);
            // "Instantiate" clona o objeto "bloco", seu segundo parâmetro é a posição e o terceiro parâmetro (Quaternion.identity) é a rotação (no caso, zero)
            Destroy(collision.gameObject); // remove o objeto da existência para não ocupar mais processamento
            Globais.score += 10; // adiciona dez pontos à pontuação
        }

        if (collision.gameObject.tag == "bloco") // se o objeto ao qual este script foi atribuído (bola) se colidir com um objeto com a tag "bloco", executa o código entre parênteses
        {
            Destroy(collision.gameObject); // remove o objeto da existência para não ocupar mais processamento
            Globais.score += 10; // adiciona dez pontos à pontuação
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        //testa se bateu no chao
        if(collision.gameObject.name == "chao")
        {
            if (Globais.vidas > 0)
            {
               
                Invoke("CriarBola", 1); //atrasa a chamada
                transform.position = new Vector2(0, 1000); //x e y fora da tela
            }
        }
    }

    void CriarBola()
    {
        Globais.vidas--;
        //valores iniciais da bola
        transform.position = Vector2.zero;
        rb.velocity = Vector2.zero;
        rb.AddForce(Vector2.up * forca);
    }

    // Update is called once per frame
    void Update () {
        
	}
}