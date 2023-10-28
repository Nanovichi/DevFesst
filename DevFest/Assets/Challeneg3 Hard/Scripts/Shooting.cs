using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletprefab;
    [SerializeField]
    private Transform spawnpoint;
    [SerializeField]
    private float force = 20f;
    private bool canshoot = true;
    [SerializeField]
    private float shootcool = 0.5f;
    private void Start()
    {
        canshoot = false;
    }

    public void setShoot(bool shoot)
    {
        canshoot = shoot;
    }

    private void OnShooting()
    {
        if (canshoot)
        {
            GameObject bullet = Instantiate(bulletprefab, spawnpoint.position, spawnpoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(spawnpoint.up * force, ForceMode2D.Impulse);
            StartCoroutine(ShootCouldown());
        }
    }

    IEnumerator ShootCouldown()
    {
        canshoot = false;
        yield return new WaitForSeconds(shootcool);
        canshoot = true;
    }
}
