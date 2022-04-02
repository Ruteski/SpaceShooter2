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
        //diminui tempo de espera para atirar
        esperaTiro -= Time.deltaTime;   

        if (esperaTiro < 0f) {
            //instanciando o tiro
            Instantiate(goTiro, transform.position, transform.rotation);
            esperaTiro = Random.Range(1.5f, 2f);
        }    

    }
}
