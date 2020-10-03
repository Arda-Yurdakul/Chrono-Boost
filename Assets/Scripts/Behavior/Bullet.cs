using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float destroyTime;
    private float initialization;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, destroyTime);
        initialization = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        float lifeTime = Time.time - initialization;
        if (!collision.gameObject.CompareTag("Turret") && lifeTime > 0.1f && destroyTime == 5)
            Destroy(this.gameObject);
    }
}
