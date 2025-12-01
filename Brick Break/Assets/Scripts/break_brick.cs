using UnityEngine;
using UnityEngine.SceneManagement; // [필수] 씬 재시작을 위해 추가

public class break_brick : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 1. 공과 부딪혔는지 확인
        if (collision.gameObject.CompareTag("Ball"))
        {
            // [핵심 로직] 남은 벽돌 개수 세기
            // 현재 씬에 있는 "Brick" 태그를 가진 모든 물체를 찾습니다.
            GameObject[] bricks = GameObject.FindGameObjectsWithTag("Brick");

            // 2. 승리 조건 검사
            // 왜 0개가 아니라 1개일까요?
            // 이 코드가 실행되는 시점에는 '나 자신(이번에 깨질 벽돌)'이 아직 파괴되기 전이라 살아있기 때문입니다.
            // 즉, 목록에 내가 포함되어 있으므로 개수가 1개라면 "내가 마지막 벽돌이다"라는 뜻입니다.
            if (bricks.Length <= 1)
            {
                Debug.Log("🎉 게임 클리어! 축하합니다! 🎉");

                // 게임을 재시작합니다.
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

            // 3. 벽돌 파괴 (나 자신을 없앰)
            Destroy(gameObject);
        }
    }
}