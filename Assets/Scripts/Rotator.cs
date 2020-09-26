using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private Vector3 turnDirection;
    [SerializeField] private float turnSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(turnDirection * Time.deltaTime * turnSpeed);
    }
}
