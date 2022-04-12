using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo02Controller : InimigoPai
{
    private Rigidbody2D meuRB;

    [SerializeField] private Transform posTiro;

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

    private void Atirando() {
        //checa se o sprite renderer esta visivel
        //pegando informação dos filhos
        bool visivel = GetComponentInChildren<SpriteRenderer>().isVisible;

        if (visivel) {
            //diminui tempo de espera para atirar
            esperaTiro -= Time.deltaTime;

            if (esperaTiro < 0f) {
                //instanciando o tiro
                GameObject tiro = Instantiate(goTiro, posTiro.position, transform.rotation);

                // encontrando o player na cena
                var player = FindObjectOfType<PlayerController>();

                // encontrando a direcao do player
                Vector2 direcao = player.transform.position - tiro.transform.position;

                //normalizando a velocidade dele
                direcao.Normalize();

                tiro.GetComponent<Rigidbody2D>().velocity = direcao * -velocidadeTiro;

                esperaTiro = Random.Range(2f, 4f);
            }
        }
    }
}
