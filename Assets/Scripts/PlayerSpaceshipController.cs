using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSpaceshipController : MonoBehaviour
{
    
    [SerializeField]
    private float _speed = 3.0f; // Velocidade da nave do jogador
    private float _x, _y;
    private Text _score;

    [SerializeField]
    private GameObject _resetButton;

    // Rigidbody2D necessario para movimentar a nave usando a fisica
    private Rigidbody2D _rb2d;

    // Objeto a ser gerado para simular tiro da nave
    public GameObject prefabLaser;

    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Pegar o valor da movimentacao horizontal e vertical entre 0 e 1
        _x = Input.GetAxis("Horizontal");
        _y = Input.GetAxis("Vertical");

        // Ao clicar com o botao esquerdo do mouse, criar um objeto prefabLaser para simular o tiro da nave
        if(Input.GetMouseButtonDown(0)){
            Instantiate(prefabLaser, transform.position + new Vector3(0,1,0), transform.rotation);
        }
    }

    // Quando envolve fisica, usar o FixedUpdate
    // FixedUpdate tem o Time.deltaTime constante
    void FixedUpdate(){
        // Movimentacao pela fisica. 
        _rb2d.MovePosition(_rb2d.position + new Vector2(_x,_y)*_speed*Time.deltaTime);
    }

    // Detectar quando algum outro objeto colidir com a nave do jogador
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Laser")){
            _score = GameObject.Find("Score").GetComponent<Text>();
            _score.text = "Game Over";
            Destroy(other.gameObject);
            Destroy(this.gameObject);

            _resetButton.SetActive(true);
        }
    }

}
