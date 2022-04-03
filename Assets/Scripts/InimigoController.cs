using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoController : MonoBehaviour
{
    private Rigidbody2D meuRB;
    [SerializeField] private float velocidade = -3f;
    private float esperaTiro = 1f;

    //meu tiro
    [SerializeField] private GameObject goTiro;

    //pegando o transforme da posicao do meu tiro
    [SerializeField] private Transform posTiro;

    [SerializeField] private int vida = 1;
    [SerializeField] private GameObject goExplosao;

    // Start is called before the first frame update
    void Start()
    {
        meuRB = GetComponent<Rigidbody2D>();
        meuRB.velocity = new Vector2(0f, velocidade);

        //espera tiro aleatoria
        esperaTiro = Random.Range(0.5f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        //checa se o sprite renderer esta visivel
        //pegando informação dos filhos
        bool visivel = GetComponentInChildren<SpriteRenderer>().isVisible;

        if (visivel) {
            //diminui tempo de espera para atirar
            esperaTiro -= Time.deltaTime;

            if (esperaTiro < 0f) {
                //instanciando o tiro
                Instantiate(goTiro, posTiro.position, transform.rotation);
                esperaTiro = Random.Range(1.5f, 2f);
            }
        }
    }

    public void PerdeVida(int dano) {
        vida -= dano;

        if (vida <= 0) { 
            Destroy(gameObject);
            Instantiate(goExplosao, transform.position, transform.rotation);
        }
    }
}
