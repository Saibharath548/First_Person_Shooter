using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    [SerializeField] private GameObject body;

    private void Update()
    {
        transform.position = body.transform.position;
    }
}
