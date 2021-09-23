using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Image _livesImg;
    [SerializeField]
    private Sprite[] _liveSprites;
    [SerializeField]
    private Text _gameOverText;
    // Start is called before the first frame update
    void Start()
    {
        _gameOverText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(1);
        }
    }

    public void UpdateLives(int currentLives)
    {
        //acess the display image and give it a new one based on the current lives
        _livesImg.sprite = _liveSprites[currentLives];

        if ((currentLives) == 0)

            _gameOverText.gameObject.SetActive(true);


    }
}
