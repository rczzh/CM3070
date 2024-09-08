using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance;

    public int scoreValue = 0;
    Text scoreText;

    public AudioSource src;
    public AudioClip sfx;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.Find("Score").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int amount)
    {
        scoreValue += amount;
        scoreText.text = scoreValue.ToString();

        gameObject.GetComponent<Inventory>().UpdateInventory(amount);

        src.clip = sfx;
        src.Play();
    }
}
