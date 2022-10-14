using System;
using System.Collections;
using System.Collections.Generic;
using AsteroidMining.GameUtils;
using UnityEngine;

namespace AsteroidMining.PlayerController
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private InputHandler input;
        [SerializeField] private Rigidbody2D rb;
        [Range(1, 1500)] public float thrust;
        [Tooltip("Min speed when holding joystick")][Range(1, 1500)] public float thrustMinSpeed;
        [Range(1, 50)] public float turnSpeed;

        private float thrustInput;
        private float turnInput;
        private Vector2 testVector;
        private float easeInValue;
        private float currentTime;
        private float turnTimeElapsed;

        private Vector2 turnVector;
        private Quaternion rotation;
        private Quaternion lastRotationValue;
        private float clampMinValue;
        private float normalizedTime;
        private float duration = 1f;
        private void Update()
        {
            turnInput = input.rotationValue.normalized.sqrMagnitude;
            //Debug.Log($"<color=cyan>turnInput: {turnInput} </color>");
            if (turnInput > 0)
            {
                float angle = Mathf.Atan2(input.rotationValue.x, input.rotationValue.y) * Mathf.Rad2Deg;
                rotation = Quaternion.AngleAxis(-angle, Vector3.forward);
                lastRotationValue = rotation;
                //Debug.Log($"<color=cyan> angle: {input.rotationValue} </color>");
            }
            else
            {
                rotation = lastRotationValue;
            }
            
            thrustInput = input.move.normalized.sqrMagnitude;
           
            if (thrustInput > 0)
            {
                currentTime += Time.deltaTime;
                normalizedTime = currentTime / duration;
                thrustMinSpeed = 350f;
                easeInValue = thrustInput * GameUtils.Easing.QuadEaseOut(normalizedTime, 0, thrust, normalizedTime);
            }
            else
            {
                thrustMinSpeed = 0;
                currentTime = 0;
            }
            easeInValue = Mathf.Clamp(easeInValue, thrustMinSpeed, thrust);
            Debug.Log($"<color=cyan> thrustInput: {thrustInput} </color>");
        }

        private void FixedUpdate()
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation,
                turnSpeed * Time.deltaTime);
            rb.AddForce(input.move * easeInValue * Time.deltaTime);
        }
    }
}