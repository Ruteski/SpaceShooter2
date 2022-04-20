using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacaoBoss : MonoBehaviour
{
    [SerializeField] private GameObject boss;

    public void CriaBoss() {
        Instantiate(boss, transform.position, transform.rotation);
    }
}
