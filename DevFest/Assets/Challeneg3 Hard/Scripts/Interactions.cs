using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    [SerializeField]
    private GameObject eButton;
    private Shooting shooting;
    private SpriteRenderer sprite;
    [SerializeField]
    private Sprite weaponSprite;
    private void Start()
    {
        sprite=GetComponent<SpriteRenderer>();  
        eButton.SetActive(false);
        shooting = GetComponent<Shooting>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PNG"))
        {
            eButton.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Weapon1"))
        {
            Destroy(collision.gameObject);
            shooting.setShoot(true);
            sprite.sprite = weaponSprite;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PNG"))
        {
            eButton.SetActive(false);
        }
    }

    
}
