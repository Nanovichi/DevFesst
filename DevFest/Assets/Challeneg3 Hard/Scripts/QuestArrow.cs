using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestArrow : MonoBehaviour
{
    [SerializeField]
    public Transform target;
    [SerializeField]
    private float buffer;

    private void Update()
    {
        Vector2 difference = this.transform.position - target.position;
        float angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + buffer);
    }
}
