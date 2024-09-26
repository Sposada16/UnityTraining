using System.Collections.Generic;
using UnityEngine;

public class CameraObstructionTransparency : MonoBehaviour
{
    public Transform player;  // Reference to the player's transform
    public LayerMask obstructionLayer;  // Layer of objects that can obstruct the view (e.g., trees)
    public float distanceThreshold = 5f;  // Distance at which objects become transparent
    private List<Renderer> currentObstructedObjects = new List<Renderer>();  // Keep track of currently obstructed objects

    void LateUpdate()
    {
        // Cast a sphere around the camera to detect obstructing objects
        Collider[] colliders = Physics.OverlapSphere(transform.position, distanceThreshold, obstructionLayer);

        // Loop through all colliders in the sphere and make their renderers transparent
        foreach (Collider collider in colliders)
        {
            Renderer renderer = collider.GetComponent<Renderer>();
            if (renderer != null)
            {
                if (!currentObstructedObjects.Contains(renderer))
                {
                    // Only make the object transparent if it hasn't already been made transparent
                    SetObjectTransparent(renderer);
                    currentObstructedObjects.Add(renderer);  // Keep track of objects we've made transparent
                }
            }
        }
    }

    // Set object transparency
    void SetObjectTransparent(Renderer renderer)
    {
        foreach (Material material in renderer.materials)
        {
            // Change to transparent mode
            material.SetFloat("_Mode", 2);  // 2 = Transparent
            material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            material.SetInt("_ZWrite", 0);
            material.DisableKeyword("_ALPHATEST_ON");
            material.EnableKeyword("_ALPHABLEND_ON");
            material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            material.renderQueue = 3000;

            // Set transparency
            Color color = material.color;
            color.a = 0.3f;  // Set to 30% transparency
            material.color = color;
        }
    }
}
