using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float destroyTime;
    float timer;
    private void Awake()
    {
        transform.parent = null;
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > destroyTime)
        {
            Destroy(gameObject);
        }
    }
}
