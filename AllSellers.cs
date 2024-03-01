using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AllSellers : MonoBehaviour
{
    private GameObject Canvas, SellerObject, ContentArea, PanelResult, PanelError, Panel3;
    private InputField PMInput, TOMInput;
    private Text Result;
    private string resultForAll;
    private decimal PM0, TOM0, PM5, PR0, SumPP0, SumTOP0;
    private int index = 1;
    private UnityEngine.UI.Button DeleteButton;
    private List<InputField> NamesInput = new();
    private List<InputField> HoursInput = new();
    private List<InputField> PPInput = new();
    private List<InputField> TOPInput = new();
    private List<string> Names1 = new();
    private List<decimal> H0 = new();
    private List<decimal> PP0 = new();
    private List<decimal> TOP0 = new();
    private List<decimal> PP5 = new();
    private List<decimal> BO = new();
    private List<decimal> PR1 = new();
    private List<decimal> Bonus = new();
    private List<decimal> V = new();
    private List<decimal> U0 = new();
    private List<decimal> U = new();
    private List<decimal> Res = new();
    private List<Toggle> UPTToggle1 = new();
    private List<Toggle> UPTToggle2 = new();
    private List<Toggle> UPTToggle3 = new();
    private List<Toggle> UPTToggle4 = new();
    private void Awake()
    {
        Canvas = GameObject.FindGameObjectWithTag("Canvas");
        PanelResult = Canvas.transform.GetChild(16).gameObject;
        PanelError = Canvas.transform.GetChild(17).gameObject;
        Panel3 = Canvas.transform.GetChild(18).gameObject;
        ContentArea = Canvas.transform.GetChild(12).GetChild(0).GetChild(0).gameObject;
        SellerObject = ContentArea.transform.GetChild(0).gameObject;
        Result = PanelResult.transform.GetChild(4).GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>();
        PMInput = Canvas.transform.GetChild(6).GetComponent<InputField>();
        TOMInput = Canvas.transform.GetChild(8).GetComponent<InputField>();
        DeleteButton = Canvas.transform.GetChild(11).GetComponent<UnityEngine.UI.Button>();
    }
    private void Start()
    {
        PanelResult.SetActive(false);
        PanelError.SetActive(false);
        Panel3.SetActive(false);
        NamesInput.Add(SellerObject.transform.GetChild(2).GetComponent<InputField>());
        HoursInput.Add(SellerObject.transform.GetChild(5).GetComponent<InputField>());
        PPInput.Add(SellerObject.transform.GetChild(3).GetComponent<InputField>());
        TOPInput.Add(SellerObject.transform.GetChild(4).GetComponent<InputField>());
        UPTToggle1.Add(SellerObject.transform.GetChild(6).GetComponent<Toggle>());
        UPTToggle2.Add(SellerObject.transform.GetChild(7).GetComponent<Toggle>());
        UPTToggle3.Add(SellerObject.transform.GetChild(8).GetComponent<Toggle>());
        UPTToggle4.Add(SellerObject.transform.GetChild(9).GetComponent<Toggle>());
    }
    public void Add1Button()
    {
        var copy = Instantiate(SellerObject, ContentArea.transform, false);
        copy.transform.localPosition = Vector2.zero;
        copy.GetComponentInChildren<Text>().text = (index + 1+"-й сотрудник").ToString();
        NamesInput.Add(ContentArea.transform.GetChild(index).GetChild(2).GetComponent<InputField>());
        HoursInput.Add(ContentArea.transform.GetChild(index).GetChild(5).GetComponent<InputField>());
        PPInput.Add(ContentArea.transform.GetChild(index).GetChild(3).GetComponent<InputField>());
        TOPInput.Add(ContentArea.transform.GetChild(index).GetChild(4).GetComponent<InputField>());
        UPTToggle1.Add(ContentArea.transform.GetChild(index).GetChild(6).GetComponent<Toggle>());
        UPTToggle2.Add(ContentArea.transform.GetChild(index).GetChild(7).GetComponent<Toggle>());
        UPTToggle3.Add(ContentArea.transform.GetChild(index).GetChild(8).GetComponent<Toggle>());
        UPTToggle4.Add(ContentArea.transform.GetChild(index).GetChild(9).GetComponent<Toggle>());
        index++;
        DeleteButton.interactable = true;
    }
    public void Delete1Button()
    {
        if (index > 1)
        {
            index--;
            NamesInput.Remove(ContentArea.transform.GetChild(index).GetChild(2).GetComponent<InputField>());
            HoursInput.Remove(ContentArea.transform.GetChild(index).GetChild(5).GetComponent<InputField>());
            PPInput.Remove(ContentArea.transform.GetChild(index).GetChild(3).GetComponent<InputField>());
            TOPInput.Remove(ContentArea.transform.GetChild(index).GetChild(4).GetComponent<InputField>());
            UPTToggle1.Remove(ContentArea.transform.GetChild(index).GetChild(6).GetComponent<Toggle>());
            UPTToggle2.Remove(ContentArea.transform.GetChild(index).GetChild(7).GetComponent<Toggle>());
            UPTToggle3.Remove(ContentArea.transform.GetChild(index).GetChild(8).GetComponent<Toggle>());
            UPTToggle4.Remove(ContentArea.transform.GetChild(index).GetChild(9).GetComponent<Toggle>());
            Destroy(ContentArea.transform.GetChild(index).gameObject);
        }
        else { DeleteButton.interactable = false; }
    }
    public void ButtonResult()
    {
        ForPanelError();
        if (!PanelError.activeInHierarchy)
        {
            for(int i = 0; i < index; i++)
            {
                if (UPTToggle1[i].isOn) { U0.Add(0); }
                else if (UPTToggle2[i].isOn) { U0.Add(10); }
                else if (UPTToggle3[i].isOn) { U0.Add(15); }
                else if (UPTToggle4[i].isOn) { U0.Add(20); }
                Names1.Add(NamesInput[i].text);
                PM0 = decimal.Parse(PMInput.text);
                TOM0 = decimal.Parse(TOMInput.text);
                H0.Add(decimal.Parse(HoursInput[i].text));
                PP0.Add(decimal.Parse(PPInput[i].text));
                TOP0.Add(decimal.Parse(TOPInput[i].text));
                PM5 = TOM0 / PM0 * 100;
                PP5.Add(TOP0[i] / PP0[i] * 100);
                BO.Add(H0[i] * 100);
                U.Add(Methods.CountUPT(PM5, H0[i], U0[i]));
                PR0 = Methods.CountProcent(PM5);
                PR1.Add(TOP0[i] / 100 * PR0);
                V.Add(TOP0[i] / TOM0 * 100);
                Bonus.Add(Methods.CountBonus(PM5, PM0, TOM0, V[i] / 100));
                SumPP0 += PP0[i];
                SumTOP0 += TOP0[i];
                Res.Add(BO[i] + PR1[i] + U[i] + Bonus[i]);
                PanelResult.SetActive(true);
                resultForAll += "\n\nЗарплата сотрудника по имени " + Names1[i] + ": " + Res[i].ToString("0.00") + "\nПроцент выполнения продавцом его личного плана: " + PP5[i].ToString("0.0") + "%" + "\nПроцент вклада в общий товарооборот: " + V[i].ToString("0.0") + "%" + "\nБазовый оклад сотрудника: " + BO[i].ToString("0.00") + "\nПроцент с продаж: " + PR1[i].ToString("0.00") + "\nДоплата за UPT: " + U[i].ToString("0.00") + "\nБонус, если есть: " + Bonus[i].ToString("0.00");
            }
            TextInResult();
        }
    }
    public void ButtonClosePanel()
    {
        PanelResult.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ButtonClosePanel2()
    {
        PanelError.SetActive(false);
    }
    public void ButtonClosePanel3()
    {
        if (!Panel3.activeInHierarchy) { Panel3.SetActive(true); }
        else {  Panel3.SetActive(false); }
    }
    private void ForPanelError()
    {
        if (string.IsNullOrEmpty(PMInput.text) | string.IsNullOrEmpty(TOMInput.text)) { PanelError.SetActive(true); }
        for (int i = 0; i < index; i++)
        {
            if (PanelError.activeInHierarchy) { break; }
            if (string.IsNullOrEmpty(NamesInput[i].text) | string.IsNullOrEmpty(HoursInput[i].text) | string.IsNullOrEmpty(PPInput[i].text) | string.IsNullOrEmpty(TOPInput[i].text))
            {
                PanelError.SetActive(true);
            }
            else if (UPTToggle1[i].isOn == false & UPTToggle2[i].isOn == false & UPTToggle3[i].isOn == false & UPTToggle4[i].isOn == false)
            {
                PanelError.SetActive(true);
            }
        }
    }
    private void TextInResult()
    {
        Result.text = "Процент выполнения плана магазином: " + PM5.ToString("0.0") + "%\n";
        if (SumPP0 != PM0) { Result.text += "\nСумма личных планов продавцов не равна плану магазина, возможно вы забыли продавца или где-то ошиблись, проверьте введенные данные."; }
        if (SumTOP0 != TOM0) { Result.text += "\nСумма личных товарооборотов продавцов не равна товарообороту магазина, возможно вы забыли продавца или где-то ошиблись, проверьте введенные данные."; }
        Result.text += resultForAll;
    }
}


