using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject bulletPrefab;
    private bool onCoolDown;
    
    
    // Start is called before the first frame update
    void Start()
    {
        onCoolDown = true;
        Invoke("resetCoolDown", 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 alignment = (player.transform.position - transform.position);
        alignment.Normalize();
        if (onCoolDown)
            return;
        else
        {
            onCoolDown = true;
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            AudioManager.Instance.PlayPew();
            bullet.GetComponent<Rigidbody>().AddForce(alignment * 1000);
            Invoke("resetCoolDown", 2.0f);
        }
        

    }

    public void resetCoolDown()
    {
        onCoolDown = false;
    }
}
