using UnityEngine;

public class ControllerScript : MonoBehaviour
{
    // variables are pascalCase (lower first letter, upper first letter second and beyond words)
    // class and funtions are camelCase (Upper first letter for each word)
    // public variables and functions are acessible everywhere
    // private variables and functions are only acessible to the class
    // protected variables and functions are available to the current class and its inheritted children
    // <optional> member variables can _pascalCase (with an underscore at the beginning)

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // public appears in the editor, easily changed, private no.

    public int _myValue = 0;
    [SerializeField]
    private float _speed = 0.0f;
    [SerializeField]
    private Vector2 _maxRange = Vector2.zero;

    private Vector2 _startingPoint = Vector2.zero;

    [SerializeField]
    private GameObject _dropItemPreFab = null;

    private void Awake()
    {
        _startingPoint = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        Vector2 endPos = transform.position;
        if (Input.GetKey(KeyCode.W))
        {
            endPos.y += _speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            endPos.x -= _speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            endPos.y -= _speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            endPos.x += _speed * Time.deltaTime;
        }
        endPos.x = Mathf.Clamp(endPos.x, _startingPoint.x - _maxRange.x, _startingPoint.x + _maxRange.x);
        endPos.y = Mathf.Clamp(endPos.y, _startingPoint.y - _maxRange.y, _startingPoint.y + _maxRange.y);
        transform.position = endPos;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // creates a copy of the prefab (new Instance)
            float rotate = Random.Range(0, 360);
            Quaternion rotationQuat = Quaternion.Euler(0, 0, rotate);
            GameObject newDropItem = Instantiate(_dropItemPreFab, transform.position, rotationQuat);
            Debug.Log("New Item Spawned" + newDropItem.name);
        }

    }
}
