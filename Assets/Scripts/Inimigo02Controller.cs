using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo02Controller : InimigoPai
{
    private Rigidbody2D meuRB;

    [SerializeField] private Transform posTiro;
    [SerializeField] private float yMax = 2.8f;

    private bool mudouDirecao = false;

    // Start is called before the first frame update
    void Start()
    {
        meuRB = GetComponent<Rigidbody2D>();
        //meuRB.velocity = new Vector2(0f, velocidade);
        meuRB.velocity = Vector2.down * -velocidade;

        //espera tiro aleatoria
        esperaTiro = Random.Range(0.5f, 2f);
    }

    // Update is called once per frame
    void Update() {
        Atirando();
    }

    private void FixedUpdate() {
        Movendo();
    }

    private void Movendo() {
        if (transform.position.y <= yMax && !mudouDirecao) {
            if (transform.position.x > 0f) {
                meuRB.velocity = new Vector2(velocidade, velocidade);
                mudouDirecao = true;
            } else {
                // vai para a direita
                meuRB.velocity = new Vector2(velocidade * -1, velocidade);
                mudouDirecao = true;
            }
        }
    }

    private void Atirando() {
        //checa se o sprite renderer esta visivel
        //pegando informação dos filhos
        bool visivel = GetComponentInChildren<SpriteRenderer>().isVisible;

        if (visivel) {
            // encontrando o player na cena
            var player = FindObjectOfType<PlayerController>();

            if (player) {
                //diminui tempo de espera para atirar
                esperaTiro -= Time.deltaTime;

                if (esperaTiro < 0f) {
                    //instanciando o tiro
                    GameObject tiro = Instantiate(goTiro, posTiro.position, transform.rotation);

                    // encontrando a direcao do player
                    Vector2 direcao = player.transform.position - tiro.transform.position;

                    //normalizando a velocidade dele
                    direcao.Normalize();

                    tiro.GetComponent<Rigidbody2D>().velocity = direcao * -velocidadeTiro;

                    //dando o angulo que o tiro tem que estar(a conta do angulo é padrao)
                    /*float angulo = Mathf.Atan2(direcao.y, direcao.x);// retorna o valor em radiano
                    angulo = angulo * Mathf.Rad2Deg; // converte radianos em graus*/

                    float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;
                
                    //passando o angulo para o a sprite do tiro
                    tiro.transform.rotation = Quaternion.Euler(0f, 0f, angulo + 90f); 

                    esperaTiro = Random.Range(2f, 4f);
                }
            }
        }
    }
}
