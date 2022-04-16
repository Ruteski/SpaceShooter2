using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D meuRB;
    [SerializeField] private float velocidade = 5f;
    [SerializeField] private GameObject goTiro;
    [SerializeField] private Transform posTiro;
    [SerializeField] private int vida = 3;
    [SerializeField] private GameObject goExplosao;
    [SerializeField] private float velcidadeTiro = 6f;

    [SerializeField] private float xMin = -8.3f;
    [SerializeField] private float xMax = 8.3f;
    [SerializeField] private float yMin = -4.4f;
    [SerializeField] private float yMax = 4.4f;

    private Vector2 minhaVelocidade;
    private float horizontal;
    private float vertical;
    

    // Start is called before the first frame update
    void Start()
    {
        meuRB = GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void Update() {
        minhaVelocidade = Direcao();

        Atirando();
    }

    private void FixedUpdate() {
        Movendo();
    }

    private void Movendo() {
        //passando a minha velocidade para o rb
        meuRB.velocity = minhaVelocidade * velocidade;

        //limitando a posicao da tela
        //funcao Clamp
        float meuX = Mathf.Clamp(transform.position.x, xMin, xMax);
        float meuY = Mathf.Clamp(transform.position.y, yMin, yMax);


        //aplicando minha posicao X
        transform.position = new Vector3(meuX, meuY);
    }

    private Vector2 Direcao() {
        //pegando o input horizontal
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Vector2 minhaVelocidade = new Vector2(horizontal, vertical);

        //normalizando para que a velocidade diagonal seja a msm da velocidade nos eixos
        minhaVelocidade.Normalize();
        return minhaVelocidade;
    }

    private void Atirando() {
        if (Input.GetButtonDown("Fire1")) {
            GameObject tiro = Instantiate(goTiro, posTiro.position, transform.rotation);

            //dar direcao e velocidade para o rb do tiro
            tiro.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, velcidadeTiro);
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
