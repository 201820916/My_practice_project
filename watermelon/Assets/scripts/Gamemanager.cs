using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Gamemanager : MonoBehaviour
{
    public List<GameObject> planets = new List<GameObject>();
    // ★ Inspector에서 planets 순서와 똑같이 행성 이미지를 넣어주세요 (0번: 체리, 1번: 포도...)
    public List<Sprite> planetImages = new List<Sprite>();

    public GameObject NextObject;
    public GameObject Clone;
    public GameObject GameOverPanel;

    public TMP_Text ScoreText;

    // ★ Inspector에서 "Canvas > next > Image"를 여기에 연결하세요
    public Image NextPlanetImage;

    float timeCount = 0;
    int score = 0;

    // ★ 다음 행성이 무엇인지 미리 저장해둘 변수 (생성 시 사용)
    int nextPlanetIndex;

    void Start()
    {
        // 1. 처음 시작할 때 "다음 행성"을 먼저 뽑아둠
        SelectNextPlanetIndex();

        // 2. 뽑아둔 행성을 생성함
        SpawnPlanet();

        UpdateScoreUI();
    }

    void Update()
    {
        timeCount += Time.deltaTime;

        if (GameOverPanel.activeSelf) return;

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Clone != null)
        {
            Clone.transform.position = new Vector2(Mathf.Clamp(mousePos.x, -4f, 4f), 4.0f);
        }

        if (Input.GetMouseButtonDown(0) && timeCount >= 0.5f)
        {
            timeCount = 0;
            Clone.GetComponent<Rigidbody2D>().gravityScale = 1;
            Clone.GetComponent<Collider2D>().enabled = true;

            // 3. 현재 "다음"으로 지정된 행성을 생성
            SpawnPlanet();
        }
    }

    // ★ [수정] 랜덤으로 인덱스만 뽑고, 이미지(UI)를 갱신하는 함수
    void SelectNextPlanetIndex()
    {
        // 0~4번 행성 중 하나를 랜덤으로 선택 (범위는 필요에 따라 조절)
        nextPlanetIndex = Random.Range(0, 5);

        // UI 이미지 교체
        if (NextPlanetImage != null && planetImages.Count > nextPlanetIndex)
        {
            NextPlanetImage.sprite = planetImages[nextPlanetIndex];
        }
    }

    // ★ [신규] 실제 행성을 생성하는 로직을 분리 (이름 변경: SelectNextObject -> SpawnPlanet)
    // 기존 SelectNextObject는 "다음 걸 고르는" 역할만 하고, 생성은 여기서 합니다.
    void SpawnPlanet()
    {
        // 아까 골라둔 인덱스로 오브젝트 설정
        NextObject = planets[nextPlanetIndex];

        // 생성
        Clone = Instantiate(NextObject);
        Clone.GetComponent<Planet>().manager = this;

        // ★ 생성했으니, 이제 "그 다음" 행성을 미리 골라둠 (프리뷰 갱신)
        SelectNextPlanetIndex();
    }

    public void GameOver()
    {
        GameOverPanel.SetActive(true);
    }

    public void ReGame()
    {
        SceneManager.LoadScene(0);
    }

    public void AddScore(int level)
    {
        int addPoint = (int)Mathf.Pow(2, level);
        score += addPoint;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (ScoreText != null)
        {
            ScoreText.text = score.ToString();
        }
    }
}
