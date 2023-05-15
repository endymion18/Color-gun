using UnityEngine;
using UnityEngine.Tilemaps;

public class TileProperties : MonoBehaviour
{
    //изменение свойств игрока в зависимости от тайла
    private Tilemap _tilemap;
    private float _speedDefault;
    private float _jumpDefault;
    private Vector3Int playerPos;
    [SerializeField] private Transform player;
    [SerializeField] private TileBase[] tiles;

    private void Start()
    {
        _tilemap = GetComponent<Tilemap>();
        _speedDefault = CharacterController.Speed;
        _jumpDefault = CharacterController.JumpForce;
    }

    private void Update()
    {
        playerPos = _tilemap.WorldToCell(player.position);
        CheckTile(playerPos);
    }

    private void CheckTile(Vector3Int playerPosition)
    {
        NearestWall(playerPosition);
        playerPosition.y -= 1;
        var tile = _tilemap.GetTile(playerPosition);
        switch (tile)
        {
            case var value when value == tiles[0]:
            {
                CharacterController.Speed = 15f;
                CharacterController.JumpForce = _jumpDefault;
                break;
            }
            case var value when value == tiles[1]:
            {
                CharacterController.Speed = _speedDefault;
                CharacterController.JumpForce = 15f;
                break;
            }
            case var value when value == tiles[3] || value == tiles[2]:
            {
                CharacterController.Speed = _speedDefault;
                CharacterController.JumpForce = _jumpDefault;
                break;
            }
        }
    }

    private void NearestWall(Vector3Int playerPosition)
    {
        var tempPlayerPos = playerPosition;
        tempPlayerPos.x += (int)CharacterController.Horizontal;
        var tile = _tilemap.GetTile(tempPlayerPos);
        CharacterController.IsNextToBlueWall = tile == tiles[2];
    }
}