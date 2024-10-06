using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using Zenject;

public class CameraFollowing : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;

    public void Init(Transform transform)
    {
       _virtualCamera.Follow = transform;
    }

}
