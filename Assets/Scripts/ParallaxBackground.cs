using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private MeshRenderer _mr;
    
    // Start is called before the first frame update
    void Start()
    {
       _mr = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _mr.material.mainTextureOffset += new Vector2(0, _speed * Time.deltaTime);
    }
}
