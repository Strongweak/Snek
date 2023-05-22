using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var playerhead = collision.gameObject.GetComponent<PlayerHead>();
        if (playerhead != null)
        {
            collision.gameObject.GetComponent<PlayerHead>().GetSnakeHead().AddSegment();
            Destroy(gameObject);
        }
    }
}
