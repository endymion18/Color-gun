using UnityEngine;

public class WeaponRotationScript : MonoBehaviour
{
    //Меняет положение оружие в зависимости от положения курсора
    public Transform gun;
    private Vector2 _gunDirection;

    [SerializeField] private Camera mainCamera;

    private void Update()
    {
        var mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        var localScale = gun.localScale;

        _gunDirection = mousePos - gun.position;
        gun.transform.right = _gunDirection;
        localScale.y = mousePos.x < transform.position.x ? -1f : 1f;
        gun.localScale = localScale;
    }
}