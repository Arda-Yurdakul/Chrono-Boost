using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class Rocket : MonoBehaviour
{
    Rigidbody rigidbody;
    
    [SerializeField] private float thrust;
    [SerializeField] private float rotation;
    

    [SerializeField] private ParticleSystem engineParticles;
    [SerializeField] private ParticleSystem winParticles;
    [SerializeField] private ParticleSystem deathParticles;
    [SerializeField] private Slider fuelBar;
    [SerializeField] private Slider slowBar;
    [SerializeField] private float fuel;

    private int bulletTimeLeft;
    private bool hasCollided;
    public enum State { Alive, Dead, Transcending }
    public State state;



    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        state = State.Alive;
        hasCollided = false;
        fuelBar.maxValue = fuel;
        bulletTimeLeft = 2;
        slowBar.maxValue = 2;
        print(PlayerPrefs.GetInt("HighestLevel"));
    }

    // Update is called once per frame
    void Update()
    {
        if (state != State.Alive) { return; }
        ProcessInput();
        fuelBar.value = fuel;
        slowBar.value = bulletTimeLeft;
    }



    private void ProcessInput()
    {
        if (CrossPlatformInputManager.GetButtonDown("Chrono_Button") && bulletTimeLeft > 0 && Time.timeScale == 1)
        {
            AudioManager.Instance.PlayBulletTime();
            bulletTimeLeft -= 1;
            BulletTime();             
        }

        else if (CrossPlatformInputManager.GetButton("Boost_Button") && fuel > 0)
        {
            rigidbody.AddRelativeForce(0, thrust * Time.deltaTime, 0);
            AudioManager.Instance.PlayThruster();
            fuel -= 1 * Time.deltaTime;
            if(!engineParticles.isPlaying && Time.timeScale != 0)
                engineParticles.Play();
        }

        if(CrossPlatformInputManager.GetButtonUp("Boost_Button"))
        {
            AudioManager.Instance.StopPlaying();
            engineParticles.Stop();
        }

        rigidbody.freezeRotation = true;

        if(CrossPlatformInputManager.GetButton("Left_Button"))
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * rotation);
        }

        else if (CrossPlatformInputManager.GetButton("Right_Button"))
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
                    break;
                case ("finish"):
                    if(collision.gameObject.transform.position.y + 0.5f < transform.position.y)
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
        int completedLevel = SceneManager.GetActiveScene().buildIndex - 1;
        int highestCompletedLevel = PlayerPrefs.GetInt("HighestLevel");
        if(completedLevel > highestCompletedLevel)
            PlayerPrefs.SetInt("HighestLevel", completedLevel);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BulletTime()
    {
        Time.timeScale = 0.3f;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
        Invoke("ResetBulletTime", 1f);
    }

    public void ResetBulletTime()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02F;
    }
}
