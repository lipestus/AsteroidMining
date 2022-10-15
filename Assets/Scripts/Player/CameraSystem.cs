using System;
using AsteroidMining.GameUtils;
using UnityEditor;
using UnityEngine;

namespace AsteroidMining.PlayerController
{
    public class CameraSystem : MonoBehaviour
    {
        [SerializeField] private InputHandler input;
        [SerializeField] private Transform follow;
        [SerializeField] public Vector3 offset;
        //[SerializeField] private Vector3 analogInputOffset;
        [Range(1, 100)] [SerializeField] private float smoothFollow = 8f;
        [Range(1, 100)] [SerializeField] private float smoothShift = 8f;
        private float zAxis => -10;

        private Vector3 focusPosition => new Vector3(follow.position.x, follow.position.y, zAxis)
                                         + new Vector3(offset.x, offset.y, 0);
        private float delay = 1f;
        private Vector3 forwardDirection;
        public float currentTime;
        private float normalizedTime;
        private float duration = 1f;
        private void LateUpdate()
        {
            forwardDirection = follow.rotation * Vector3.up * 2f;
            float moveInput = input.move.normalized.sqrMagnitude;
            if (moveInput > 0)
            {
                currentTime += Time.deltaTime;
                normalizedTime = currentTime / duration;
            }
            else
            {
                normalizedTime = 0;
                currentTime = 0;
                Vector3 smoothShiftVector = Vector3.Lerp(offset, 
                    forwardDirection, 0.5f * Time.deltaTime);
                offset = smoothShiftVector;
            }

            if (normalizedTime > 1)
            {
                Vector3 smoothShiftVector = Vector3.Lerp(offset, 
                    forwardDirection * 3.5f, 0.5f * Time.deltaTime);
                offset = smoothShiftVector;
            }
            
            //SmoothFollow();

            // if (/*!playerConfig.IsShooting*/ true)
            // {
            //     if (input.move.normalized.sqrMagnitude > 0)
            //     {
            //         ShiftCamera(new Vector2(forwardDirection.x, forwardDirection.y) * 4f, smoothShift);
            //         Invoke(nameof(ResetValue), 1f);
            //     }
            //     else
            //     {
            //         if (delay > 0f)
            //         {
            //             delay -= Time.deltaTime;
            //             return;
            //         }
            //         float pace = 1.8f;
            //         ShiftCamera(Vector2.zero, pace);
            //     }
            // }
            SmoothFollow();
        }
        private void SmoothFollow()
        {
            //Vector3 smoothTransition = Vector3.Lerp(transform.position, focusPosition, smoothFollow * Time.deltaTime);
            // float clampedX = Mathf.Clamp(smoothTransition.x, 
            //     confinerBox.bounds.min.x + cameraBox.size.x / 2, 
            //     confinerBox.bounds.max.x - cameraBox.size.x / 2);
            //
            // float clampedY = Mathf.Clamp(smoothTransition.y, 
            //     confinerBox.bounds.min.y + cameraBox.size.y / 2, 
            //     confinerBox.bounds.max.y - cameraBox.size.y / 2);
            //Vector3 clampedSmoothTransition = new Vector3(clampedX, clampedY, zAxis);
            transform.position = focusPosition;
        }
        private void ShiftCamera(Vector2 amount, float pace)
        {
            Vector3 smoothShiftVector = Vector3.Lerp(offset, 
                new Vector3(amount.x, amount.y, offset.z), pace * Time.deltaTime);
            offset = smoothShiftVector;
        }
        private void ResetValue()
        {
            delay = 1f;
        }
    }
}