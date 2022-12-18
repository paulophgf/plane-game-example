using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D _planeRigidbody;
    [SerializeField] private float speed = 5f;
    private float _planeLimit = 5.7f;
    [SerializeField] private GameObject smoke;
    
    // Start is called before the first frame update
    void Start()
    {
        _planeRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       PlaneUp();
       HeightLimit();
       CheckPlaneLimit();
    }

    void PlaneUp()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _planeRigidbody.velocity = Vector2.up * speed;
            GameObject myPuff = Instantiate(smoke, transform.position, Quaternion.identity);
            Destroy(myPuff, 2f);
        }
    }

    void HeightLimit()
    {
        if (_planeRigidbody.velocity.y < -speed)
        {
            _planeRigidbody.velocity = Vector2.down * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        SceneManager.LoadScene(0);
    }
    
    private void CheckPlaneLimit()
    {
        if (transform.position.y < -_planeLimit || transform.position.y > _planeLimit)
        {
            SceneManager.LoadScene(0);
        }
    }
    
}
