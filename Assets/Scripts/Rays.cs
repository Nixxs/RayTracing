using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rays : MonoBehaviour
{
    // Update is called once per frame
    public void CastRay()
    {
        // create a ray originating from the player position (rays is attached) to the player
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo; // this is used later to store the hitinfo from the ray

        // physics raycast will cast our ray out and return true/false if it hits something
        // if it does hit something is also gives you RaycastHit via the out var
        if (Physics.Raycast(ray, out hitInfo))
        {
            // draws a line between two points, so we set origin to the ray origin position and
            // end point to be the thing that the ray hit
            Debug.DrawLine(ray.origin, hitInfo.point, Color.green);

            // this is just to print out the tag of the game object that was hit to show
            // that we have access to the hit game object.
            print(hitInfo.transform.gameObject.tag);
        } else
        {
            // the ray hasn't hit anything so calculate the end point for the ray coming
            // out of the player using a distance. in this case it's 20 units.
            Vector3 endPoint = ray.origin + (ray.direction * 20);

            // draw the ray line in red since it didn't hit anything
            Debug.DrawLine(ray.origin, endPoint, Color.red);

            
        }
    }
}
