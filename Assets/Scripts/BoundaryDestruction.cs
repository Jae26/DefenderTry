using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryDestruction : MonoBehaviour {

    void OnTriggerExit(Collider other)
    {
        //Destroy everything that leaves the area
        Destroy(other.gameObject);
    }
}
