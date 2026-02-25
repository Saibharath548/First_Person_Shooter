using TMPro;
using UnityEngine;

public class BulletsUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentGunBulletStats;
    [SerializeField] private GunController gunController;

    private void Update()
    {
        currentGunBulletStats.text = "0" + gunController.RemainingBullet(); //+ "/" + gunController.BulletsPerMagzine());
    }
}
