using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] private Vector3 finalTransform;
    [SerializeField] float speed;

    private void Start()
    {
          
    }
    // Update is called once per frame
    void Update()
    {
        print("Hey");
        transform.position  = Vector3.MoveTowards(transform.position, finalTransform, speed * Time.deltaTime);
    }
}
