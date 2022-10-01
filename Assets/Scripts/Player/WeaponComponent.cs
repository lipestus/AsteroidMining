using System.Collections;
using System.Collections.Generic;
using AsteroidMining.GameUtils;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponComponent : MonoBehaviour
{
    [SerializeField] private Transform aimTransform;
    [SerializeField, Range(1, 100)] private float rotationSpeed = 1;
    private Vector3 mousePosition;
    void Update()
    {
        mousePosition = GameplayUtils.GetMouseWorldPosition();
        aimTransform.transform.up =
            Vector3.MoveTowards(aimTransform.transform.up, mousePosition, 
                rotationSpeed * Time.deltaTime);
    }
}
