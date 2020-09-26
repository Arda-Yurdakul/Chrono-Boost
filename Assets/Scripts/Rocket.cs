using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
    Rigidbody rigidbody;
    
    [SerializeField] private float thrust;
    [SerializeField] private float rotation;

    [SerializeField] private ParticleSystem engineParticles;
    [SerializeField] private ParticleSystem winParticles;
    [SerializeField] private ParticleSystem deathParticles;

    private bool hasCollided;
    private enum State { Alive, Dead, Transcending }
    State state;



    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        state = State.Alive;
        hasCollided = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (state != State.Alive) { return; }
        ProcessInput();
    }



    private void ProcessInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Time.timeScale == 1f)
                Time.timeScale = 0.3f;
            else
                Time.timeScale = 1f;
        }

        if (Input.GetKey("space"))
        {
            rigidbody.AddRelativeForce(0, thrust * Time.deltaTime, 0);
            AudioManager.Instance.PlayThruster();
            if(!engineParticles.isPlaying)
                engineParticles.Play();
        }
        else
        {
            AudioManager.Instance.StopPlaying();
            engineParticles.Stop();
        }

        rigidbody.freezeRotation = true;

        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * rotation);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back * Time.deltaTime * rotation);
        }

        rigidbody.freezeRotation = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!hasCollided)
        {
            switch (collision.gameObject.tag)
            {
                case ("Friendly"):
                    print("You have a friend in me");
                    break;
                case ("finish"):
                    if(collision.gameObject.transform.position.y < transform.position.y)
                    {
                        AudioManager.Instance.PlayWinJingle();
                        winParticles.Play();
                        state = State.Transcending;
                        hasCollided = true;
                        Invoke("NextLevel", 1.0f);
                    }
                    break;
                default:
                    AudioManager.Instance.PlayDeathExplosion();
                    deathParticles.Play();
                    state = State.Dead;
                    hasCollided = true;
                    Invoke("RestartLevel", 1.0f);
                    break;
            }
        }
        
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
