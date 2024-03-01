using UnityEngine;
using UnityEngine.UI;

public class PrognosZP : MonoBehaviour
{
    private GameObject Canvas, PanelError, PanelResult, Panel3;
    private Text Result;
    private InputField Smen, ODSmen, PM, PP, TOM, TOP, H;
    private decimal Res, SM0, ODS0, PM0, PP0, TOM0, TOP0, H0, Pre, PreTOM, PreTOP;
    private decimal BO, PM5, PP5, PR0, PR1, U, U0, V, V1, Bonus;
    private Toggle[] UPTToggle;
    private void Awake()
    {
        Canvas = GameObject.FindGameObjectWithTag("Canvas");
        PanelError = Canvas.transform.GetChild(25).gameObject;
        PanelResult = Canvas.transform.GetChild(24).gameObject;
        Panel3 = Canvas.transform.GetChild(26).gameObject;
        Result = PanelResult.transform.GetChild(4).GetComponent<Text>();
        Smen = Canvas.transform.GetChild(5).GetComponent<InputField>();
        ODSmen = Canvas.transform.GetChild(6).GetComponent<InputField>();
        PM = Canvas.transform.GetChild(7).GetComponent<InputField>();
        PP = Canvas.transform.GetChild(8).GetComponent<InputField>();
        TOM = Canvas.transform.GetChild(9).GetComponent<InputField>();
        TOP = Canvas.transform.GetChild(10).GetComponent<InputField>();
        H = Canvas.transform.GetChild(11).GetComponent<InputField>();
        UPTToggle = new Toggle[4];
        for(int i = 0; i < UPTToggle.Length; i++)
        {
            UPTToggle[i] = Canvas.transform.GetChild(20).GetChild(i+1).GetComponent<Toggle>();
        }
    }
    private void Start()
    {
        PanelError.SetActive(false);
        PanelResult.SetActive(false);
        Panel3.SetActive(false);
    }
    public void SaveInputText()
    {
        if (string.IsNullOrEmpty(Smen.text) | string.IsNullOrEmpty(ODSmen.text) | string.IsNullOrEmpty(PM.text) | string.IsNullOrEmpty(PP.text) | string.IsNullOrEmpty(TOM.text) | string.IsNullOrEmpty(TOP.text) | string.IsNullOrEmpty(H.text))
        {
            PanelError.SetActive(true);
        }
        else if(UPTToggle[0].isOn == false & UPTToggle[1].isOn == false & UPTToggle[2].isOn == false & UPTToggle[3].isOn == false)
        {
            PanelError.SetActive(true);
        }
        else
        {
            Parsing();
            Pre = SM0 / ODS0;
            PreTOM = TOM0 * Pre;
            PreTOP = TOP0 * Pre;
            PM5 = PreTOM / PM0 * 100;
            PP5 = PreTOP / PP0 * 100;
            BO = H0 * 100;
            U0 = Methods.Toggles(UPTToggle);
            U = Methods.CountUPT(PM5, H0, U0);
            PR0 = Methods.CountProcent(PM5);
            PR1 = PreTOP / 100 * PR0;
            V = PreTOP / PreTOM;
            V1 = V * 100;
            Bonus = Methods.CountBonus(PM5, PM0, PreTOM, V);
            Res = BO + PR1 + Bonus + U;
            PanelResult.SetActive(true);
            Result.text = "Предполагаемый процент выполнения плана магазином: " + PM5.ToString("0.0") + "%" + "\nПредполагаемый процент выполнения продавцом его личного плана: " + PP5.ToString("0.0") + "%" + "\nПредполагаемый процент вклада в общий товарооборот: " + V1.ToString("0.0") + "%" + "\nБазовый оклад сотрудника: " + BO.ToString("0.00") + "\nПредполагаемый процент с продаж: " + PR1.ToString("0.00") + "\nПредполагаемая доплата за UPT: " + U.ToString("0.00") + "\nВозможный бонус: " + Bonus.ToString("0.00");
            Result.text += "\n\nПрогнозируемая заработная плата сотрудника: " + Res.ToString("0.00");
        }
    }
    public void ButtonClosePanelError()
    {
        PanelError.SetActive(false);
    }
    public void ButtonClosePanelResult()
    {
        PanelResult.SetActive(false);
    }
    public void ButtonClosePanel3()
    {
        if (!Panel3.activeInHierarchy) { Panel3.SetActive(true); }
        else { Panel3.SetActive(false); }
    }
    private void Parsing()
    {
        SM0 = decimal.Parse(Smen.text);
        ODS0 = decimal.Parse(ODSmen.text);
        PM0 = decimal.Parse(PM.text);
        PP0 = decimal.Parse(PP.text);
        TOM0 = decimal.Parse(TOM.text);
        TOP0 = decimal.Parse(TOP.text);
        H0 = decimal.Parse(H.text);
    }
}
