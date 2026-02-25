using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private PlayerCharacterController playerReference;
    [SerializeField] private GunController gunControllerReference;
    [SerializeField] private PlayerInputActions playerInputs;
    [SerializeField] private Animator handAnimator;
    private bool reloading;

    private void Start()
    {
        handAnimator = GetComponent<Animator>();
        playerInputs.OnShooting += OnShooting;
        playerInputs.OnReload += OnPlayerReload;
        reloading = false;
    }

    private void OnPlayerReload(object sender, System.EventArgs e)
    {
        gunControllerReference.GunReload();
        handAnimator.SetTrigger("Reload");
    }

    private void Update()
    {
        if (playerReference.GetPlayerCurrentVelocity() != Vector3.zero)
        {
            handAnimator.SetFloat("Motion", 1);
        }
        else
        {
            handAnimator.SetFloat("Motion", 0);
        }
    }

    private void OnShooting(object sender, System.EventArgs e)
    {
        if (!reloading)
        {
            if (gunControllerReference.RemainingBullet() > 0)
            {
                handAnimator.SetTrigger("Fire");
            }
        }
    }

    public void ReloadEvent()
    {
        if (gunControllerReference.RemainingBullet() <= 0)
        {
            gunControllerReference.GunReload();
            reloading = true;
            handAnimator.SetTrigger("Reload");
            Invoke("ReloadTwitch", 1.5f);
        }
    }

    private void ReloadTwitch()
    {
        reloading = false;
    }

    public void FireMethod()
    {
        gunControllerReference.FireFunction();
    }
}
