using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ball : MonoBehaviour
{
    Rigidbody rb;
    bool isforce = false;
    int score = 0;
    public GameObject winPanel,losspanal;
    public Text scoredisplay;
    int levelno = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        winPanel.SetActive(false);
        losspanal.SetActive(false);
        levelno = PlayerPrefs.GetInt("levelno", 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (isforce)
        {
            addforcetoball();
        }
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<MeshCollider>() != null)
        {
            isforce = true;
        }
        if (collision.gameObject.CompareTag("win"))
        {
            winPanel.SetActive(true);
        }
        if(collision.gameObject.CompareTag("pink"))
        {
            losspanal.SetActive(true);
        }
    }
    void addforcetoball()
    {
        if(isforce)
        {
            isforce = false;
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.up * 150f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("score"))
        {
            score = score + 100;
            scoredisplay.text = "" + score;
        }
    }
    public void nextlevel()
    {
        PlayerPrefs.SetInt("levelno",levelno+1);
        SceneManager.LoadScene("l" + (levelno + 1));
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag=="score")
        {
           Transform perentobj = other.transform.parent.transform;
            if(perentobj!=null)
            {
                foreach(Transform child in perentobj)
                {
                    child.GetComponent<MeshCollider>().convex = true;
                    child.GetComponent<Rigidbody>().isKinematic = false;
                    Destroy(child.gameObject,0.5f);
                }
            }
        }
    }
}
