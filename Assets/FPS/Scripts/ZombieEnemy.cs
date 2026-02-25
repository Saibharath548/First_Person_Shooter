using UnityEngine;

public class ZombieEnemy : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    [SerializeField] private Rigidbody rb;
    //private ZombieEnemy zE;
    //[SerializeField] private Animator zEAnim;
    private void Awake()
    {
        //zE = GetComponent<ZombieEnemy>();
    }

    private void Update()
    {
        //zE.enabled = zEAnim.isActiveAndEnabled;
        transform.position = Vector3.MoveTowards(transform.position, playerPos.position, Time.deltaTime * 2);
        Vector3 rotateDir = playerPos.position - transform.position;
        transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, rotateDir, Time.deltaTime * 2 , 0));
    }
}
