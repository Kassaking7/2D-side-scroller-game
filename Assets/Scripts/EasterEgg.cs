using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEgg : MonoBehaviour
{
    public string easterEggPassword;
    public static string Password;

    public GameObject coin;
    public int coinQuantity;
    public float coinUpSpeed;
    public float intervalTime;
    // Start is called before the first frame update
    void Start()
    {
        Password = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Password == easterEggPassword)
        {
            Debug.Log("trigger easter egg!");
            Password = "";
            StartCoroutine(GenCoins());
        }
    }

    IEnumerator GenCoins()
    {
        WaitForSeconds wait = new WaitForSeconds(intervalTime);
        for (int i = 0; i < coinQuantity; i++)
        {
            GameObject gb = Instantiate(coin, transform.position, Quaternion.identity);
            Vector2 randomDirection = new Vector2(Random.Range(-0.3f,0.3f),1);
            gb.GetComponent<Rigidbody2D>().velocity = randomDirection * coinUpSpeed;
            yield return wait;
        }
    }
}
