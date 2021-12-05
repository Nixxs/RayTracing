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
        // it also has an overload that allows you to set max distance so it doesn't go on forever
        if (Physics.Raycast(ray, out hitInfo, 100f))
        {
            // draws a line between two points, so we set origin to the ray origin position and
            // end point to be the thing that the ray hit
            Debug.DrawLine(ray.origin, hitInfo.point, Color.green);

            // if it hit a wall bounce it off the wall
            if (hitInfo.transform.gameObject.tag == "Wall")
            {
                // define the bounce direction using the initial hitobject normal
                Vector3 bounceDirection = Vector3.Reflect(ray.direction, hitInfo.normal);
                // make a new ray using the hit location as orgin and bounce direction as direction
                Ray bounceRay = new Ray(hitInfo.point, bounceDirection);
                RaycastHit hitInfo2;
                if (Physics.Raycast(bounceRay, out hitInfo2, 100f))
                {
                    // cast out the new ray and draw a line if it hits something 
                    Debug.DrawLine(bounceRay.origin, hitInfo2.point, Color.green);
                    print(hitInfo2.transform.tag);
                } else
                {
                    // if the bounce didn't hit anythign then draw it red
                    Vector3 endBouncePoint = bounceRay.origin + (bounceRay.direction * 20);
                    Debug.DrawLine(bounceRay.origin, endBouncePoint, Color.red);
                }
            } else // if it didnt hit a wall just print what it hit
            {
                print(hitInfo.transform.tag);
            }

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
