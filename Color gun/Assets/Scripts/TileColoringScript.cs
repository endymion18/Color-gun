using UnityEngine;
using UnityEngine.Tilemaps;

public class TileColoringScript : MonoBehaviour
{
    // Отвечает за покраску тайлов в процессе игры
    private static int _curWeapon;
    private ParticleCollisionEvent[] _collisionEvents = new ParticleCollisionEvent[5];
    private Vector3Int collisionHitLoc;
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private TileBase[] tiles;
    private ParticleSystem _particleSystem;

    private void Awake()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        _curWeapon = WeaponChoosingScript.CurWeapon;
    }

    private void OnParticleCollision(GameObject other)
    {
        {
            var safeLength = _particleSystem.GetSafeCollisionEventSize();
            if (_collisionEvents.Length < safeLength)
                _collisionEvents = new ParticleCollisionEvent[safeLength];
            var numCollisionEvents = _particleSystem.GetCollisionEvents(other, _collisionEvents);
            var i = 0;
            while (i < numCollisionEvents)
            {
                var hit = _collisionEvents[i].intersection;
                collisionHitLoc = tilemap.WorldToCell(hit);
                i++;
                NearestTile(true);
                NearestTile(false);
                if (tilemap.HasTile(collisionHitLoc) && tilemap.GetTile(collisionHitLoc) != tiles[3] &&
                    tilemap.GetTile(collisionHitLoc) != tiles[4])
                    tilemap.SetTile(collisionHitLoc, tiles[_curWeapon]);
            }
        }
    }

    //объеденить в один метод
    private void NearestTile(bool isNearestTileByX)
    {
        var ratio = isNearestTileByX ? new[] { 0, 1, -1 } : new[] { -1, 0 };
        foreach (var r in ratio)
        {
            var tempHitLoc = collisionHitLoc;
            if (isNearestTileByX) tempHitLoc.x += r;
            else tempHitLoc.y += r;
            if (tilemap.HasTile(tempHitLoc) && tilemap.GetTile(tempHitLoc) != tiles[3])
                collisionHitLoc = tempHitLoc;
        }
    }
}