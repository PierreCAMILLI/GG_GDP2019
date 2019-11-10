using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heros : MonoBehaviour
{
    [SerializeField]
    private Transform[] _heros;
    public Transform[] HeroList
    {
        get { return _heros; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < _heros.Length; ++i)
        {
            _heros[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < Controls.Instance.GamePads.Count; ++i)
        {
            _heros[i].gameObject.SetActive(true);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        foreach(Transform hero in _heros)
        {
            Gizmos.DrawCube(hero.position, Vector3.one);
        }
    }
}
