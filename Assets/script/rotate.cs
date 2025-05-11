using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class rotate : MonoBehaviour
{
    float rotationSpeed = 150f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDrag() 
    {
        float horizontal = Input.GetAxis("Mouse X");
        float yrot  = horizontal*Time.deltaTime*rotationSpeed;
        transform.Rotate(new Vector3(0, yrot, 0));
    }
}
