using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yariprehab : MonoBehaviour
{
    public GameObject yari;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Z))
        {
            Instantiate(yari, this.transform.position, Quaternion.identity);

        }
    }
}
