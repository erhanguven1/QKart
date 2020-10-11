using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void Update()
    {
        if (transform.position.z<Camera.main.transform.position.z)
        {
            OnLimitReached();
        }
    }

    void OnLimitReached()
    {
        Pooling.Instance.Despawn(gameObject);
    }
}
