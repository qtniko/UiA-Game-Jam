using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAbility : MonoBehaviour
{
    public GameObject bomb;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(bomb, transform.position,transform.rotation);
        }
    }

}
