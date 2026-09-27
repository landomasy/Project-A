using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public Camera playerCamera;      // drag your PlayerCamera in
    public float range = 100f;
    public LayerMask targetMask;     // which layers count as "hittable"

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // left-click
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f)); // center of screen
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, range, targetMask))
        {
            Target target = hit.collider.GetComponent<Target>();
            if (target != null)
            {
                target.OnHit();
            }
        }
    }
}