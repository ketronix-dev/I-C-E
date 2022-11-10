using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private Camera _camera;
    void Start()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(_camera.transform.position.x, _camera.transform.position.y, 30);
    }
}
