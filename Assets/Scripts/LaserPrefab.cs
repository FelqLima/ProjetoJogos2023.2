using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaserPrefab : MonoBehaviour
{
    [SerializeField]
    private float _speedY = 10f;

    private Rigidbody2D _rb2d;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 0.7f);
        _rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
       _rb2d.MovePosition(_rb2d.position + new Vector2(0,_speedY)*Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy")){
            
            other.gameObject.GetComponent<EnemySpaceshipController>().Destruir();
            Destroy(this.gameObject);
        }
    }
}
