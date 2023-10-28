using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float lifetime = 2f;


    private void Start()
    {

        StartCoroutine(Destroyobject());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Ennemies"))
        {
            Destroy(this.gameObject);

        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Ennemies"))
        {
            Destroy(this.gameObject);

        }
    }
    private IEnumerator Destroyobject()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(this.gameObject);

    }
}
