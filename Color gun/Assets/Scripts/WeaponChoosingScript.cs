using UnityEngine;

public class WeaponChoosingScript : MonoBehaviour
{
    //Выбор оружия
    public static int CurWeapon;
    public GameObject[] guns;

    private void Start()
    {
        foreach (var weapon in guns)
            weapon.SetActive(false);
        guns[CurWeapon].SetActive(true);
    }

    private void Update()
    {
        var prevWeapon = CurWeapon;
        if (!Input.GetMouseButton(0))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                CurWeapon = CurWeapon + 1 > 2 ? 0 : CurWeapon += 1;
                guns[CurWeapon].SetActive(true);
                guns[prevWeapon].SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                CurWeapon = CurWeapon - 1 < 0 ? 2 : CurWeapon -= 1;
                guns[CurWeapon].SetActive(true);
                guns[prevWeapon].SetActive(false);
            }
        }
    }
}