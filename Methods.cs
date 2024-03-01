using UnityEngine.UI;

public static class Methods
{
    public static decimal proc; //��������� ��������
    public static decimal upt, u; //����� �� ���, ��������� ���
    public static decimal bonus; //�����
    public static decimal[] uptProcent = new decimal[4] { 0, 10, 15, 20 }; //�������� ��������� ���
    public static decimal CountProcent(decimal plan)
    {
        proc = 1;
        if (plan >= 70 & plan < 90) { proc = 2; }
        else if (plan >= 90 & plan < 95) { proc = 2.5M; }
        else if (plan >= 95 & plan < 100) { proc = 2.7M; }
        else if (plan >= 100) { proc = 3; }
        return proc;
    }
    public static decimal CountBonus(decimal plan, decimal pm, decimal tom, decimal v)
    {
        bonus = 0;
        if (plan >= 105) { bonus = (tom - (pm * 1.05M)) * 0.05M * v; }
        return bonus;
    }
    public static decimal CountUPT(decimal plan, decimal hours, decimal uptProcent)
    {
        upt = 0;
        if (plan >= 80) { upt = hours * uptProcent; }
        return upt;
    }
    public static decimal Toggles(Toggle[] toggle)
    {
        u = 0;
        for (int i = 0; i < toggle.Length; i++)
        {
            if (toggle[i].isOn) { u = uptProcent[i]; break; }
        }
        return u;
    }
}
