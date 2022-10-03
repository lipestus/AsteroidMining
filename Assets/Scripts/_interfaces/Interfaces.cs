using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{ 
    void Damage(float value, Bullet.TypeBullet bulletType = Bullet.TypeBullet.Standard, Vector2 direction = default);
}

public interface IKnockBackable
{
    IEnumerator KnockBack(Vector2 direction, float knockBackStrength, Action callback = null);
}

public interface IImpactable
{
    void OnImpact();
}

