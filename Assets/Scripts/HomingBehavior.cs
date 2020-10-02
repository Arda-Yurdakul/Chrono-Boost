using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HomingBehavior : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        Vector3 dist = transform.position - player.transform.position;
        transform.LookAt(dist);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Spaceship")
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(600 * (player.transform.position - transform.position));
        }

        else
            print("hey");
    }

    

}
