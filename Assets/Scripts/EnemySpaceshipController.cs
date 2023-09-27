using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpaceshipController : MonoBehaviour
{
    [SerializeField]
    private float _speedY = -0.5f;

    private Rigidbody2D _rb2d;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 20.0f);
        _rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
       _rb2d.MovePosition(_rb2d.position + new Vector2(0,_speedY)*Time.deltaTime);
    }
}
