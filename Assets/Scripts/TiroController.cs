using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroController : MonoBehaviour
{
    [SerializeField] private float velocidade = 10f;
    private Rigidbody2D meuRB;

    // Start is called before the first frame update
    void Start()
    {
        meuRB = GetComponent<Rigidbody2D>();

        meuRB.velocity = new Vector2(0f, velocidade);

        Destroy(meuRB, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
