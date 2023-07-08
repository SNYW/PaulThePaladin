using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaulCam : MonoBehaviour
{
    private GameObject _paul;
    public Vector2 offset;
    // Start is called before the first frame update
    void Start()
    {
        _paul = GameObject.Find("Paul");
    }

    // Update is called once per frame
    void Update()
    {
        var newPos = new Vector3(_paul.transform.position.x+offset.x, transform.position.y, _paul.transform.position.z+offset.y);
        transform.position = newPos;
    }
}
