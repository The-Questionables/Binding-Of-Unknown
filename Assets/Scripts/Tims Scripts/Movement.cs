using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Movement : MonoBehaviour
{
    public float Speed;
    public float RotationSpeed;
    public float SpeedUpTimer;
    public float SpeedUpValue= 1.5f;
    public float SlowDownValue= 0.3f;
    public float ShootSpeedUpValue = 2;
    public float dauer = 10f;

    void MoveLeft()
    {
        transform.position = transform.position + new Vector3( - Speed * Time.deltaTime, 0, 0);
    }

    void MoveRight()
    {
        transform.position = transform.position + new Vector3( + Speed * Time.deltaTime, 0, 0);
    }

    void MoveUp()
    {
        transform.position = transform.position + new Vector3(0, + Speed * Time.deltaTime, 0); 
    }

    void MoveDown()
    {
        transform.position = transform.position + new Vector3(0, - Speed * Time.deltaTime, 0);

    }
    
    void TurnLeft()
    {
        Vector3 rotation = transform.eulerAngles;
        rotation.z += Time.deltaTime * RotationSpeed;
        transform.eulerAngles = rotation;
    }

    void TurnRight()
    {
        Vector3 rotation = transform.eulerAngles;
        rotation.z += Time.deltaTime * -RotationSpeed;
        transform.eulerAngles = rotation;

    }


    void SpeedUp() { Speed *= SpeedUpValue; RotationSpeed *= SpeedUpValue; Time.timeScale = SlowDownValue; }
    void SpeedDown() { Speed *= 1f/ SpeedUpValue; RotationSpeed *= 1f/ SpeedUpValue; Time.timeScale = 1f;  }
    
    void MoveBullet()
    {
        transform.position += -transform.up* Time.deltaTime*Speed;
    }
    void MoveEnemyBullet()
    {
        transform.position += transform.up * Time.deltaTime * Speed;
    }

    void MoveTo(Vector2 position)
    {
        transform.position = position;
    }

}
