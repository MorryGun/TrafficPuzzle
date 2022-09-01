using UnityEngine;

public class CarController : MonoBehaviour
{
    Rigidbody carRb;
    GameManager gameManager;
    AudioSource audioSource;

    [SerializeField] float speed = 1000;
    [SerializeField] float minSpeed = 900;
    [SerializeField] float maxSpeed = 2900;

    [SerializeField] ParticleSystem explosion;
    [SerializeField] AudioClip boostSound;
    [SerializeField] AudioClip coolSound;
    [SerializeField] AudioClip crashsound;

    int pointBoost = 10;
    float speedBoostModifier = 1.2f;
    float speedSlowDownModifier = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        carRb = gameObject.GetComponent<Rigidbody>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            carRb.AddForce(gameObject.transform.forward * speed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            gameManager.isGameActive = false;
            explosion.Play();
            audioSource.PlayOneShot(crashsound);
            gameManager.gameOverScreen.SetActive(true);
        }
        else if (collision.gameObject.CompareTag("Sensor"))
        {
            gameManager.score += pointBoost;
            Destroy(gameObject);
        }
    }

    private void OnMouseOver()
    {
        // Boost the car on left click
        if (Input.GetMouseButtonDown(0) && speed < maxSpeed)
        {
            speed *= speedBoostModifier;
            audioSource.PlayOneShot(boostSound);
        } else if (Input.GetMouseButtonDown(1) && speed > minSpeed)
        {
            // Slow the car down on right click
            speed *= speedSlowDownModifier;
            audioSource.PlayOneShot(coolSound);
        }
    }
}
