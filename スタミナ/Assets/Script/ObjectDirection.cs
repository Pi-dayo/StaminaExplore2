using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDirection : MonoBehaviour
{
    PlayerDirection pD;
    // Start is called before the first frame update
    void Start()
    {
        pD = GameObject.Find("Player").GetComponent<PlayerDirection>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (pD.playerDirection)
        {
            case PlayerDirection.Direction.Up:
                transform.localPosition = new Vector2(0,1);
                transform.localEulerAngles= new Vector3(0,0,90);
                break;
            case PlayerDirection.Direction.UpRight:
                transform.localPosition = new Vector2(1, 1);
                transform.localEulerAngles = new Vector3(0, 0, 45);

                break;
            case PlayerDirection.Direction.Right:
                transform.localPosition = new Vector2(1, 0);
                transform.localEulerAngles = new Vector3(0, 0,0);

                break;
            case PlayerDirection.Direction.DownRight:
                transform.localPosition = new Vector2(1, -1);
                transform.localEulerAngles = new Vector3(0, 0,-45);

                break;
            case PlayerDirection.Direction.Down:
                transform.localPosition = new Vector2(0, -1);
                transform.localEulerAngles = new Vector3(0, 0, -90);

                break;
            case PlayerDirection.Direction.DownLeft:
                transform.localPosition = new Vector2(-1, -1);
                transform.localEulerAngles = new Vector3(0, 0, -135);

                break;
            case PlayerDirection.Direction.Left:
                transform.localPosition = new Vector2(-1, 0);
                transform.localEulerAngles = new Vector3(0, 0, 180);

                break;
            case PlayerDirection.Direction.UpLeft:
                transform.localPosition = new Vector2(-1, 1);
                transform.localEulerAngles = new Vector3(0, 0, 135);

                break;
        }
    }
}
