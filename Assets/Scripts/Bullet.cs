using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D rb;

    public void impulseBullet(Vector3 direction)
    {
        rb.velocity = new Vector2(direction.x, direction.y) * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Idamageable damageable))
        {
            damageable.GetDamage(20);
        }
    }
}
