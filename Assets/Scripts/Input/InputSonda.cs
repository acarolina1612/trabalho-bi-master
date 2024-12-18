using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// Aba Sondas
/// </summary>
[System.Serializable]
public class InputSonda : BaseObject, IExcelExportImport
{
    //Input
    public DateTime mobilizacao;
    public int duracaoMinimaDias, duracaoMaximaDias;
    public bool mpd, dual;
    public int valorDiaria;

    //Runtime
    //public Dictionary<int, Atividade> eventosInput; //apenas para carregar input, usar o runtime
    public DateTime desmobilizacao; //calculado
    public InputSonda()
    {
        //eventosInput = new Dictionary<int, Atividade>();
    }


    #region Import/Export Excel
    public override string ToString()
    {
        StringBuilder newText = new StringBuilder();
        string[] header = GetHeaderColumnNames();
        for (int i = 0; i < header.Length; i++)
        {
            newText.Append($"{header[i]}: ").Append(GetFieldValue(header[i]));
            if (i != header.Length - 1) newText.Append(" | ");
            else newText.AppendLine();
        }
        return newText.ToString();
    }
    public string[] GetHeaderColumnNames()
    {
        return new string[7] {
            "Id",
            "Mobiliza��o",
            "Dura��o min (m�s)",
            "Dura��o max (m�s)",
            "Di�ria",
            "Dual",
            "MPD"
        };
    }
    public string GetFieldValue(string fieldName)
    {
        switch (fieldName)
        {
            case "Id": return id.ToString();
            case "Mobiliza��o": return mobilizacao.ToString();
            case "Dura��o min (m�s)": return (duracaoMinimaDias / 30).ToString();
            case "Dura��o max (m�s)": return (duracaoMaximaDias / 30).ToString();
            case "Di�ria": return valorDiaria.ToString();
            case "Dual": return dual.ToString();
            case "MPD": return mpd.ToString();
        }
        return "";
    }
    public void SetFieldValue(string fieldName, string value)
    {
        switch (fieldName)
        {
            case "Id": id = value; displayName = value; break;
            case "Mobiliza��o": mobilizacao.SetValueByString(value); break;
            case "Dura��o min (m�s)":
                duracaoMinimaDias.SetValueByString(value);
                duracaoMinimaDias *= 30;
                break;
            case "Dura��o max (m�s)":
                duracaoMaximaDias.SetValueByString(value);
                duracaoMaximaDias *= 30;
                break;
            case "Di�ria": valorDiaria.SetValueByString(value); break;
            case "Dual": dual.SetValueByString(value); break;
            case "MPD": mpd.SetValueByString(value); break;
        }
    }
    public void ResetFields()
    {

    }
    public void FinishImport()
    {
        desmobilizacao = mobilizacao.AddDays(duracaoMaximaDias);
    }
    #endregion
}
