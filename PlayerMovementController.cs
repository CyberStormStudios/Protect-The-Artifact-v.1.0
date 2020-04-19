using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public TextMeshProUGUI LivesText;
    public TextMeshProUGUI NotificationText;
    public AudioSource EnemyKill;
    public static bool SlasherUnlocked = false;
    public int SlasherTracker = 0;
    public ParticleSystem deathParticles;
   

    public float Speed { get; private set; }

    private void Start()
    {
        EnemyKill = GetComponent<AudioSource>();
    }
    public void Update()
    {
        if(SlasherTracker >= 50)
        {
            SlasherUnlocked = true;
            StartCoroutine(SlasherUnlock());
        }
    }
    IEnumerator SlasherUnlock()
    {
        NotificationText.text = "Slasher Achivement Unlocked";
        yield return new WaitForSeconds(3);
        NotificationText.text = "";
        StopCoroutine(SlasherUnlock());
    }

    private void FixedUpdate()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        //Speed = horizontal;

        Vector3 movement = new Vector3(horizontal, vertical);

        transform.position += movement * Time.deltaTime * moveSpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        { 
            Destroy(collision.gameObject);
            EnemyKill.Play();
            Instantiate(deathParticles, transform.position, Quaternion.identity);
            if(SlasherUnlocked == false)
            {
                SlasherTracker += 1;
            }
            else
            {
                SlasherTracker += 0;
            }
            
            if(FindObjectOfType<Artifact>().health <= 99)
            {
                FindObjectOfType<Artifact>().health += 1;
                LivesText.text = "Artifact Lives Left: " + FindObjectOfType<Artifact>().health.ToString();
            }
            else
            {
                FindObjectOfType<Artifact>().health += 0;
            }
            
        }


    }
}
