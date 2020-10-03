using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] meshList;
    private int meshType;
    private int meshXlocation;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnMesh", 0f, 1f);  //1s delay, repeat every 2s
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnMesh()
    {
        meshType = Random.Range(0,3);
        meshXlocation = Random.Range(-7, 26);
        GameObject obstacle = Instantiate(meshList[meshType], new Vector3(meshXlocation,130,0), Quaternion.identity);
    }
}
