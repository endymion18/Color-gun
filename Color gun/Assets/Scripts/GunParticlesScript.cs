using UnityEngine;

public class GunParticlesScript : MonoBehaviour
{
    //Управляет частицами которое выпускает Particle System (оружие)
    public Sprite[] sprites;
    public Transform gun;
    private SpriteRenderer _spriteRenderer;
    private Vector2 _psDirection;
    private static int _curWeapon;
    private ParticleSystem _particleSystem;
    private ParticleSystem.MainModule _main;

    private void Awake()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        _main = _particleSystem.main;
    }

    private void Update()
    {
        _curWeapon = WeaponChoosingScript.CurWeapon;
        _particleSystem.textureSheetAnimation.SetSprite(0, sprites[_curWeapon]);
        if (Input.GetMouseButtonDown(0)) _particleSystem.Play();
        if (Input.GetMouseButton(0))
            _main.startRotation = new ParticleSystem.MinMaxCurve(-gun.rotation.eulerAngles.z * Mathf.Deg2Rad);
        if (Input.GetMouseButtonUp(0)) _particleSystem.Stop();
    }
}