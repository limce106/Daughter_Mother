using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    public List<string> Talk1 = new List<string>();
    public List<string> Talk2 = new List<string>();
    public List<string> Talk3 = new List<string>();
    public List<string> Talk4 = new List<string>();
    public List<string> Talk5 = new List<string>();
    public List<string> Talk6 = new List<string>();
    public List<string> Talk7 = new List<string>();
    public List<string> Talk8 = new List<string>();
    public List<string> Talk9 = new List<string>();
    public List<string> Talk10 = new List<string>();
    public List<string> Talk11 = new List<string>();

    public string system1;
    public string system2;
    public List<string> talk1 = new List<string>();
    public string talk2;

    // �� �̸��� ���Ƿ� ������->���߿� ����
    void Start()
    {
        // STAGE1
        // �÷��̾�
        Talk1.Add("��ο� �� 20XX�� XX�� XX�� �� ����, ������ �� ������");
        Talk1.Add("�濡�� ���� �ڰ� �־��� " + PlayerPrefs.GetString("Name") + "�� ���� ���");
        Talk1.Add("��? ����... ��𰬾�?");
        Talk1.Add("�������� �������� ���ڴµ� ���..");
        Talk1.Add("�ٴڿ� ���� ����?");
        talk1.Add("������ ã���� �����߰ڴ�!");

        // STAGE2
        // �÷��̾�
        Talk2.Add("���õ��� ���� �޼ӿ� �ִ� �� ����!");
        Talk2.Add("������ �� �����Ϳ� ����? �ϴ� ���� �����Ϳ� ������!"); 

        Talk3.Add("�ٵ� �̰� ����..? ��! ������ �۳� ���Ͽ� ���� ���������ݾ�!");
        // �� ����
        Talk3.Add("�ȳ�? �������̾�! �������� ���� �ȳ���༭ ���� �����...");
        Talk3.Add("������ ã������? ");
        Talk3.Add("�ʳ� ������ ���� ���� ��ſ�...");
        Talk3.Add("������ ���� ������ ���� ������ �־�");
        Talk3.Add("������ ������ ���Ѿƺ�����!!");
        // �÷��̾�
        Talk4.Add("�� ����� ����?  �� ������.");
        Talk4.Add("�������� ����ְ� ��Ҵ�?");
        Talk4.Add("������ ���� ���汸�� �ִܴ�.");
        Talk4.Add("���汸�� ���ٷ�?");
        Talk4.Add("�� ���� ���汸�� ����? �� ���汸�� ���߰ڴ�.");

        // STAGE3
        // �÷��̾�
        Talk6.Add("�� �̱��! ������ ������ ���°�~"); //10
        Talk6.Add("������ ��� �ִ� �ɱ�..?");
        Talk6.Add("��?! �ٴڿ� �Դ� ���� �ް����� �־�");

        Talk6.Add("�ڼ��� ���� ���� ������ ���汸���� ������� �ް����� ����ϰ� �����ݾ�!");
        Talk6.Add("������â�� ��Ʈ ����� �Ȱ���. ����"); // 14
        // �ް���
        Talk6.Add("�ȳ�! ���� �ް����ߡ�");
        Talk6.Add("Ȥ��.. ������ ã�� �ִ�?��");
        Talk6.Add("���� ������ ���� ����! �پ��� ������ ���ִ� ���ĸ��� ���� ������..!��");
        Talk6.Add("������ ���� ������ ���� ������ �־��");
        Talk6.Add("������ ������ �ʹٸ� ���� �����߷���!��");
        // �÷��̾�
        Talk7.Add("����ü �� ������ ����...? ���� �ι�°��...");
        Talk7.Add("�������� ������ ������ �þƺ��ϱ� ���?");
        Talk7.Add("������ ���� �б��� �ִܴ�.");
        Talk7.Add("�б��� ���ٷ�?");
        Talk7.Add("������ ���� �� �б��� ���ž�! �̹��� ���� �ְ���? ���� �б��� �����߰ڴ�.");

        // STAGE4
        // �÷��̾�
        Talk8.Add("����� �б����� �Գ�. ��... �б��� �ʹ� �Ⱦ�");
        Talk8.Add("���� ������ �� �ڲ� �ٸ����� �������� �ž�");

        Talk8.Add("��?! �Ҿ���� �� ����!!!");
        Talk8.Add("����! ������ ����� �� �䳢 ������ ���հŸ��� �־�");
        // �䳢 ����
        // ++ �̸� �Է� �ϼ� �� �� �ڵ嵵 ����
        Talk8.Add(PlayerPrefs.GetString("Name") + "�� �ȳ�! ���� �����༭ ������! �ʶ� ���� �б��� ���� �; ���� ���Դµ� ���ۿ� ���� ��������� ����");
        Talk8.Add("���� �ʶ� �б����� �� �� �ְڴ�!");
        Talk8.Add("���� �Բ� ����! �׷��� ������ ����ִ��� �˷��ٰ�! �����̾�!"); // 2
        // �÷��̾�
        Talk8.Add("��? ��������? �� ��� �� ����!"); //22
        // �䳢 ����
        Talk10.Add("������ ���� ã�� �;�����? �׷� �ʿ� �� ��� ���� �̷��ٰ�!"); // �⺻
        // �÷��̾�
        Talk10.Add("����?"); // �÷��̾� �⺻
        Talk10.Add("!!!!!!!!!"); // �÷��̾� �⺻
        // ����
        // ++ �̸� �Է� �ϼ� �� �� �ڵ嵵 ����
        Talk10.Add(PlayerPrefs.GetString("Name") + "�� �ȳ�?"); // ���� �⺻
        // �÷��̾�
        Talk10.Add("����!?"); // �÷��̾� �⺻
        // ����
        Talk10.Add("�¾�. ������"); // ���� �⺻
        // �÷��̾�
        Talk10.Add("������ �䳢�����̾���?!"); // �÷��̾� �⺻
        // ����
        Talk10.Add("�� ���� �䳢�������� ���߰�, �� ���� ��������� �ñ�����?"); // ���� �⺻
        Talk10.Add("��� �װ� �ڴ� ���� ������ ������ ���ܼ� ����� ������ �ҷ��ܴ�.");// ���� �⺻ 8
        Talk10.Add("������ �� ������ž�.. ����� ������ �ƴϴϱ�");// ���� ����
        // �÷��̾�
        Talk10.Add("������ �ƴ϶��...?");// �÷��̾� �⺻
        // ����
        Talk10.Add("��. �̰��� ������ �츮 " + PlayerPrefs.GetString("Name") + "���� �������ְ� �;� ���� �����̾�"); // ���� ����
        Talk10.Add("���ݱ��� ������ ���ǵ�� ���� �������� ����.. Ȥ�� ��ﳪ��?"); // ���� ���� 12
        // �÷��̾�
        Talk10.Add("��..? ������.. �ް���.. �䳢����..... �׸��� ���ö��� ����.................");  // �÷��̾� �⺻
        Talk10.Add("!!!!!!!!!");  // �÷��̾� �⺻
        // ����
        Talk10.Add("�¾�. ��� ������ " + PlayerPrefs.GetString("Name") + "�̰� �Բ��ߴ� ������ �߾���̾�."); // ���� ���� 15
        Talk10.Add("���� �� ������ �־��� ������, ������ �Բ� ������� �ް���, ������ ������־��� �䳢 ����..");// �÷��̾� �⺻
        Talk10.Add("��� �װ� ������ �ٸ���, �� ������ ������ �Ǹ鼭 � �� ���� Ȱ������ �峭�� �ִ� ����� ������ ��ó�� ������.");//17
        Talk10.Add("�׷��� � ���� ������ " + PlayerPrefs.GetString("Name") + "�̰� �Բ� �ߴ� �߾�� �� �߾��� ��� ���ǵ��� �����ذž�.");
        Talk10.Add("� ���� �����ϰ� Ȱ��á�� " + PlayerPrefs.GetString("Name") + "���� ����� �ٽñ� ���ݰ� ���ְ� �;���.");
        Talk10.Add("������ ���� ��� ���̾�."); //20
        // �÷��̾�
        Talk10.Add("����...... "); // �÷��̾� ����
        Talk10.Add("���� ��� �� ���ݱ��� �ʹ� �������..");// �÷��̾� ����
        Talk10.Add("������� ���簡 �̷��� ���ſ� ������ ���� ���� ������ �ǰ����� �˰� �Ǿ���.");// �÷��̾� ����
        Talk10.Add("���� �̾��ϰ� �ʹ� ��������.");// �÷��̾� ����
        // ����
        // ++ �̸� �Է� �ϼ� �� �� �ڵ嵵 ����
        Talk10.Add(PlayerPrefs.GetString("Name") + "�� ���ݱ��� �ʹ� �����߾�. ������ ������ �� �ٿ� ���� ��� �ٶ���." +
            "���߸��� ���� ���� �¾�༭ ���� �����ܴ�."); // ���� ����

        // STAGE5
        // �÷��̾�
        Talk11.Add("��� �� �� ���̾��ٴ�... �ʹ� �����߾�");
        Talk11.Add("�������� �츮 ����. ������ �� �����; �޿��� ã�ƿ°���?");
        Talk11.Add("����, ���� ������. ������ ������ ������ �� �� �ְ� ���༭. �� �����ε� ������");
    }
    public List<string> GetTalk(List<string> talkname, int talkIndex)
    {
        if (talkIndex == talkname.Count)
        {
            return null;
        }
        else
        {
            return talkname;
        }
    }
}