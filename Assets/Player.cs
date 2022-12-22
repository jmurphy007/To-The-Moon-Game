using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
	public int maxHealth = 100;
	public int currentHealth = 100;

	public HealthBar healthBar;
	public AudioSource zap;

	private float y;
	private float startY;
	[SerializeField] TextMeshProUGUI heightText;

	public float addY = 250;

	public AudioSource soundUI;

	[SerializeField] private GameObject moreClouds;

	void Start()
	{
		startY = transform.position.y;
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			loadMenu();
		}

		y = transform.position.y;
		setHeightText();

		
		if (y >= (addY + startY))
		{
			startY += addY;
			addMore();
		}
	}

	void addMore()
    {
		float startX = -25.35574f;
		float startZ = 12.626f;
		Instantiate(moreClouds, new Vector3(startX, startY, startZ), (Quaternion.identity * moreClouds.transform.localRotation));
		
		if (currentHealth < maxHealth)
        {
			currentHealth += 10;
			displayHealth();
        }
	}

	void setHeightText()
    {
		int height = (int)y;
		if (height <= 0)
        {
			height = 0;
        }
		heightText.text = "Height: " + height + "FT";
    }

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Storm")
        {
			TakeDamage(10);
			zap.Play();
		}
	}

	void TakeDamage(int damage)
	{
		currentHealth -= damage;
		displayHealth();
		if (currentHealth < 0)
		{
			Debug.Log("LOST!");
			loadMenu();
		}
    }

	void displayHealth()
    {
		if (currentHealth > maxHealth)
        {
			currentHealth = maxHealth;
        }
		healthBar.SetHealth(currentHealth);
	}

	void loadMenu()
    {
		soundUI.Play();
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}
}