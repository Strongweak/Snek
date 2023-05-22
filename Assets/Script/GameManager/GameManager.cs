using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private List<GameObject> enemies;
    [SerializeField] private List<GameObject> powerUp;
    private List<GameObject> food;
    public enum gameState
    {
        ready, playing, pause, gameover
    }

    [SerializeField] private gameState state;
    [SerializeField] private float marginX,marginY;
    private Camera cam;
    private Vector2 screenBounds;

    private void Awake()
    {
        Instance = this;
        cam = Camera.main;
        food = new List<GameObject>();
        screenBounds = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
    }

    void Start()
    {
        if (food.Count == 0)
        {
            SpawnFood();
        }
    }

    void Update()
    {
        switch (state)
        {
            case gameState.ready:
                break;
            case gameState.playing:
                break;
            case gameState.gameover:
                break;
        }
        if (FindObjectsOfType<Food>().Length == 0)
        {
            SpawnFood();
        }
    }

    private void SpawnFood()
    {
        GameObject powerup = Instantiate(powerUp[0], new Vector2(Random.Range(-screenBounds.x + marginX, screenBounds.x - marginX), Random.Range(-screenBounds.y + marginY, screenBounds.y - marginY)), Quaternion.identity);
        food.Add(powerup);
    }

}
