using System;
using System.Xml;
using Unity.Cinemachine;
using UnityEngine;

public class teleport : MonoBehaviour
{
    private float cooltime = 0f;
    private int count = 0;
    private CinemachineCamera vcam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vcam = FindFirstObjectByType<CinemachineCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        use_teleport();
        if (cooltime > 0)
        {
            cooltime -= Time.deltaTime;
        }

        else
        {
            cooltime = 0;
        }
    }

    public void use_teleport()
    {



        if ( Input.GetKeyDown(KeyCode.Z) && cooltime <= 0 )
        {
            if ( count == 0 )
            {
                PlayerPrefs.SetFloat("PlayerPosX", transform.position.x);
                PlayerPrefs.SetFloat("PlayerPosY", transform.position.y);
                PlayerPrefs.Save();

                transform.position = new Vector2(0f, 0f);

                vcam.OnTargetObjectWarped(transform, transform.position - vcam.transform.position);

                count = 1;
                cooltime = 30f;

            }

            else
            {
                // 돌아갈 장소 좌표 temp로 저장
                float tempX = PlayerPrefs.GetFloat("PlayerPosX"); 
                float tempY = PlayerPrefs.GetFloat("PlayerPosY");


                // 다시 돌아올 장소 좌표 Prefs 갱신
                PlayerPrefs.SetFloat("PlayerPosX", transform.position.x);
                PlayerPrefs.SetFloat("PlayerPosY", transform.position.y);
                PlayerPrefs.Save();
                
                // 이동
                transform.position = new Vector2(tempX, tempY);

                vcam.OnTargetObjectWarped(transform, transform.position - vcam.transform.position);

                cooltime = 30f;


            }

        }
    }

}
