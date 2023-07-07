using UnityEngine;

public class Building : MonoBehaviour
{

    private bool _active;
    // Start is called before the first frame update
    private void OnEnable()
    {
        _active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!_active) return;
    }

    public void Place()
    {
        _active = true;
    }
}
