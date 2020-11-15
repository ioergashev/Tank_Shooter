using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public float rotationSpeed = 1;
    public float moveSpeed = 1;

    private float lastFireTime;
    public float WeaponReloadDuration = 0.5f;
    public Projectile ProjectilePrefab;

    public Transform ProjectileOrigin;

    public float Armor = 0.5f;

    void Update()
    {
        float rotationAngle = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.back, rotationAngle);

        float moveDistance = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(Vector3.up * moveDistance);

        if((Input.GetKey(KeyCode.X) || Input.GetKey(KeyCode.Space))
            && Time.time > lastFireTime + WeaponReloadDuration)
        {
            lastFireTime = Time.time;
            Fire();
        }
    }

    private void Fire()
    {
        Instantiate(ProjectilePrefab, ProjectileOrigin.position, ProjectileOrigin.rotation);
    }
}
