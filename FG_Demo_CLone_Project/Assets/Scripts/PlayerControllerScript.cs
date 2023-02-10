using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerControllerScript : MonoBehaviour
{

    private Rigidbody2D _rigidbody;
    private float speed = 3.0f;
    // Start is called before the first frame update
    private void Start()
    {
        _rigidbody= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void onMove(InputValue inputValue)
    {
        
    }

}
