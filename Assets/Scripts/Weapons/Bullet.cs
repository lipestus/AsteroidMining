using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public enum TypeBullet
    {
        Standard,
        Laser
    }

    public TypeBullet typeBullet;
    public float bulletDamage = 1f;
    public float speed;
    [SerializeField] private Rigidbody rb;
    public float lifeTime = 2f;
    public void OnEnable()
    {
        rb.velocity = transform.forward * speed;
    }

    private void Update()
    {
        if (lifeTime <= 0f)
            Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        IDamageable damageable = other.gameObject.GetComponent<IDamageable>();
        if (damageable != null)
        {
            Vector2 velocity = Vector2.zero;
            switch (typeBullet)
            {
                case TypeBullet.Laser:
                    int randomDirection = UnityEngine.Random.Range(-100, 100);
                    velocity.x = randomDirection;
                    break;
                default:
                    velocity = rb.velocity;
                    break;
            }

            damageable.Damage(bulletDamage, typeBullet, velocity);
            rb.velocity = Vector3.zero;
        }

        IImpactable impactable = other.gameObject.GetComponent<IImpactable>();
        if (impactable != null)
        {
        }
    }
}
