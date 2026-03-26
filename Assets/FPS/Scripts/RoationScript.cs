using UnityEngine;

public class RoationScript : MonoBehaviour
{
    [SerializeField] private Transform referencePoint;
    void Start()
    {
        Debug.Log(referencePoint.right);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            transform.LookAt(-referencePoint.right, transform.up);
        }
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            transform.LookAt(referencePoint.right);
        }

        
    }
}
