using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooling : MonoBehaviour
{
    public static Pooling Instance;
    private void Awake()
    {
        Instance = this;
    }

    public void Despawn(GameObject despawn)
    {

        despawn.transform.position += (10 -despawn.transform.position.z + LevelGenerator.Instance.lastObstacle.transform.position.z)* Vector3.forward;
        LevelGenerator.Instance.lastObstacle = despawn;
    }
}
