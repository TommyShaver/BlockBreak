using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelGenerator : MonoBehaviour
{
    
    public Vector2Int _size;
    public Vector2 _offset;

    public GameObject _brickPrefabs;
    public Gradient _gradient;

    private void Awake()
    {
        // To auto spawn a level needs a for loop that loops on x and y. 
        for (int i = 0; i < _size.x; i++)
        {
            for (int j = 0; j < _size.y; j++)
            {
                GameObject newBrick = Instantiate(_brickPrefabs, transform);
                newBrick.transform.position = transform.position + new Vector3((float)((_size.x - 1) * .5f - i) * _offset.x, j * _offset.y, 0);
                //                                                           |This is centering the spawn  | this is how to lay blocks across blocks
                //Gradient color change
                newBrick.GetComponent<SpriteRenderer>().color = _gradient.Evaluate((float)j / (_size.y - 1));
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void Restart()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       
    }
}
