using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    public Transform ObjectToPlace;
    public Camera gameCamera;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // make a ray going from the camera to the position on the game world that the mouse
            // is hovering over
            Ray cameraToMouseRay = gameCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(cameraToMouseRay, out hitInfo, 2500f))
            {
                // if the ray (ie player mouse click) has hit the terrain then move the cube to
                // that position
                if (hitInfo.transform.gameObject.tag == "Terrain")
                {
                    // draw the line of the ray in debug so we can see whats going on
                    Debug.DrawLine(cameraToMouseRay.origin, hitInfo.point, Color.red);
                    // update the position of the object 
                    ObjectToPlace.position = hitInfo.point;
                    // rotate the object so that it conforms to the surface of the terrain
                    ObjectToPlace.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
                }

                // if a cube is hit by the ray then we change the Object to the clicked on cube
                if (hitInfo.transform.gameObject.tag == "Cube")
                {
                    // because of the way we setup the cube meshes we actually select the parent
                    // instead of the just the mesh that was intersected by the ray
                    ObjectToPlace = hitInfo.transform.parent;
                }
            }
        }
    }
}
