using System.Collections;
using System.Collections.Generic;
using CodeMonkey.Utils;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    [SerializeField]
    private float dieTime = 120f;

    public GameObject munitionPrefab;

    [SerializeField]
    private float spawnchance;

    [SerializeField]
    private float knockbackforce = 16f;

    private Rigidbody2D rb;


    private int health;

    private Transform target;

    [SerializeField]
    private float speed = 2;

    [SerializeField]
    private float minoffset = 0.3f;

    [SerializeField]
    private float maxoffset = 20f;
    public AudioClip loopClip;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }
    private void Start()
    {
        health = Random.Range(1, 3);
        speed = Random.Range(1, 6);
        target = GameObject.FindGameObjectWithTag("Player").transform;
        Destroy(this.gameObject, dieTime);

    }
    private void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > minoffset && Vector2.Distance(transform.position, target.position) < maxoffset)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            Attack();
        }
        lookAt();

    }
    private void Attack()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Bullet"))
        {
            takeDamage();
        }
    }
    private void takeDamage()
    {
        knockback();
        health--;
        if (health <= 0)
        {
            Instantiate(munitionPrefab, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

    }
    private void knockback()
    {
        Vector2 diection = (this.transform.position - target.transform.position).normalized;
        rb.AddForce(diection * knockbackforce, ForceMode2D.Impulse);
    }
    private void lookAt()
    {
        Vector2 direction = target.transform.position - this.transform.position;
        float angle = UtilsClass.GetAngleFromVectorFloat(direction);
        this.transform.eulerAngles = new Vector3(0f, 0f, angle);
    }
}
