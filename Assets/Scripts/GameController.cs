using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private float timer = 1f;
    [SerializeField] private GameObject obstacle;
    [SerializeField] private Vector3 position;
    [SerializeField] private Text textPoints;
    [SerializeField] private Text textLevel;
    [SerializeField] private float pointsToNextlevel;
    [SerializeField] private AudioClip levelUpSound;
    private Vector3 _cameraPosition;
    private float _innerTime;
    private float _limit_up = 2.7f;
    private float _limit_down = -0.6f;
    private float _points;
    private int _level = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        _innerTime = timer;
        _cameraPosition = Camera.main.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        GeneratePoints();
        CreateObstacle();
        CalculateLevel();
    }

    private void GeneratePoints()
    {
        _points += Time.deltaTime;
        textPoints.text = "Pontos = " + Mathf.RoundToInt(_points);
        textLevel.text = "Level =" + _level + "  (Next level: " + Mathf.RoundToInt(pointsToNextlevel) + ")";
    }
    
    private void CreateObstacle()
    {
        if (_innerTime < 0)
        {
            position.y = Random.Range(0, 2) == 0 ? _limit_down : _limit_up;
            Instantiate(obstacle, position, Quaternion.identity);
            _innerTime = Random.Range(1, 3);
        }

        _innerTime -= Time.deltaTime;
    }

    private void CalculateLevel()
    {
        if (_points >= pointsToNextlevel)
        {
            _level++;
            pointsToNextlevel *= 2;
            AudioSource.PlayClipAtPoint(levelUpSound, _cameraPosition);
        }
    }

    public int GetLevel()
    {
        return _level;
    }
    
}
