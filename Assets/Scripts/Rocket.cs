using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody rigidbody;
    AudioSource audioSource;
    [SerializeField] private float thrust;
    [SerializeField] private float rotation;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }



    private void ProcessInput()
    {
        if (Input.GetKey("space"))
        {
            rigidbody.AddRelativeForce(0, thrust, 0);
            if (!audioSource.isPlaying)
                audioSource.Play();
        }
        else
            audioSource.Stop();



        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * rotation);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back * Time.deltaTime * rotation);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.tag)
        {
            case ("Friendly"):
                print("You have a friend in me");
                break;
            default:
                print("Miss Keisha!");
                break;
        }
    }
}
