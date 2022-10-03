using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Standard BulletData", menuName = "Projectiles/Standard bullet", order = 1)]  
public class BulletData : ScriptableObject  
{  
    [NonReorderable]  
    public BulletType[] bullets;  
      
    [Serializable]  
    public class BulletType  
    {  
        public PropertyName bulletName;  
        public Bullet bulletPrefab;  
    }  
}
