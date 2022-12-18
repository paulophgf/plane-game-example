using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] private float speed = 4f;
    [SerializeField] private GameController game;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 6f);
        game = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * (Time.deltaTime * (speed + game.GetLevel()));
    }
    
}
