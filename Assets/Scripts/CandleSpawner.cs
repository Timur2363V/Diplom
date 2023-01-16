using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CandleSpawner : MonoBehaviour
{
    [Header("НЕ ставить галочку, появятся свечи!!!")] [SerializeField]
    private bool isOnValidateEnabled;

    [Header("Parameters")] [SerializeField]
    private Bounds spawnZone;

    [SerializeField] private int spawnCount;
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private Transform parent;

    private void OnValidate()
    {
        if (isOnValidateEnabled)
        {
            for (var i = 0; i < spawnCount; i++)
            {
                var position = RandomPointInBox(spawnZone);
                var go = Instantiate(objectToSpawn, parent);
                go.transform.localPosition = position;
            }
        }
    }

    private static Vector3 RandomPointInBox(Bounds bounds)
    {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );
    }
}