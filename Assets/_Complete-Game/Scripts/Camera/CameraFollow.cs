using UnityEngine;
using System.Collections;

namespace CompleteProject
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;    // The position that that camera will be following.
        public float smoothing = 5f;    // The speed with which the camera will be following.
        public float smoothingRotation = 5f;    // The speed with which the camera will be rotating to aim at the player.

        public Vector3 offset;  // The initial offset from the target.

        void Start ()
        {
            // Calculate the initial offset.
            transform.position = target.position + offset;
        }

        void FixedUpdate ()
        {
            // Create a postion the camera is aiming for based on the offset from the target.
            Vector3 targetCamPos = target.position + offset;

            // Smoothly interpolate between the camera's current position and it's target position.
            transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);

            // Smoothly interpolate rotation to look at the player position
            Vector3 targetPosition = target.position - transform.position;
            Quaternion newRotation = Quaternion.LookRotation(targetPosition); // Create a new rotation that aims at the player position
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, smoothingRotation * Time.deltaTime);
        }
    }
}