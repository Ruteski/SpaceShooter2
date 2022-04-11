using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoPai : MonoBehaviour
{
    [SerializeField] private float velocidade;
    [SerializeField] private int vida;
    [SerializeField] private GameObject goExplosao;

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
}
