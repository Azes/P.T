using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour
{
  

    public static bool IsVisible(Camera camera, GameObject gameObject, bool canSee = false)
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();
        Collider col = gameObject.GetComponent<Collider>();

        if (renderer == null && col == null)
            return false;

        float offset = .7f;
        RaycastHit hit;
        Vector3 objectPosition = renderer != null ? renderer.bounds.center : col.bounds.center;
        Ray ray = camera.ScreenPointToRay(camera.WorldToScreenPoint(objectPosition));

        
        // Wenn der Renderer vorhanden ist, überprüfen Sie die Bildschirmposition
        if (renderer != null)
        {
            
            Vector3 viewPos = camera.WorldToViewportPoint(renderer.bounds.center);
            bool i = viewPos.x >= (!canSee ? -offset : 0) && viewPos.x <= (!canSee ? 1 + offset : 1) 
                && viewPos.y >= (!canSee ? -offset : 0) && viewPos.y <= (canSee ? 1 + offset : 1) && viewPos.z > 0;

            if (canSee)
            {
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    if (hit.collider != null) return false;
                    else return true;
                }

                return true;
            }
           
            return i;
        }

        // Wenn kein Renderer vorhanden ist, überprüfen Sie die Collider-Bounds
        if (col != null)
        {
            Vector3 viewPos = camera.WorldToViewportPoint(col.bounds.center);
            bool i = viewPos.x >= (!canSee ? -offset : 0) && viewPos.x <= (!canSee ? 1 + offset : 1)
                && viewPos.y >= (!canSee ? -offset : 0) && viewPos.y <= (canSee ? 1 + offset : 1) && viewPos.z > 0;

            if (canSee)
            {
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    if (hit.collider != null) return false;
                    else return true;
                }
                return true;
            }
            
            return i;
        }

        return false;
    }

}
