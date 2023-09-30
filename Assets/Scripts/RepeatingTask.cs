using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingTask : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;

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
        var random = Random.Range(0, enemies.Length);
        var randomX = Random.Range(-x,x);
        Instantiate(enemies[random] , new Vector3(randomX,y,0), transform.rotation);
    }
}
