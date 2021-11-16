using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;

    public float enemySpeed;

    private void Awake()
    {
        enemySpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        enemySpeed = 0.02f;
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, enemySpeed);
    }
}
