using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ParticleCollision : MonoBehaviour, ISetParent
{
    private AimTarget target;
    private ParticleSystem particleEffect;
    public List<ParticleCollisionEvent> particleCollisionEvents;
    [SerializeField] private GameObject bulletHolePrefab;
    //[SerializeField] private Animator enemyAnimator;

    private void Awake()
    {
        particleEffect = GetComponent<ParticleSystem>();
    }
    private void Start()
    {
        particleCollisionEvents = new List<ParticleCollisionEvent>();
    }

    private void OnParticleCollision(GameObject other)
    {
        int numOfEvents = particleEffect.GetCollisionEvents(other, particleCollisionEvents);
        if (other.gameObject.GetComponent<AimTarget>())
        {
            target = other.gameObject.GetComponent<AimTarget>();
            target.TargetFalling();
        }
        else if (numOfEvents > 0)
        {
            if (other.gameObject.GetComponent<BulletHoleDummy>())
            {
                GameObject hole = Instantiate(bulletHolePrefab);
                hole.transform.position = particleCollisionEvents[0].intersection + particleCollisionEvents[0].normal * 0.1f;
                Destroy(hole.gameObject, 5f);
            }
        }
        /* For Ragdoll Animator Twitch

        bool hasAnimator = false;
        hasAnimator = other.gameObject.TryGetComponent<Animator>(out var animator);
        Debug.Log(hasAnimator);
        if(hasAnimator)
        {
            enemyAnimator = animator;
            Debug.Log("hit");
            animator.enabled = false;
        }
        */
        if (other.gameObject.GetComponent<ZombieEnemy>())
        {
            Debug.Log("enemy");
            Destroy(other.gameObject);
        }
    }
    
    public void ClearParent()
    {
        transform.parent = null;
    }

    public void SetParent(GameObject parentGameObject, GameObject childGameObject)
    {
        childGameObject.transform.parent = parentGameObject.transform;
    }
}
