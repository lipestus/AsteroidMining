using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDamage : MonoBehaviour, IDamageable
{
    [SerializeField] private Health health;
    public void Damage(float value, Bullet.TypeBullet bulletType = Bullet.TypeBullet.Standard, Vector2 direction = default)
    {
        health.Decrement((int)value);
    }
}