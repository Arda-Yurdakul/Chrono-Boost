using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{

    [SerializeField] private Vector3 turnDirection1;
    [SerializeField] private Vector3 turnDirection2;
    [SerializeField] private float turnSpeed;
    private enum Rotate {left, right}
    Rotate rotate;

    private void Start()
    {
        rotate = Rotate.right;
        InvokeRepeating("ChangeDirection", 5f, 10f);  //1s delay, repeat every 1s
    }
    // Update is called once per frame
    void Update()
    {
        switch(rotate)
        {
            case(Rotate.right):
                transform.Rotate(turnDirection1 * Time.deltaTime * turnSpeed);
                break;
            case (Rotate.left):
                transform.Rotate(turnDirection2 * Time.deltaTime * turnSpeed);
                break;
        }
           
    }

    public void ChangeDirection()
    {
        if (rotate == Rotate.left)
            rotate = Rotate.right;

        else if (rotate == Rotate.right)
            rotate = Rotate.left;
    }
}
