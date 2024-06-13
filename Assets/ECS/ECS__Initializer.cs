using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Scellecs.Morpeh;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Initializers/" + nameof(ECS__Initializer))]
public sealed class ECS__Initializer : Initializer {

    private World world;
    Entity player;

    public override void OnAwake()
    {
        world = World.Create();

        player = this.World.CreateEntity();

        ref var moving = ref player.AddComponent<MovingComponent>();

        ref var input = ref player.AddComponent<InputComponent>();

        var spawnPlayer = GameObject.Instantiate(PlayerData.LoadFromAssets().playerPrefab, Vector2.zero, Quaternion.identity);

        moving.moveSpeed = PlayerData.LoadFromAssets().speed;

        moving.transform = spawnPlayer.transform;
    }

    public override void Dispose() 
    {
        this.world.RemoveEntity(player);
    }
}