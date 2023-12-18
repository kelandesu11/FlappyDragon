using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject g = Instantiate(gameObject);
        float x = transform.position.x + 40;
        int y = Random.Range(0, 10);
        g.transform.position = new Vector3(x, y, 0);
    }
}
