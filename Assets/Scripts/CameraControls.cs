using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public float moveSpeed;

    private Camera _camera;
    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        var moveVector = Vector3.zero;
        
        if (Input.GetKey(KeyCode.W))
        {
          moveVector += Vector3.forward * moveSpeed * Time.deltaTime;  
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveVector += Vector3.left * moveSpeed * Time.deltaTime;  
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveVector += -Vector3.forward * moveSpeed * Time.deltaTime;  
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveVector += -Vector3.left * moveSpeed * Time.deltaTime;  
        }

        _camera.gameObject.transform.position += moveVector;
    }
}
