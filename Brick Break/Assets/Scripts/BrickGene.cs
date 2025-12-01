using UnityEngine;

public class BrickGene : MonoBehaviour
{
    // [1] Inspector 창에서 Brick 프리팹을 연결할 변수 (가장 중요!)
    public GameObject brickPrefab;

    // [2] 레벨 디자인 설정
    public int rows = 2;         // 생성할 행(가로 줄)의 개수
    public int columns = 3;     // 생성할 열(세로 칸)의 개수
    public float spacing = 1.5f; // 벽돌 간 간격 (작을수록 촘촘함)
    public Vector3 startPosition = new Vector3(-4.5f, 4.0f, 0); // 벽돌 배치가 시작될 화면 상단 좌측 위치

    void Start()
    {
        GenerateBricks();
    }

    void GenerateBricks()
    {
        // 행 (Row, Y축) 반복
        for (int i = 0; i < rows; i++)
        {
            // 열 (Column, X축) 반복
            for (int j = 0; j < columns; j++)
            {
                // [3] 벽돌 생성 위치 계산
                // 시작 위치에서 간격만큼 X, Y 좌표를 이동시킵니다.
                Vector3 position = new Vector3(
                    startPosition.x + j * spacing,    // X 위치
                    startPosition.y - i * spacing,    // Y 위치 (아래로 내려가야 하므로 -i)
                    0
                );

                // [4] 프리팹을 복제하여 씬에 실제 벽돌 오브젝트 생성
                // Instantiate(생성할 프리팹, 위치, 회전값(Quaternion.identity는 회전 없음))
                Instantiate(brickPrefab, position, Quaternion.identity);
            }
        }
    }
}