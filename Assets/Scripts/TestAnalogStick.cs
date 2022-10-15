using System.Collections;
using System.Collections.Generic;
using AsteroidMining.PlayerController;
using UnityEngine;

namespace AsteroidMining.PlayerController
{
    public class TestAnalogStick : MonoBehaviour
    {
        [SerializeField] private CameraSystem camera;
        private float moveInput;
        [SerializeField] private InputHandler input;
        [SerializeField] private Rigidbody2D rb;
        private float easeInValue;
        public float currentTime;
        private float normalizedTime;
        private float duration = 1f;
        private Vector3 forwardDirection;
        // Update is called once per frame
        void Update()
        {
            // transform.position = input.move;
            // forwardDirection = rb.rotation * Vector3.up;
            
            // moveInput = input.move.normalized.sqrMagnitude;
            // if (moveInput > 0)
            // {
            //     currentTime += Time.deltaTime;
            //     normalizedTime = currentTime / duration;
            // }
            // else
            // {
            //     normalizedTime = 0;
            //     currentTime = 0;
            //     Vector3 smoothShiftVector = Vector3.Lerp(camera.offset, 
            //         Vector3.zero, 1.5f * Time.deltaTime);
            //     camera.offset = smoothShiftVector;
            // }
            //
            // if (normalizedTime > 1)
            // {
            //     Vector3 smoothShiftVector = Vector3.Lerp(camera.offset, 
            //         new Vector3(input.move.x, input.move.y, camera.offset.z) * 6, 2.5f * Time.deltaTime);
            //     camera.offset = smoothShiftVector;
            // }
            
            //
            // easeInValue = moveInput * GameUtils.Easing.QuadEaseOut(normalizedTime, 0, 350f, normalizedTime);
            Debug.Log($"<color=cyan> normalizedTime: {normalizedTime} </color>");
        }

        private void FixedUpdate()
        {
            //rb.AddForce(input.move * easeInValue * Time.deltaTime);
        }
    }
}



