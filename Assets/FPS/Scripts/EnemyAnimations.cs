using System.Collections;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    [SerializeField] private Animator enemyAnimator;
    private bool temp;

    private void Start()
    {
        temp = true;
    }

    public void InitiateAgonization()
    {
        if (temp)
        {
            StartCoroutine(ZombieAgonizingCounter());
        }
    }

    IEnumerator ZombieAgonizingCounter()
    {
        temp = false;
        yield return new WaitForSeconds(5);
        enemyAnimator.SetTrigger("PlayerSpotted");
        temp = true;
    }
}
