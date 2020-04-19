using UnityEngine;
using TMPro;
using System.Collections;
using System;
using UnityEngine.UI;

public class Artifact : MonoBehaviour
{
    public int health = 100;
    public TextMeshProUGUI LivesText;
    public TextMeshProUGUI BoostActivatedText;
    public GameObject[] spawnPoints;
    public GameObject Fader;
    public Image fadeIn;
    public Image Button1;
    public Image Button2;
    public TextMeshProUGUI Text1;
    public TextMeshProUGUI Text2;
    public TextMeshProUGUI TimerText;
    public AudioSource ArtifactTakeDamage;


    private void Start()
    {
        StartCoroutine(IdleDamage());
        var HealthText = health.ToString();
        LivesText.text = "Artifact Lives Left: " + HealthText;
        fadeIn.canvasRenderer.SetAlpha(0f);

        Button1.canvasRenderer.SetAlpha(0f);

        Button2.canvasRenderer.SetAlpha(0f);
        Text1.canvasRenderer.SetAlpha(0f);
        Text2.canvasRenderer.SetAlpha(0f);
    }

    void Update()
    {
        if (health <= 0)
        {
            if(health <= -1)
            {
                health = 0;
                LivesText.text = "Artifact Lives Left: 0";
            }
            
            DestroyGameObjects();
            StartCoroutine(ActualFade());
        }

        ActivateBoost();
    }


    public void DestroyGameObjects()
    {
        

        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int e = 0; e < enemies.Length; e++)
            Destroy(enemies[e]);

        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        for(int i = 0; i<spawnPoints.Length; i++)
        Destroy(spawnPoints[i]);
    }

    private void ActivateBoost()
    {
        if (health >= 20)
        {
            if (Input.GetButtonDown("B"))
            {
                health -= 15;
                var HealthText = health.ToString();
                LivesText.text = "Artifact Lives Left: " + HealthText;
                StartCoroutine(Boost());
            }
        }
    }
    IEnumerator Boost()
    {
        FindObjectOfType<PlayerMovementController>().moveSpeed += 10f;
        BoostActivatedText.text = "Boost Activated for 30 seconds!";
        yield return new WaitForSeconds(3);
        BoostActivatedText.text = "";
        yield return new WaitForSeconds(30);
        FindObjectOfType<PlayerMovementController>().moveSpeed -= 10f;
        StopCoroutine(Boost());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            health -= 10;
            var HealthText = health.ToString();
            Destroy(collision.gameObject);
            LivesText.text = "Artifact Lives Left: " + HealthText;
            ArtifactTakeDamage.Play();
        }
    }
    IEnumerator ActualFade()
    {
        GetComponent<Animator>().SetTrigger("DeathTrigger");
        yield return new WaitForSeconds(5);
        TimerText.CrossFadeAlpha(0, 1, false);
        Fader.SetActive(true);
        fadeIn.CrossFadeAlpha(1, 2.5f, false);
        Button1.CrossFadeAlpha(1, 1, false);
        Button2.CrossFadeAlpha(1, 1, false);
        Text1.CrossFadeAlpha(1, 1, false);
        Text2.CrossFadeAlpha(1, 1, false);
    }

    IEnumerator IdleDamage()
    {
        yield return new WaitForSeconds(5);
        health -= 1;
        LivesText.text = "Artifact Lives Left: " + health.ToString();
        StartCoroutine(IdleDamage());
    }

}
