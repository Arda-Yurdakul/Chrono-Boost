using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour
{
    [SerializeField] private Vector3 MovementAmount;
    [SerializeField] private float period;
    //[SerializeField] [Range(0, 1)] private float MovementFactor;
    Vector3 initialPosition;
    const float tau = Mathf.PI * 2;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon)
            return;
        float cycles = Time.time / period;
        float rawSinWave = Mathf.Sin(cycles * tau);
        float movementFactor = (rawSinWave / 2f) + 0.5f;
        transform.position = initialPosition + (MovementAmount * movementFactor);
    }
}
