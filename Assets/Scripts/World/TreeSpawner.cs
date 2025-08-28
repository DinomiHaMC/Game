using UnityEngine;
using static UnityEditor.PlayerSettings;

public class TreeSpawner : MonoBehaviour
{
    private Terrain _terrain;
    private Vector3 _terrainPos;

    [SerializeField] private GameObject _tree;
    [SerializeField] private Transform _parent;
    [SerializeField] private Transform _pos1;
    [SerializeField] private Transform _pos2;
    [SerializeField] private int _maxCount;
    [SerializeField] private int _minCount;
    [SerializeField] private int _count;
    private void Start()
    {
        _terrain = GetComponent<Terrain>();
        _terrainPos = _terrain.transform.position;

        SpawnTrees();
    }

    public void SpawnTrees()
    {
        foreach(Transform child in _parent)
        {
            Destroy(child.gameObject);
        }

        _count = Random.Range(_minCount, _maxCount);

        for(var i = 0; i<_count; i++)
        {
            var randX = Random.Range(_pos1.position.x, _pos2.position.x);
            var randZ = Random.Range(_pos1.position.z, _pos2.position.z);
            float y = _terrain.SampleHeight(new Vector3(randX, 0, randZ)) + _terrainPos.y;
            var pos = new Vector3(randX, y, randZ);
            var spawn = Instantiate(_tree, pos, Quaternion.identity);
            spawn.transform.SetParent(_parent);
        }
    }
}
