using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10;

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (Mathf.Abs(transform.position.x) > 0.6f * GameSettings.Instance.WorldSize.x
            || Mathf.Abs(transform.position.y) > 0.6f * GameSettings.Instance.WorldSize.y)
            Destroy(gameObject);
    }
}
