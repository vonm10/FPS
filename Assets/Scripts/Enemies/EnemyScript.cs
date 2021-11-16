using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    int enemyHealth = 10;

    public ScoreCounter scoreCounter;

    public void DeductHealthPoints(int damageAmount)
    {
        enemyHealth -= damageAmount;
    }

    void Update()
    {
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
            scoreCounter.AddScore(5);
        }
    }
}
