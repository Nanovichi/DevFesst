using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    [SerializeField]
    private TextMeshProUGUI taskQuest;

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
        if (collision.gameObject.CompareTag("Weapon1") && player.quests[player.GetIndex()].goal.goaltype == GoalType.Finding)
        {


            Destroy(collision.gameObject);
            shooting.setShoot(true);
            sprite.sprite = weaponSprite;
            player.quests[player.GetIndex()].isActive = false;
            player.quests[player.GetIndex()].goal.SetFound();

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
        Debug.Log("New QUest");
        taskQuest.text = "New QUest";
        NPC.GiveQuest();
    }
    

}
