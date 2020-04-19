using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectObject : MonoBehaviour
{
    [SerializeField]private float time = 0.8f;

    void Start()
    {
        Destroy(gameObject, time);
    }

}
