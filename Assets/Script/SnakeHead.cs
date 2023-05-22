using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SnakeHead : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;

    [SerializeField] private GameObject boddyPrefab;

    private List<GameObject> bodyList = new List<GameObject>();
    private List<Vector3> positionHistory = new List<Vector3>();

    private Collider2D headCollider;
    [Header("how many segment at the start of the game")]
    [SerializeField] private int startingBody = 3;

    [Header ("distance between segment")]
    [SerializeField] private int gap = 10;
    [Header("how fast the segment reach the each other")]
    [SerializeField] private float bodySpeed;


    private void Awake()
    {
        headCollider = GetComponent<Collider2D>();
        Physics2D.IgnoreLayerCollision(3, 3);
    }
    void Start()
    {
        for (int i = 0; i < startingBody; i++)
        {
            GameObject newBullet = Instantiate(boddyPrefab);
            newBullet.transform.position = transform.position;
            bodyList.Add(newBullet);
        }
        InstallHead();
    }

    void Update()
    {
        transform.position += transform.up * moveSpeed * Time.deltaTime;
        transform.Rotate(Vector3.forward * rotateSpeed * -Input.GetAxisRaw("Horizontal") * Time.deltaTime);
        //just in case if it null
        if (bodyList.Count > 0)
        {
            positionHistory.Insert(0, transform.position);

            int index = 0;
            foreach (var body in bodyList)
            {
                Vector3 point = positionHistory[Mathf.Min(gap * index, positionHistory.Count - 1)];
                Vector3 movedirection = point - body.transform.position;
                body.transform.position += movedirection * bodySpeed * Time.deltaTime;
                body.transform.up = movedirection;
                index++;
            }
        }
    }

    private void Die()
    {
        foreach (var body in bodyList)
        {
            Destroy(body);
        }
        Destroy(gameObject);
    }

    private void PlayerInput()
    {

    }

    private void InstallHead()
    {
        //bodyList[0].layer = 6;
        bodyList[0].AddComponent<PlayerHead>();
        bodyList[0].GetComponent<PlayerHead>().SetSnakeHead(this);
    }

    public void AddSegment()
    {
        GameObject newBullet = Instantiate(boddyPrefab);
        newBullet.transform.position = bodyList[bodyList.Count -1].transform.position;
        bodyList.Add(newBullet);
    }
}
