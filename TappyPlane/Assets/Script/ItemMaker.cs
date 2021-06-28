using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMaker : MonoBehaviour
{
    //public GameObject item_gold;
    //public GameObject item_silver;
    //public GameObject item_bronze;

    float item_delay; //생성주기
    float item_timer; //지난시간
    float Hitem_delay;
    float Hitem_timer;
    float Gitem_delay;
    float Gitem_timer;

    public GameObject[] stars;
    public GameObject Heal_item;
    public GameObject[] gods;
    

    void Start()
    {
        item_delay = 2f;
        //3초에 한번씩 생성
        item_timer = 0;

        Hitem_delay = 10f;
        Hitem_timer = 0;

        Gitem_delay = Random.Range(3.0f, 10.0f);
        Gitem_timer = 0;
            
        
    }

    
    void Update()
    {
        item_timer += Time.deltaTime;
        Hitem_timer += Time.deltaTime;
        Gitem_timer += Time.deltaTime;
        if(item_timer>= item_delay)
        {
            //시간을 더해줘서 시간이 생성주기 이상이되면 생성
            item_timer -= item_delay;
            //다시 생성주기만큼 시간을빼준다
            float height = Random.Range(-1.0f, 0.9f);
            
            //높이를 랜덤으로 지정
            //Instantiate(item_gold, new Vector3(9, height, 8), Quaternion.identity);
            //Instantiate로 아이템생성하는데 위치는 x9높이는 heigt랜덤,z는 8, 회전은 안하고

            int r = Random.Range(0, 3);
            //switch (r)
            //{
            //    case 0:
            //        Instantiate(item_gold, new Vector3(9, height, 8), Quaternion.identity);
            //        break;
            //    case 1:
            //        Instantiate(item_silver, new Vector3(9, height, 8), Quaternion.identity);
            //        break;
            //    case 2:
            //        Instantiate(item_bronze, new Vector3(9, height, 8), Quaternion.identity);
            //        break;
            //}
            Instantiate(stars[r], new Vector3(9, height, 8), Quaternion.identity);


            //Resources.Load<Sprite>("Letters/letterA");
            //Resources.Load : 프로젝트의 Resources폴더 내에 존재하는
            //파일을 불러오는 함수
            //<>에는 불러올 파일을 어떤 데이터 형태로 가져올지가 들어간다.
            //()에는 불러올 파일의 이름이 문자열의 형태로 들어간다.
            //만약 불러오려는 파일이 Resources폴더 내의
            //다른 폴더 안에 존재한다면
            //이름에 해당하는 폴더의 경로를 포함하여 작성해줘야 한다.
        }
        if (Hitem_timer >= Hitem_delay)
        {
            Hitem_timer -= Hitem_delay;
            Instantiate(Heal_item, new Vector3(9, 0, 8), Quaternion.identity);
        }
        if (Gitem_timer >= Gitem_delay)
        {
            Gitem_timer -= Gitem_delay;
            int r = Random.Range(0, 3);
            Instantiate(gods[r], new Vector3(9, 0, 8), Quaternion.identity);
        }
        
    }
}
