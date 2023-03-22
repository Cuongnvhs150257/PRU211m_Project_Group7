using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManage : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject tieuLien;
    public GameObject shotgun;
    public GameObject sungLuc;
    void Start()
    {
        sungLuc.SetActive(true);
        shotgun.SetActive(false);
        tieuLien.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject mainCharacter=GameObject.FindGameObjectWithTag("Player");
        if(mainCharacter.GetComponent<ManageLevel>().Level >= 5)
        {
            tieuLien.SetActive(true);
        }
        if (mainCharacter.GetComponent<ManageLevel>().Level >= 15)
        {
            shotgun.SetActive(true);
        }

    }
}
