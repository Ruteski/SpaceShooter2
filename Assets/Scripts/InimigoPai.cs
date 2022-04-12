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
    protected float esperaTiro = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PerdeVida(int dano) {
        vida -= dano;

        if (vida <= 0) {
            Destroy(gameObject);
            Instantiate(goExplosao, transform.position, transform.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("DestroiInimigo")) {
            Destroy(gameObject);
        }
    }
}
