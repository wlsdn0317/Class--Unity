using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMaker : MonoBehaviour
{
    //public GameObject item_gold;
    //public GameObject item_silver;
    //public GameObject item_bronze;

    float item_delay; //�����ֱ�
    float item_timer; //�����ð�
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
        //3�ʿ� �ѹ��� ����
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
            //�ð��� �����༭ �ð��� �����ֱ� �̻��̵Ǹ� ����
            item_timer -= item_delay;
            //�ٽ� �����ֱ⸸ŭ �ð������ش�
            float height = Random.Range(-1.0f, 0.9f);
            
            //���̸� �������� ����
            //Instantiate(item_gold, new Vector3(9, height, 8), Quaternion.identity);
            //Instantiate�� �����ۻ����ϴµ� ��ġ�� x9���̴� heigt����,z�� 8, ȸ���� ���ϰ�

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
            //Resources.Load : ������Ʈ�� Resources���� ���� �����ϴ�
            //������ �ҷ����� �Լ�
            //<>���� �ҷ��� ������ � ������ ���·� ���������� ����.
            //()���� �ҷ��� ������ �̸��� ���ڿ��� ���·� ����.
            //���� �ҷ������� ������ Resources���� ����
            //�ٸ� ���� �ȿ� �����Ѵٸ�
            //�̸��� �ش��ϴ� ������ ��θ� �����Ͽ� �ۼ������ �Ѵ�.
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
