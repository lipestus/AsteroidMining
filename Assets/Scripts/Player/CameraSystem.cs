using AsteroidMining.GameUtils;
using UnityEngine;

namespace AsteroidMining.PlayerController
{
    public class CameraSystem : MonoBehaviour
    {
        [SerializeField] private Transform follow;
        [SerializeField] private Vector3 offset;
        [Range(1, 10)] [SerializeField] private float smoothFollow = 8f;
        [Range(1, 10)] [SerializeField] private float smoothShift = 8f;
        private float zAxis => -10;
        [SerializeField] private InputHandler playerConfig;
        private Vector3 focusPosition => new Vector3(follow.position.x, follow.position.y, -10) 
                                         + new Vector3(offset.x, offset.y, zAxis);
        private float delay = 1f;
        private void LateUpdate()
        {
            SmoothFollow();

            if (/*!playerConfig.IsShooting*/ true)
            {
                if (true)
                {
                    //ShiftCamera(1.8f, smoothShift);
                    //Invoke(nameof(ResetValue), 1f);
                }
                // else if (playerConfig.move.x == 0)
                // {
                //     if (delay > 0f)
                //     {
                //         delay -= Time.deltaTime;
                //         return;
                //     }
                //     float pace = 1.8f;
                //     ShiftCamera(0f, pace);
                // }
            }
            // else if (playerConfig.IsShooting)
            // {
            //     if(playerConfig.ShootingDirection == Vector2.right)
            //         ShiftCamera(1.8f, smoothShift);
            //     if(playerConfig.ShootingDirection == Vector2.left)
            //         ShiftCamera(-1.8f, smoothShift);
            // }

        }
        private void SmoothFollow()
        {
            //Vector3 smoothTransition = Vector3.Lerp(transform.position, focusPosition, smoothFollow * Time.deltaTime);
            Vector3 smoothTransition =
                GameplayUtils.Lerp(transform.position, focusPosition, Time.deltaTime, smoothFollow);
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
        private void ShiftCamera(float amount, float pace)
        {
            Vector3 smoothShiftVector = Vector3.Lerp(offset, new Vector3(offset.x, amount, offset.z), pace * Time.deltaTime);
            offset = smoothShiftVector;
        }
        private void ResetValue()
        {
            delay = 1f;
        }
    }
}