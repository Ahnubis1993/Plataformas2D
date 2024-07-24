using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSCameraController : MonoBehaviour
{
    public Vector2 minPos, maxPos;
    public Transform Target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float xPos = Mathf.Clamp(Target.position.x, minPos.x, maxPos.x);
        float yPos = Mathf.Clamp(Target.position.y, minPos.y, maxPos.y);

        transform.position = new Vector3(xPos, yPos, transform.position.z);
    }
}
