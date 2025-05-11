using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ringgem : MonoBehaviour
{
    public Material[] ringgemMaterial;
    public string[] alltags;
    // Start is called before the first frame update
    void Start()
    {
        generatering();
    }

    // Update is called once per frame
  /*  void Update()
    {
        
    }
    void generatering()
    {
        foreach(Transform child in transform)
        {
            int r = Random.Range(0, ringgemMaterial.Length);
            child.tag = alltags[r];
            if(r==2) // r is matereal length 
            {
                child.GetComponent<MeshRenderer>().enabled = false;
                child.GetComponent<MeshCollider>().convex = true;
                child.GetComponent<MeshCollider>().isTrigger = true;

                child.transform.position = new Vector3(transform.position.x, transform.position.y - 0.3f, transform.position.z);
            }
            else
            {
                child.GetComponent <Renderer>().material = ringgemMaterial[r];
            }
        }
    }*/
    void generatering()
    {
        int index = 0;
        foreach (Transform child in transform)
        {
            if (index == 0) // First ring
            {
                child.tag = alltags[0]; // Assign a specific tag if needed
                child.GetComponent<Renderer>().material = ringgemMaterial[0]; // Set blue material
            }
            else
            {
                int r = Random.Range(0, ringgemMaterial.Length);
                child.tag = alltags[r];

                if (r == 2) // r is material length (if special behavior is required)
                {
                    child.GetComponent<MeshRenderer>().enabled = false;
                    child.GetComponent<MeshCollider>().convex = true;
                    child.GetComponent<MeshCollider>().isTrigger = true;
                    child.transform.position = new Vector3(transform.position.x, transform.position.y - 0.3f, transform.position.z);
                }
                else
                {
                    child.GetComponent<Renderer>().material = ringgemMaterial[r];
                }
            }
            index++;
        }
    }
}
