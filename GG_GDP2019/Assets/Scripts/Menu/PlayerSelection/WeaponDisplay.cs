using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WeaponDisplay : MonoBehaviour
{
    [SerializeField]
    private int _selectedImage = 0;

    public int Number;

    public int SelectedImage
    {
        get { return _selectedImage; }
        set { _selectedImage = value; }
    }

    [SerializeField]
    private List<RectTransform> _images;

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ChangeWeapon(0);
        _images.ForEach(i => i.gameObject.SetActive(false));
        _images[_selectedImage].gameObject.SetActive(true);
    }

    public void ChangeWeapon(int i)
    {
        _selectedImage += i;
        if (_selectedImage < 0)
            _selectedImage = _images.Count-1;
        else if (_selectedImage >= _images.Count)
            _selectedImage = 0;
    }
}
