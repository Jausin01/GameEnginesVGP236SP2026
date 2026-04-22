using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bonusPrefab;
    [SerializeField] private Transform[] spawnPoints;

    private void Start()
    {
        SpawnBonus();
    }


    public void SpawnBonus()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(bonusPrefab, spawnPoints[randomIndex].position, Quaternion.identity);
    }
}
