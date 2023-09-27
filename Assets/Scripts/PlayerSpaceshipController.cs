using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpaceshipController : MonoBehaviour
{
    // Start is called before the first frame update
    private float _speed = 3.0f;
    private float _x, _y;

    private Rigidbody2D _rb2d;

    public GameObject prefabLaser;

    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        print("Hello World!");
    }

    // Update is called once per frame
    void Update()
    {
        _x = Input.GetAxis("Horizontal");
        _y = Input.GetAxis("Vertical");

        //Esse aqui só retorna 0 ou 1
        //var x = Input.GetAxisRaw("Horizontal");
        //var y = Input.GetAxisRaw("Vertical");

        transform.Translate(_x*_speed*Time.deltaTime, _y*_speed*Time.deltaTime,0);

        if(Input.GetMouseButtonDown(0)){
            Instantiate(prefabLaser, transform.position + new Vector3(0,1,0), transform.rotation);
        }

    }

    void FixedUpdate(){
        _rb2d.MovePosition(_rb2d.position + new Vector2(_y,_x)*_speed*Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        print("Trigger Enter");
    }

    void OnTriggerStay2D(Collider2D other)
    {
        print("Trigger Stay");
    }

}
