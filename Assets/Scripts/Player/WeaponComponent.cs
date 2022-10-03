using System;
using System.Collections;
using System.Collections.Generic;
using AsteroidMining.GameUtils;
using AsteroidMining.PlayerController;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponComponent : MonoBehaviour
{
    [SerializeField] private InputHandler input;
    [SerializeField] private Transform aimTransform;
    [SerializeField] private Transform barrel;
    [SerializeField, Range(1, 100)] private float rotationSpeed = 1;

    [Space(10)]
    [Header("FIRE LOGIC")] 
    [SerializeField] [Range(0.1f,10)]private float fireRate;
    
    
    private Vector3 mousePosition;
    private float lastShot = 0.0f;
    private BulletSpawner bulletSpawner;

    private void Awake()
    {
        bulletSpawner = GetComponent<BulletSpawner>();
    }
    void Update()
    {
        mousePosition = GameplayUtils.GetMouseWorldPosition();
        if (input.isFiring)
        {
            if (Time.time > fireRate + lastShot)
            {
                lastShot = Time.time;
                bulletSpawner.Spawn(barrel, "Standard");
            }
        }
    }
    private void LateUpdate()
    {
        RotateGunTowardsPoint(mousePosition, rotationSpeed);
    }

    private void RotateGunTowardsPoint(Vector3 point, float rotationSpeed)
    {
        Vector3 aimDirection = (point - aimTransform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        aimTransform.rotation = Quaternion.Slerp(aimTransform.rotation, rotation,
            rotationSpeed * Time.deltaTime);
    }
}
