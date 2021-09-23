using System.Collections;//namespace Unity default
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //variable requirements - public or private reference, data type (int, float, bool, string), a name. Optional value assigned.
    [SerializeField]
    private float _speed = 2.5f; //float is a number a decimial and we're creating the _speed variable with a 2.5 value
    // Start is called before the first frame update
    [SerializeField]
    private GameObject _laserPrefab;

    private int _lives = 3; //Setting our lives to a value of 3 to start

    private SpawnManager _spawnManager;

    private UIManager _uiManager;
    void Start()
    {
        //player star position = (0, 0, 0)
        transform.position = new Vector3(0, 0, 0); //acess transform component to set new postition to 0, 0, 0
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        //if the space button is pushed then the laser gets instantiated (created)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 1.05f, 0), Quaternion.identity);
        }
    }

    void PlayerMovement()
    {
        float horizontalinput = Input.GetAxis("Horizontal"); //defining the horizontal input variable and using Unity default name
        float verticalinput = Input.GetAxis("Vertical"); //define vertical input variable using unity default name

        transform.Translate(Vector3.right * horizontalinput * _speed * Time.deltaTime); //new Vector3 (1, 0, 0) * player horizontal input * speed variable * real time
        transform.Translate(Vector3.up * verticalinput * _speed * Time.deltaTime); //create transform.translate for vertical input

        //if the player's y value is > 5.9 or < -3.9 the player will stop at those locations
        if (transform.position.y >= 5.9f)
        {
            transform.position = new Vector3(transform.position.x, 5.9f, 0);
        }
        else if (transform.position.y <= -3.9f)
        {
            transform.position = new Vector3(transform.position.x, -3.9f, 0);
        }

        if (transform.position.x >= 9.24)

        {
            transform.position = new Vector3(9.24f, transform.position.y, 0);
        }
        else if (transform.position.x <= -9.24f)
        {
            transform.position = new Vector3(-9.24f, transform.position.y, 0);
        }
    }
        public void Damage()
        {
            _lives -= 1;
        _uiManager.UpdateLives(_lives);

            if (_lives < 1)
            {
            _spawnManager.OnPlayerDeath(); 
            Destroy(this.gameObject);
            }
        }
    
}


