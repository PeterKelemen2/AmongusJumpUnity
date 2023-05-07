using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float minDistance = 2f; // minimum distance between platforms
    public float maxX = 4f; // maximum x position for a new platform
    public float minX = -4f; // minimum x position for a new platform
    public float maxYOffset = 5f; // maximum y offset for a new platform
    public float minYOffset = 1f; // minimum y offset for a new platform
    public bool overlaps = false; 

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("tile"))
        {
            MovePlatform();
        }
    }

    private void Update()
    {
        overlaps = CheckOverlap(transform.position);
    }

    public void MovePlatform()
    {
        Vector3 newPos = transform.position;
        do
        {
            newPos.x = Random.Range(minX, maxX);
            newPos.y = Camera.main.transform.position.y + Random.Range(minYOffset, maxYOffset);
        } while (CheckOverlap(newPos));
        transform.position = newPos;
    }

    bool CheckOverlap(Vector3 pos)
    {
        Collider[] colliders = Physics.OverlapSphere(pos, minDistance);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("platformSpawnCheck"))
            {
                return true;
            }
        }
        return false;
    }
}