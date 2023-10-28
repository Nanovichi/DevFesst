using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    [SerializeField]
    private float minInterval = 5f;
    [SerializeField]
    private float maxInterval = 10f;
    [SerializeField]
    private int minamount = 4;
    [SerializeField]
    private int maxamount = 8;
    private BoxCollider2D boxCollider2D;

    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }
    private void Start()
    {
        InvokeRepeating("Spawn", 0f, Random.Range(minInterval, maxInterval));
    }

    private void Spawn()
    {
        int amount = Random.Range(minamount, maxamount);
        for (int i = 0; i < amount; i++)
        {
            Vector2 randompostion = GetrandomPosition();

            Instantiate(prefab, randompostion, Quaternion.identity);
        }
    }

    private Vector2 GetrandomPosition()
    {
        Bounds bounds = boxCollider2D.bounds;

        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomY = Random.Range(bounds.min.y, bounds.max.y);

        return new Vector2(randomX, randomY);
    }
}
