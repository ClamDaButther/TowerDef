using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    public bool isGrounded;
    
    
    
    void OnTriggerEnter(Collider other)
    {
        isGrounded = true;
    }

    void OnTriggerExit(Collider other)
    {
        isGrounded = false;
    }

    void Update() {

       
            if (Input.GetKey(KeyCode.W)) { transform.Translate(Vector3.forward * Time.deltaTime); }
            if (Input.GetKey(KeyCode.S)) { transform.Translate(Vector3.back * Time.deltaTime); }
            if (Input.GetKey(KeyCode.D)) { transform.Translate(Vector3.right * Time.deltaTime); }
            if (Input.GetKey(KeyCode.A)) { transform.Translate(Vector3.left * Time.deltaTime); }
        
    }
}
