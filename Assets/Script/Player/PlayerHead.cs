using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHead : MonoBehaviour
{
    [SerializeField] private SnakeHead snakeHead;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Head hit " + collision.gameObject.name);
    }

    public void SetSnakeHead(SnakeHead input)
    {
        snakeHead = input;
    }

    public SnakeHead GetSnakeHead()
    {
        return snakeHead;
    }
}
