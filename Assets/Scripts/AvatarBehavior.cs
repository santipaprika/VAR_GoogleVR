﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarBehavior : MonoBehaviour
{
    void Update()
    {
        Quaternion camYaw = Quaternion.Euler(0, Camera.main.transform.rotation.eulerAngles.y, 0);
        transform.rotation = camYaw;
        transform.position = new Vector3(Camera.main.transform.position.x, 0, Camera.main.transform.position.z) - 0.15f*(camYaw * Vector3.forward).normalized;
    }
}
