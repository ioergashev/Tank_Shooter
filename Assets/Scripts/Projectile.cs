using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10;
    public float Damage = 10;

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (Mathf.Abs(transform.position.x) > 0.6f * GameSettings.Instance.WorldSize.x
            || Mathf.Abs(transform.position.y) > 0.6f * GameSettings.Instance.WorldSize.y)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.transform.GetComponent<Enemy>();
        if(enemy != null)
        {
            enemy.OnAttacked?.Invoke(new AttackEventArgs { Damage = Damage });
            Destroy(gameObject);
        }
    }
}
