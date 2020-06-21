using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject MorningLights;

    public GameObject EveningLights;

    public GameObject Fontein;

    public GameObject player;

    public bool Ochtend;  // Aan en uit zetten van de dag.

    private void Start()
    {
        Ochtend = true;
        MorningLights.gameObject.SetActive(true);
        EveningLights.gameObject.SetActive(false);
    }


    private void Update()
    {
        if (Ochtend)
        {
            EveningLights.gameObject.SetActive(false);
            MorningLights.gameObject.SetActive(true);
        }else if (!Ochtend)
        {
            EveningLights.gameObject.SetActive(true);
            MorningLights.gameObject.SetActive(false);
        }
    }

    public void SwitchScript()
    {
        if (Ochtend == true)
        {
            Ochtend = false;
        }
        else if (Ochtend == false)
        {
            Ochtend = true;
        }
    }
}
