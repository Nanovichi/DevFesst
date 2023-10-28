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
    [SerializeField]
    private QuestGiver NPC;

    private Player player;
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        eButton.SetActive(false);
        shooting = GetComponent<Shooting>();
        player = GetComponent<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PNG"))
        {
            eButton.SetActive(true);
            
        }
        if (collision.gameObject.CompareTag("Weapon1") && player.quests[player.GetIndex()].goal.goaltype == GoalType.FInding)
        {
            Destroy(collision.gameObject);
            shooting.setShoot(true);
            sprite.sprite = weaponSprite;
            player.quests[player.GetIndex()].isActive = false;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PNG"))
        {
            eButton.SetActive(false);
        }
    }

    private void OnInteract()
    {
        NPC.GiveQuest();
    }
    

}
