using UnityEngine;

public class FinalSpawnZone : MonoBehaviour
{
    [SerializeField] GameObject prefabToSpawn;
    bool hasSpawned = false;
    public void OnTriggerEnter(Collider other)
    {
        if (hasSpawned) { return; }
        if (other.CompareTag("Player"))
        {
            foreach (Transform location in GetComponentInChildren<Transform>())
            {
                Instantiate(prefabToSpawn, location);
            }
        }
        hasSpawned = true;
    }
}
