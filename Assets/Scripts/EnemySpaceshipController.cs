using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemySpaceshipController : MonoBehaviour
{
    [SerializeField]
    private float _speedY = -1.0f;

    private float _speedX = 0;

    [SerializeField]
    private float x = 6.1f;

    private Rigidbody2D _rb2d;

    private Text _score;

    public AudioClip explosionSound; // - RAVEL adicionando o som 

    private bool _passouDaMetade = false;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 20.0f);
        _rb2d = GetComponent<Rigidbody2D>();
        _score = GameObject.Find("Score").GetComponent<Text>();
        _rb2d.velocity = new Vector2(_speedX, _speedY);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!_passouDaMetade && Mathf.Abs(_rb2d.position.y - 0.0f) < 0.1f)
        {
        
            // Verifica a posição X do jogador e define a direção
            GameObject jogador = GameObject.FindWithTag("Player");
            if (jogador != null)
            {
                if (jogador.transform.position.x >= 0.0f)
                {
                    _speedX = 1;
                }
                else
                {
                    _speedX = -1;
                }
            }

            // Aplica a velocidade diretamente no Rigidbody2D
            _rb2d.velocity = new Vector2(_speedX, _speedY);
            _passouDaMetade = true;

        } else if (_rb2d.position.x < -x) {
            _speedX = 1;
            _rb2d.velocity = new Vector2(_speedX, _speedY);
        } else if (_rb2d.position.x > x) {
            _speedX = -1;
            _rb2d.velocity = new Vector2(_speedX, _speedY);
        }
        /*
        else
        {
            _speedX = 0; // Pare o movimento horizontal se estiver abaixo de -0.1 em Y
        }
        */
        
    }

    public void Destruir() {
        // Pontuacao que a nave destruida vai gerar para o jogador
        PontuacaoController.Pontuacao++;
        _score.text = "Pontos: " + PontuacaoController.Pontuacao.ToString();

        // RAVEL - Reproduzir o som da explosão
        if (explosionSound != null)
        {
            AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, 0.3f);
        }
        Destroy(this.gameObject);
    }
}
