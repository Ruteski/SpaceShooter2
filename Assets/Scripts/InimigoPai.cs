using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoPai : MonoBehaviour
{
    [SerializeField] protected float velocidade;
    [SerializeField] protected int vida;
    [SerializeField] protected GameObject goExplosao;
    [SerializeField] protected GameObject goTiro;//meu tiro
    [SerializeField] protected float velocidadeTiro = 5f;
    [SerializeField] protected int pontos = 10;
    [SerializeField] protected float esperaTiro = 1f;
    [SerializeField] protected GameObject goPowerUp;
    [SerializeField] protected float itemRate = 0.9f;

    public void PerdeVida(int dano) {
        if (gameObject.transform.position.y < 5f){
            vida -= dano;

            if (vida <= 0) {
                Destroy(gameObject);
                Instantiate(goExplosao, transform.position, transform.rotation);

                //ganhando pontos
                var gerador = FindObjectOfType<GeradorInimigos>();
                gerador.DiminuiQuantidade();
                gerador.GanhaPontos(pontos);

                DropaItem();
            }
        }
    }

    private void DropaItem() {
        float chance = Random.Range(0f, 1f);

        if (chance > itemRate) { // 10% de chance de dropar o item
            GameObject powerUp = Instantiate(goPowerUp, transform.position, transform.rotation);
            Destroy(powerUp, 3f);

            //criando direcao aleatorio 
            Vector2 dir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            powerUp.GetComponent<Rigidbody2D>().velocity = dir;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("DestroiInimigo")) {
            Destroy(gameObject);

            var gerador = FindObjectOfType<GeradorInimigos>();
            gerador.DiminuiQuantidade();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        //if (other.gameObject.CompareTag("Jogador")) {  // essa é outra forma de pegar a tag
        if (other.collider.CompareTag("Jogador")) {
            Destroy(gameObject);

            var gerador = FindObjectOfType<GeradorInimigos>();
            gerador.DiminuiQuantidade();

            Instantiate(goExplosao, transform.position, transform.rotation);

            other.gameObject.GetComponent<PlayerController>().PerdeVida(1);
        }
    }
}
