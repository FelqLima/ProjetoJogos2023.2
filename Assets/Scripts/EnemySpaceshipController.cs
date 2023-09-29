using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemySpaceshipController : MonoBehaviour
{
    [SerializeField]
    private float _speedY = -1.0f;

    private Rigidbody2D _rb2d;

    private Text _score;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 20.0f);
        _rb2d = GetComponent<Rigidbody2D>();
        _score = GameObject.Find("Score").GetComponent<Text>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
       _rb2d.MovePosition(_rb2d.position + new Vector2(0,_speedY)*Time.deltaTime);
    }

    public void Destruir() {
        // Pontuacao que a nave destruida vai gerar para o jogador
        PontuacaoController.Pontuacao++;
        _score.text = "Pontos: " + PontuacaoController.Pontuacao.ToString();
        Destroy(this.gameObject);
    }
}
