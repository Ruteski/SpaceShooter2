using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacaoBoss : MonoBehaviour
{
    [SerializeField] private GameObject boss;

    private void OnDestroy() {
        Instantiate(boss, transform.position, transform.rotation);
    }
}
