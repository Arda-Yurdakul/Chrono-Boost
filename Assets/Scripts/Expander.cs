﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expander : MonoBehaviour
{
    [SerializeField] private float finalSize;
    [SerializeField] private float period;
    [SerializeField] private int[] dir;
    //[SerializeField] [Range(0, 1)] private float MovementFactor;
    Vector3 initialSize;
    const float tau = Mathf.PI * 2;

    // Start is called before the first frame update
    void Start()
    {
        initialSize = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon)
            return;
        float cycles = Time.time / period;
        float rawSinWave = Mathf.Sin(cycles * tau);
        float movementFactor = (rawSinWave / 2f) * Time.timeScale;
        transform.localScale += new Vector3(dir[0],dir[1],dir[2]) * ((finalSize * movementFactor) / 50);
    }
}
