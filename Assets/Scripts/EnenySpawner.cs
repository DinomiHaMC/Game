using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnenySpawner : MonoBehaviour
{
    private Terrain _terrain;
    private Vector3 _terrainPos;

    [SerializeField] private LightScript _light;
    [SerializeField] private float _minSpawnTime;
    [SerializeField] private float _maxSpawnTime;
    [SerializeField] private float _despawnTime;

    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform _parent;
    [SerializeField] private Transform _pos1;
    [SerializeField] private Transform _pos2;
    [SerializeField] private int _maxCount;
    [SerializeField] private int _minCount;
    [SerializeField] private int _count;
    [SerializeField] private bool _spawnFlag;

    [SerializeField] private List<GameObject> _enemysList;
    private void Start()
    {
        _terrain = GetComponent<Terrain>();
        _terrainPos = _terrain.transform.position;
    }

    private void Update()
    {
        if(_light.DayTime >= _minSpawnTime && _light.DayTime <= _maxSpawnTime && _spawnFlag)
        {
            _spawnFlag = false;
            SpawnEnemys();
        }

        else if (_light.DayTime >= _despawnTime && _light.DayTime <= _minSpawnTime - 0.1 && _enemysList.Count > 0)
        {
            _spawnFlag = true;
            foreach (Transform child in _parent)
            {
                Destroy(child.gameObject);
            }
            _enemysList.Clear();
        }
    }

    public void SpawnEnemys()
    {
        foreach (Transform child in _parent)
        {
            Destroy(child.gameObject);
        }

        _count = Random.Range(_minCount, _maxCount);

        for (var i = 0; i < _count; i++)
        {
            var randX = Random.Range(_pos1.position.x, _pos2.position.x);
            var randZ = Random.Range(_pos1.position.z, _pos2.position.z);
            float y = _terrain.SampleHeight(new Vector3(randX, 0, randZ)) + _terrainPos.y + 2;
            var pos = new Vector3(randX, y, randZ);
            print(pos);
            var spawn = Instantiate(_enemy, pos, Quaternion.identity);
            spawn.transform.SetParent(_parent);
            _enemysList.Add(spawn);
        }
    }
}
