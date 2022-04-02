using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoController : MonoBehaviour
{
    private Rigidbody2D meuRB;
    [SerializeField] private float velocidade = -3f;

    // Start is called before the first frame update
    void Start()
    {
        meuRB = GetComponent<Rigidbody2D>();
        meuRB.velocity = new Vector2(0f, velocidade);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}