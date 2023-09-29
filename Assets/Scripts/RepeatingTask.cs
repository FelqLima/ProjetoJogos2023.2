using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingTask : MonoBehaviour
{
    [SerializeField]
    public GameObject enemy;

    [SerializeField]
    private float x = 6;
    
    private float y = 5;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("NewEnemy", 3.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NewEnemy()
    {
        Instantiate(enemy, new Vector3(Random.Range(-x,x),y,0), transform.rotation);
    }
}
