using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [Header("Target Settings")]
    public GameObject targetPrefab;
    public int maxTargets = 3;

    [Header("Spawn Area")]
    public float spawnRangeX = 7f;
    public float spawnRangeY = 3f;
    public float fixedZ = 34.38f;

    [Header("Overlap Check")]
    public LayerMask targetLayerMask;
    private float targetRadius = 1f;

    private List<GameObject> activeTargets = new List<GameObject>();

    void Awake()
    {
        SphereCollider col = targetPrefab.GetComponent<SphereCollider>();
        if (col != null)
        {
            float scale = targetPrefab.transform.localScale.x;
            targetRadius = col.radius * scale * 1.1f;
        }
        else
        {
            Debug.LogWarning("Target prefab has no SphereCollider! Using default radius.");
        }
    }

    void Start()
    {
        for (int i = 0; i < maxTargets; i++)
        {
            SpawnTarget();
        }
    }

    void Update()
    {
        //remove destroyed targets
        activeTargets.RemoveAll(t => t == null);

        bool practiceMode = PlayerPrefs.GetInt("MovingTarget", 0) == 0;
        if (practiceMode) return;
        int realCount = 0;
        foreach (var t in activeTargets)
        {
            if (t == null) continue;
            Target targetScript = t.GetComponent<Target>();
            if (targetScript != null && !targetScript.isTargetPractice)
            {
                realCount++;
            }
        }
        while (realCount < maxTargets)
        {
            SpawnTarget();
            realCount++;
        }
    }

    public void SpawnTarget()
    {
        int maxAttempts = 30;
        int attempts = 0;
        bool positionFound = false;
        Vector3 spawnPos = Vector3.zero;

        while (!positionFound && attempts < maxAttempts)
        {
            spawnPos = new Vector3(
                Random.Range(-spawnRangeX, spawnRangeX),
                Random.Range(-spawnRangeY, spawnRangeY),
                fixedZ
            );

            Collider[] colliders = Physics.OverlapSphere(spawnPos, targetRadius, targetLayerMask);
            if (colliders.Length == 0)
            {
                positionFound = true;
            }

            attempts++;
        }

        if (positionFound)
        {
            GameObject target = Instantiate(targetPrefab, spawnPos, Quaternion.identity);

            bool practiceMode = PlayerPrefs.GetInt("MovingTarget", 0) == 0;

         
            Target targetScript = target.GetComponent<Target>();
            if (targetScript != null)
            {
                targetScript.isTargetPractice = practiceMode;
                if (!practiceMode)
                {
                    activeTargets.Add(target);
                }
            }
            if (!practiceMode && target.GetComponent<TargetMover>() == null)
            {
                target.AddComponent<TargetMover>();
            }
        }
        else
        {
            Debug.LogWarning("No non-overlapping position found after multiple attempts.");
        }
    }
}


