/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    public RoomSpawner currRoom;
    public float moveSpeedWhenRoomChange;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
    }

    void UpdatePosition()
    {
        if(currRoom == null)
        {
            return;
        }

        Vector3 targePos = GetCameraTargetPosition();
    }

    Vector3 GetCameraTargetPosition()
    {
        if(currRoom == null)
        {
            return Vector3.zero;
        }

        Vector3 targetPos = currRoom.GetRoomCentre();
    }
}
*/