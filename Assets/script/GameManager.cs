using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _Instance;
    public static GameManager instance
    {
        get
        {
            if(_Instance == null)
            {
                _Instance = FindObjectOfType<GameManager>();
            }
            return _Instance;
        }
    }
    [SerializeField]
    private GameObject donut;
    [SerializeField]
    private GameObject bomb;

    private int score;
    private int BestScore;
    public void Score()
    {
        score++; //��������
        if(score > BestScore) //���� ���� ������ �ְ� �������� Ŀ����
        {
            BestScore = score; //�ְ������� ���������� ����.
            PlayerPrefs.SetInt("BestScore", BestScore); //����
        }
        scoreTxt.text = "score : " + score;
        BestscoreTxt.text = "Bestscore : " + BestScore;
    }

    [SerializeField]
    private Text scoreTxt;
    [SerializeField]
    private Text BestscoreTxt;
    public void GameOver()
    {
        if (score > PlayerPrefs.GetInt("best", 0))
        PlayerPrefs.SetInt("best", score);

        SceneManager.LoadScene("EndScene");  
    }
    public void Start()
    {
        BestScore = PlayerPrefs.GetInt("BestScore", 0); //����� �����͸� �ҷ��ͼ� �ְ����� ������ ���� �־���.
        StartCoroutine(CreatedonutRoutine());
        StartCoroutine(CreatebombRoutine());
        
    }

    IEnumerator CreatedonutRoutine()
    {
        while (true)
        {
            Createdonut();
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator CreatebombRoutine() //���ð�
    {
        while (true)
        {
            Createbomb();
            yield return new WaitForSeconds(3); //���ð� 3���� ����
        }
    }

    private void Createdonut()
    {
        Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0.0f, 1.0f), 1.1f, 0));
        pos.z = 0.0f;
        Instantiate(donut, pos, Quaternion.identity);
    }

    private void Createbomb()
    {
        Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0.0f, 1.0f), 1, 0));
        pos.z = 0.0f;
        Instantiate(bomb, pos, Quaternion.identity);
    }
    public Sprite[] SpriteList;
    public string[] NameList;
    public int[] PriceList;
    public int[] GoldeList;
}
