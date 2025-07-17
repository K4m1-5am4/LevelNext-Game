using UnityEngine;

public class billboard : MonoBehaviour
{
    public Transform cam;
    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }
    private void LateUpdate()
    {
        transform.LookAt(transform.position+cam.forward);
    }
}
