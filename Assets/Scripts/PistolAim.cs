using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolAim : MonoBehaviour
{

     public float offset = 0.1f;

     void Update()
     {
         RotatePistolToCursor();
     }

     void RotatePistolToCursor()
     {
         // Get the mouse position in the world
         Vector3 mousePosition = Input.mousePosition;
         mousePosition.z = offset; // Distance from the camera to the aiming plane

         Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

         // Calculate the direction from the pistol to the mouse position
         Vector3 direction = worldMousePosition - transform.position;

         // Calculate the rotation
         Quaternion targetRotation = Quaternion.LookRotation(direction);

         // Lock rotation to X and Y axis only
         targetRotation = Quaternion.Euler(targetRotation.eulerAngles.x, -targetRotation.eulerAngles.y + 180, 0);

         // Rotate the pistol
         transform.rotation = targetRotation;
     }
}

