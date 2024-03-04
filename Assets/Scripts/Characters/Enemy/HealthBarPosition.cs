using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarPosition : MonoBehaviour
{
    public GameObject enemy;
    public float offset;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = Vector3.zero;
        transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y + offset, enemy.transform.position.z);
    }
}
