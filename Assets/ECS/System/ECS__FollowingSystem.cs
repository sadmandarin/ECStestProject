using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Scellecs.Morpeh;
using TMPro;
using Unity.VisualScripting;
using System.Collections.Generic;
using static UnityEngine.EventSystems.EventTrigger;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(ECS__FollowingSystem))]
public sealed class ECS__FollowingSystem : UpdateSystem {
    Filter filter;
    float timer;
    Filter playerFilter;

    List<GameObject> enemies;
    public override void OnAwake()
    { 
        timer = EnemyData.LoadFromAssets().spawnTime;

        SpawnEnemy();
    }

    public override void OnUpdate(float deltaTime) 
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && enemies.Count < EnemyData.LoadFromAssets().enemyCount)
        {
            timer = EnemyData.LoadFromAssets().spawnTime;

            SpawnEnemy();
        }

        filter = this.World.Filter.With<MovingComponent>().With<FollowingComponent>().Build();

        foreach (var entity in filter)
        {

            var folowing = entity.GetComponent<FollowingComponent>();

            var moving = entity.GetComponent<MovingComponent>();

            if (moving.transform != null)
            {
                Vector3 direction = (folowing.target.position - moving.transform.position).normalized;

                moving.transform.position += moving.moveSpeed * direction * Time.deltaTime;
            }

            
            
        }
    }

    public override void Dispose()
    {
        enemies.Clear();
    }

    void SpawnEnemy()
    {
        playerFilter = this.World.Filter.With<MovingComponent>().With<InputComponent>().Build();

        var enemy = this.World.CreateEntity();

        ref var enemyMove = ref enemy.AddComponent<MovingComponent>();

        ref var enemyTarget = ref enemy.AddComponent<FollowingComponent>();

        enemyMove.moveSpeed = EnemyData.LoadFromAssets().speed;

        foreach (var entit in playerFilter)
        {
            var movin = entit.GetComponent<MovingComponent>();

            enemyTarget.target = movin.transform;
        }

        var spawnPos = enemyTarget.target.position + new Vector3(Random.Range(1, EnemyData.LoadFromAssets().spawnDistance),
                                                                 Random.Range(1, EnemyData.LoadFromAssets().spawnDistance), 0);

        var enemyPref = GameObject.Instantiate(EnemyData.LoadFromAssets().EnemyPrefab, spawnPos, Quaternion.identity);

        enemies.Add(enemyPref);

        enemyMove.transform = enemyPref.transform;
    }
}