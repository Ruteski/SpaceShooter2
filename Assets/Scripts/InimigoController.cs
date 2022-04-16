using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoController : InimigoPai
{
    private Rigidbody2D meuRB;

    //pegando o transforme da posicao do meu tiro
    [SerializeField] private Transform posTiro;

    // Start is called before the first frame update
    void Start()
    {
        meuRB = GetComponent<Rigidbody2D>();
        meuRB.velocity = new Vector2(0f, velocidade);

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
        //bool visivel = GetComponentInChildren<SpriteRenderer>().isVisible;

        if (gameObject.transform.position.y < 5f) {
            //diminui tempo de espera para atirar
            esperaTiro -= Time.deltaTime;

            if (esperaTiro < 0f) {
                //instanciando o tiro
                GameObject tiro = Instantiate(goTiro, posTiro.position, transform.rotation);
                tiro.GetComponent<Rigidbody2D>().velocity = Vector2.down * velocidadeTiro;
                esperaTiro = Random.Range(1.5f, 2f);
            }
        }
    }
}
