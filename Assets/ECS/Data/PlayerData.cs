using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerData : ScriptableObject
{
    public float speed;
    public GameObject playerPrefab;

    public static PlayerData LoadFromAssets() => Resources.Load("Data/PlayerData") as PlayerData;
}
