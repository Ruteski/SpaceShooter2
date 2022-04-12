using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroController : MonoBehaviour
{
    [SerializeField] private GameObject impactoTiro;
    private Rigidbody2D meuRB;

    // Start is called before the first frame update
    void Start()
    {
        meuRB = GetComponent<Rigidbody2D>();
        //meuRB.velocity = new Vector2(0f, velocidade);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Inimigo")) {
            collision.GetComponent<InimigoPai>().PerdeVida(1);
        }

        if (collision.CompareTag("Jogador")) {
            collision.GetComponent<PlayerController>().PerdeVida(1);
        }

        Destroy(gameObject);
        Instantiate(impactoTiro, transform.position, transform.rotation);
    }
}
