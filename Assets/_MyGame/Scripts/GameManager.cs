using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI m_TextMeshProUGUI;
    private int count = 0;
    [SerializeField]
    private GameObject coinBase;

    void Start()
    {
        for (int i = 0; i < 10; i++)
        { 
            Vector3 randPos = Random.insideUnitSphere;
            GameObject newObject = Instantiate(coinBase);
            newObject.transform.position = randPos;
        }
    }

    
    void Update()
    {
        
    }
}
