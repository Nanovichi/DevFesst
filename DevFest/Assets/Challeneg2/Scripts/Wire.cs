using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{

    Vector3 startPoint;
    Vector3 startPosition;
    [SerializeField]
    private SpriteRenderer sprite;
    [SerializeField]
    private GameObject light;

    [SerializeField]
    private float radius = 0.2f;
    private GameManager gameManager;
    // Start is called before the first frame update

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    void Start()
    {
        startPoint = transform.parent.position;
        startPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(newPosition, radius);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject != this.gameObject)
            {
                
                UpdateWire(collider.transform.position);

                if (transform.parent.name.Equals(collider.transform.parent.name))
                {
                    gameManager.scoring();
                    collider.GetComponent<Wire>()?.Done();
                    Done();
                }
                return;
            }
        }       
        UpdateWire(newPosition);
    }

    private void Done()
    {
        light.SetActive(true);
        Destroy(this);
    }

    private void OnMouseUp()
    {
        UpdateWire(startPosition);
    }

    private void UpdateWire(Vector3 newPosition)
    {
        this.transform.position = newPosition;
        Vector3 direction = newPosition - startPoint;
        this.transform.right = direction * transform.lossyScale.x;

        float dist = Vector2.Distance(startPoint, newPosition);
        sprite.size = new Vector2(dist, sprite.size.y);
    }
}
