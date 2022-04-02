using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D meuRB;
    [SerializeField] private float velocidade = 5f;
    [SerializeField] private GameObject goTiro;

    // Start is called before the first frame update
    void Start()
    {
        meuRB = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        //pegando o input horizontal
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 minhaVelocidade = new Vector2(horizontal, vertical);

        //normalizando para que a velocidade diagonal seja a msm da velocidade nos eixos
        minhaVelocidade.Normalize();

        //passando a minha velocidade para o rb
        meuRB.velocity = minhaVelocidade * velocidade;

        if (Input.GetButtonDown("Fire1")) Instantiate(goTiro, transform.position, transform.rotation);
        
    }
}
