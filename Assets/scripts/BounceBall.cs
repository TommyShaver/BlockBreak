using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BounceBall : MonoBehaviour
{
    [SerializeField] float _minY = -5.5f;
    [SerializeField] float _maxVelocity = 15f;

    Rigidbody2D rb;

    int _score;
    int _lives = 5;
    public TextMeshProUGUI _scoreText;
    public GameObject[] _livesImage;
    public GameObject _gameOverPanel;
    public GameObject _winnerPanel;

    int _blockCount;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _blockCount = FindObjectOfType<LevelGenerator>().transform.childCount;
       
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < _minY)
        {
            if(_lives <= 0)
            {
                GameOver();

            }
            else
            {
                transform.position = Vector3.zero;
                rb.velocity = Vector3.zero;
                _lives--;
                _livesImage[_lives].SetActive(false);
            }
        }
        if (rb.velocity.magnitude > _maxVelocity)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, _maxVelocity);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Brick"))
        { 
            Destroy(collision.gameObject);
            _score += 5;
            _scoreText.text = _score.ToString("00000");
            _blockCount--;
            if(_blockCount <= 0)
            {
                _winnerPanel.SetActive(true);
            }
        }
        
    }

    void GameOver()
    {
        _gameOverPanel.SetActive(true);
    }
}
