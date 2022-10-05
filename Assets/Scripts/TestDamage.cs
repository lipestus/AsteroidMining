using UnityEngine;

public class TestDamage : MonoBehaviour, IDamageable
{
    [SerializeField] private Health health;

    private void Awake()
    {
        health = GetComponent<Health>();
    }
    public void Damage(float value, Bullet.TypeBullet bulletType = Bullet.TypeBullet.Standard, Vector2 direction = default)
    {
        health.Decrement((int)value);
        if (health.isZeroHP)
            Destroy(gameObject);
    }
}