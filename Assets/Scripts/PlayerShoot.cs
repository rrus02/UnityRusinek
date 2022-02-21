﻿using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float fireRate = 0.04f; //mozna dac mniejsza wartosc jak chcemy wiekszy firerate
    public Transform firingPoint;
    public GameObject bulletPrefab;

    float timeUntilFire;
    PlayerMovement pm;

    private void Start()
    {
        pm = gameObject.GetComponent<PlayerMovement>();
    }

    private void Update()
    {
      if (Input.GetMouseButtonDown(0) && timeUntilFire < Time.time)
        {
            Shoot();
            timeUntilFire = Time.time + fireRate;
        }
        if (Input.GetKeyDown(KeyCode.E) && timeUntilFire < Time.time)
            {
            Shoot();
            timeUntilFire = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        float angle = pm.isFacingRight ? 0f : 180f;
        Instantiate(bulletPrefab, firingPoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
    }
}
