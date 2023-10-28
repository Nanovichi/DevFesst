using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int health, money;

    public void IncreseMoney(int amount)
    {
        money += amount;
    }

    public int getMoney()
    {
        return money;
    }

    public int GetHealth()
    {
        return health;
    }

}
