using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collecting : MonoBehaviour
{

    //public GameObject muntje;
    public bool collission;
    public bool used = false;
    public int teller;
    // Start is called before the first frame update
    private void Start()
    {
        teller = 0;
        collission = false;
    }

    private void Update()
    {
        if(teller == 5)
        {
            SceneManager.LoadScene("Menu");
        }
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Muntjes" && collission == false)
        {
            collission = true;
            Debug.Log("test");
            hit.gameObject.SetActive(false);

            teller++;
        }
        else
        {
            collission = false;
        }
    }
}