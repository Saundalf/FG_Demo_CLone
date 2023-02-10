using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject targetObject;
    public Vector3 Offstet;
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        transform.position = targetObject.transform.position + Offstet;
    }
}
