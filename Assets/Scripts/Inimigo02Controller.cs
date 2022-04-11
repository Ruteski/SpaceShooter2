using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo02Controller : InimigoPai
{
    private Rigidbody2D meuRB;

    // Start is called before the first frame update
    void Start()
    {
        meuRB = GetComponent<Rigidbody2D>();
        //meuRB.velocity = new Vector2(0f, velocidade);
        meuRB.velocity = Vector2.down * -velocidade;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
