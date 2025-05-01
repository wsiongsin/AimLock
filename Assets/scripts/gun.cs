using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class gun : MonoBehaviour
{
    public float damage = 10f;
    public float impactForce = 100f;
    public float range = 100f;
    public float firingRate = 15f;

    public Camera FPSCam;
    private float nextTimeToFire = 0f;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / firingRate;
            Shoot();
        }
    }

    public PerformanceTracker tracker;

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPSCam.transform.position, FPSCam.transform.forward, out hit, range))
        {
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
                tracker.RegisterHit();
            }
            else
            {
                tracker.RegisterMiss();
            }
        }
        else
        {
            tracker.RegisterMiss();
        }
    }
}
