using UnityEngine;

public class TargetMover : MonoBehaviour
{
    public float speed = 2f;
    public float moveRange = 3f;

    private Vector3 startPos;
    private float offset;

    void Start()
    {
        startPos = transform.position;
        offset = Random.Range(0f, Mathf.PI * 2);
    }

    public void ResetPath()
    {
        startPos = transform.position;
        offset = Random.Range(0f, Mathf.PI * 2); 
    }

    void Update()
    {
        float movement = Mathf.Sin(Time.time * speed + offset) * moveRange;
        transform.position = startPos + new Vector3(movement, 0f, 0f);
    }
}

