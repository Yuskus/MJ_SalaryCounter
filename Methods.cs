using UnityEngine.UI;

public static class Methods
{
    public static decimal[] uptProcent = new decimal[4] { 0, 10, 15, 20 }; //çíà÷åíèÿ ìíîæèòåëÿ þïò
    
    public static decimal CountProcent(decimal plan)
    {
        return plan switch
        {
            >= 100 => 3M,
            >= 95 => 2.7M,
            >= 90 => 2.5M,
            >= 70  => 2M,
            _ => 1M
        };
    }
    
    public static decimal CountBonus(decimal plan, decimal pm, decimal tom, decimal v)
    {
        return plan >= 105 ? (tom - (pm * 1.05M)) * 0.05M * v : 0;
    }
    
    public static decimal CountUPT(decimal plan, decimal hours, decimal uptProcent)
    {
        return plan >= 80 ? hours * uptProcent : 0;
    }
    
    public static decimal Toggles(Toggle[] toggle)
    {
        for (int i = 0; i < toggle.Length; i++)
        {
            if (toggle[i].isOn) { return uptProcent[i]; }
        }
        return 0;
    }
}
