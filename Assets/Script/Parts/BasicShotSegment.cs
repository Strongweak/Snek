using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicShotSegment : MonoBehaviour
{
    [SerializeField] private float detectionRadius;

    [SerializeField] private float fireRate;
    private float timer;
    [SerializeField] private float maxDistance;
    [SerializeField] private GameObject projectile;

    [SerializeField] private LayerMask targetLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            if(DetectEnemy() != null)
            {
                Vector3 direction = DetectEnemy().position - transform.position;
                direction.Normalize();
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                GameObject newBullet = Instantiate(projectile, transform.position,transform.rotation);
                newBullet.transform.up = direction;
            }
            timer = fireRate;
        }
    }

    private Transform DetectEnemy()
    {
        Collider2D[] colliderArray = Physics2D.OverlapCircleAll(transform.position, detectionRadius, targetLayer);
        if (colliderArray != null)
        {
            foreach (Collider2D collider in colliderArray)
            {
                if (collider.TryGetComponent<Enemy>(out Enemy enemy))
                {
                    return enemy.transform;
                }
            }
        }
        return null;
    }
}
