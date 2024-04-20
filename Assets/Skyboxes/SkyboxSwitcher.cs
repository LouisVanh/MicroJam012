using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkyboxSwitcher : MonoBehaviour
{
    [SerializeField] private List<Material> _materials;
    private int _counter;
    private Object[] _skyboxes;
    private TMP_Text _text; // set quick preview name on canvas
    private bool _autoSwitch;
    private float _autoSwitchTimer;

    // Start is called before the first frame update
    void Start()
    {
        _text = GameObject.FindObjectOfType<TMP_Text>();
        _skyboxes = Resources.LoadAll("SkyboxList");

        foreach (var t in _skyboxes)
        {
            _materials.Add((Material) t);
        }

        _text.text = _materials[_counter].name;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _autoSwitch = !_autoSwitch;
        }

        if (_autoSwitch)
        {
            _autoSwitchTimer += Time.deltaTime;
            if (_autoSwitchTimer > 1)
            {
                NextSkybox();
                _autoSwitchTimer = 0;
            }
        }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PreviousSkybox();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            NextSkybox();
        }
    }

    private void PreviousSkybox()
    {
        if (_counter == 0) _counter = _materials.Count;
        _counter--;
        RenderSettings.skybox = _materials[_counter];
        _text.text = _materials[_counter].name;
    }

    private void NextSkybox()
    {
        if (_counter == _materials.Count - 1) _counter = 0;
        else _counter++;
        RenderSettings.skybox = _materials[_counter];
        _text.text = _materials[_counter].name;
    }
}
