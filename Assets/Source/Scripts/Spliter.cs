using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spliter : MonoBehaviour
{
    [SerializeField] private Splitable _template;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private List<Material> _materials;
    [SerializeField] private int _minNumberOfCubes = 2;
    [SerializeField] private int _maxNumberOfCubes = 6;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity) &&
                hit.collider.TryGetComponent(out Splitable splitable))
            {
                Split(splitable);
                Destroy(splitable.gameObject);
            }
        }
    }
    
    private void Split(Splitable splitable)
    {
        int chance = Random.Range(0, 100);

        if (chance < splitable.SplitChance)
        {
            int amountNewCubes = Random.Range(_minNumberOfCubes, _maxNumberOfCubes);

            List<Rigidbody> splittavleBodies = new List<Rigidbody>();

            for (int i = 0; i < amountNewCubes; i++)
            {
                Material newRandomMaterial = _materials[Random.Range(0, _materials.Count)];
                Splitable newSplittable = Instantiate(_template, splitable.transform.position, Quaternion.identity);
                newSplittable.Init(splitable.SplitChance / 2, newRandomMaterial, splitable.transform.localScale / 2);
                splittavleBodies.Add(newSplittable.Rigidbody);
            }

            _exploder.Explode(splittavleBodies);
        } 
    }
}