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

    // Start is called before the first frame update
    void Start()
    {
        meuRB = GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void Update() {
        Movendo();

        Atirando();
    }

    private void Movendo() {
        //pegando o input horizontal
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 minhaVelocidade = new Vector2(horizontal, vertical);

        //normalizando para que a velocidade diagonal seja a msm da velocidade nos eixos
        minhaVelocidade.Normalize();

        //passando a minha velocidade para o rb
        meuRB.velocity = minhaVelocidade * velocidade;
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
