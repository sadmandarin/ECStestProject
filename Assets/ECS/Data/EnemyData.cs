using UnityEngine;

[CreateAssetMenu]
public class EnemyData : ScriptableObject
{
    public float speed;
    public GameObject EnemyPrefab;
    public float spawnTime;
    public int enemyCount;
    public float spawnDistance;

    public static EnemyData LoadFromAssets() => Resources.Load("Data/EnemyData") as EnemyData;
}
