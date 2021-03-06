using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject Artifact;
    public float speed = 1;

    private void Start()
    {
        Artifact = GameObject.Find("Artifact");
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Artifact.transform.position, step);
    }
}
