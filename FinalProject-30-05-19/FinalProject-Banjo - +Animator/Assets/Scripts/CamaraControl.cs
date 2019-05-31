using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraControl : MonoBehaviour
{
    public Transform character;
    public Transform character1;
    public Transform select;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
   {
        if (character.gameObject.activeSelf)
        {
            select = character;
        }
        if (character1.gameObject.activeSelf)
        {
            select = character1;
        }
        if (select != null)
        {
            if (select.position.y >= -16.84f)
            {
                transform.position = new Vector3(select.position.x, select.position.y + 7, -1);
            }
            else
            {
                transform.position = new Vector3(select.position.x, -10.84f, -1);
            }
        }
    }
}
