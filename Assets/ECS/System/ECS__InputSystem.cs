using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Scellecs.Morpeh;
using Unity.Collections.LowLevel.Unsafe;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(ECS__InputSystem))]
public class ECS__InputSystem : UpdateSystem {
    private Filter filter;
    public override void OnAwake() 
    {
        filter = this.World.Filter.With<InputComponent>().With<MovingComponent>().Build();
    }

    public override void OnUpdate(float deltaTime)
    {
        var x = Input.GetAxis("Horizontal");

        var y = Input.GetAxis("Vertical");

        foreach (var entity in filter)
        {
             var input =  entity.GetComponent<InputComponent>();

             var movingComp =  entity.GetComponent<MovingComponent>();

            if (movingComp.transform != null)
            {
                input.playerInput = new Vector2(x, y);

                movingComp.transform.position += input.playerInput * movingComp.moveSpeed * Time.deltaTime;
            }

            
        }

        
    }
}