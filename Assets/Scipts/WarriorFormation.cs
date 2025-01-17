using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorFormation : MonoBehaviour
{
    public GameObject warrior;
    public int lineWidth = 10;
    public int lineLength = 4;
    void Start()
    {
        for (int z = 0; z <lineWidth; z++)
        {
            for (int x = 0; x <lineLength; x++)
            {
                Instantiate(warrior, new Vector3(x,1,z), Quaternion.identity);
            }
        
        }
    }
}
