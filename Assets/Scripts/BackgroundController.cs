using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BackgroundController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed;
    private Renderer _settings;
    private float _offsetX;
    private Vector2 _textureOffset;
    void Start()
    {
        _settings = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _offsetX += (Time.deltaTime * speed);
        _textureOffset.x = _offsetX;
        _settings.material.mainTextureOffset = _textureOffset;
    }
}
