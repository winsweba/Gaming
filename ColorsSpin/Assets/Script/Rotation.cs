using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float speed = 5;
    void Update()
    {
        transform.Rotate(0f, 0f, speed * Time.deltaTime);
    }
}
