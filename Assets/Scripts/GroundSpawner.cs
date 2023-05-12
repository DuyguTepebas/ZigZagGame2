using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] GameObject sonZemin;
    

    private void Start()
    {
        for (int i = 1; i < 20; i++)
        {
            ZeminOlustur();
        }
    }


    public void ZeminOlustur()
    {
        Vector3 yon;
        var random = Random.Range(0, 3);
        if (Random.Range(0,2) == 0)
        {
            yon = Vector3.left;
        }
        else
        {
            yon = Vector3.back;
        }
        sonZemin = Instantiate(sonZemin, sonZemin.transform.position + yon, sonZemin.transform.rotation);
        sonZemin.transform.GetChild(0).gameObject.SetActive(random == 0);
    }




}//class
