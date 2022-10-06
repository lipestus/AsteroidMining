using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletSpawner : MonoBehaviour  
{  
    [SerializeField] private BulletData bulletData;  
    [SerializeField] private Transform bulletContainer;  
    
    public void Spawn(Transform barrel, PropertyName bulletName)  
    {  
        BulletData.BulletType spawnBullet = FindBulletByName(bulletName);  
        var bullet = Instantiate(spawnBullet.cwBullet.gameObject, barrel.position, barrel.rotation);  
        bullet.transform.parent = bulletContainer;  
    }  
    public void SpawnAttached(Transform barrel, PropertyName bulletName)  
    {  
        var spawnBullet = FindBulletByName(bulletName);  
        var bullet = Instantiate(spawnBullet.cwBullet.gameObject, barrel.position, barrel.rotation);  
        bullet.transform.parent = barrel;  
    }  
  
    private BulletData.BulletType FindBulletByName(PropertyName bulletName)  
    {  
        BulletData.BulletType bulletType = null;  
        for (var i = 0; i < bulletData.bullets.Length; i++)  
        {  
            if (bulletData.bullets[i].bulletName == bulletName)  
            {  
                bulletType = bulletData.bullets[i];  
                break;  
            }  
        }  
        return bulletType;  
    }  
}
