using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] Transform tragetD, cam;
    [SerializeField] Vector3 offset;
    float degreeCam;

    // Start is called before the first frame update
    void Start()
    {
        tragetD = GameObject.FindGameObjectWithTag("MainCharacter").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = tragetD.position + offset;

    }
}
