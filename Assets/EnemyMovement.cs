using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private Rigidbody2D rigidbody2;

    [Header("Attributes")]
    [SerializeField]
    private float movespeed = 1f;

    private Transform target;
    private int pathIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        target = LevelManager.instance.path[pathIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(target.position, transform.position) <= 0.1f)
        {
            pathIndex++;

            if(pathIndex == LevelManager.instance.path.Length)
            {
                Destroy(gameObject);
                return;
            }
            else
            {
                target = LevelManager.instance.path[pathIndex];
            }

        }
    }

    private void FixedUpdate()
    {
        Vector2 dicrection = (target.position - transform.position).normalized;

        rigidbody2.velocity = dicrection * movespeed;
    }
}
