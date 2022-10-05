using UnityEngine;

public class Health : MonoBehaviour  
{  
    public int maxHP = 10;  
    public bool isZeroHP => currentHP <= 0;  
    public bool isFiftyPercentHP => currentHP <= maxHP / 2;  
    public bool isOneTenthHP => currentHP <= maxHP / 10;  
  
    public int currentHP;  
    void Awake()  
    {  
        currentHP = maxHP;  
    }  
    public void Increment()  
    {  
        currentHP = Mathf.Clamp(currentHP + 1, 0, maxHP);  
    }  
  
    public void Decrement(int value)  
    {  
        currentHP = Mathf.Clamp(currentHP - value, 0, maxHP);  
    }  
}