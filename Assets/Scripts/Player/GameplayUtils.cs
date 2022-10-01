using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace AsteroidMining.GameUtils
{
    public class GameplayUtils
    {
        public static Vector3 GetMouseWorldPosition()
        {
            Vector3 vec = GetMouseWorldPositionWithZ(Mouse.current.position.ReadValue(), UnityEngine.Camera.main);
            vec.z = 0f;
            return vec;
        }
        public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, UnityEngine.Camera worldCamera)
        {
            Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
            return worldPosition;
        }

        public static Vector3 Lerp(Vector3 start, Vector3 end, float timeStarted, float lerpTime = 1)
        {
            float timeSinceStarted = Time.time - timeStarted;
            float percentageComplete = timeSinceStarted / lerpTime;
            var lerp = Vector3.Lerp(start, end, percentageComplete);
            return lerp;
        }

        public static void ShakeEffect(AnimationCurve curve, float time = 1f)
        {
            //CameraShake2D.instance.Shake(curve, time);
        }

        public static GameObject SpawnGameObject(GameObject obj, Transform effectPosition)
        {
            return Object.Instantiate(obj, effectPosition.position, effectPosition.rotation);
        }

        public static void FlickTheLights(float duration, float range, float tMin, float tMax)
        {
            //LightController.instance.FlickLights(duration, range, tMin, tMax);
        }
    }
}


