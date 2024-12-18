
using System;
using System.Text;
using UnityEngine;
//TODO
public class InputCrono : BaseObject, IExcelExportImport
{
    public string poco;
    public TipoAtividade atividade;
    public string sonda;
    public DateTime inicio;
    public int duration;
    public DateTime termino;

    public void FromAtividade(Atividade atv)
    {
        poco = atv.inputPoco.id;
        atividade = atv.inputAtividade.tipo;
        sonda = atv.sondaId;
        inicio = atv.start;
        duration = atv.duracaoReal;
        termino = atv.finish;
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
            "Po�o",
            "Atividade",
            "Sonda",
            "Data In�cio",
            "Dura��o",
            "Data T�rmino",
    };
    }
    public string GetFieldValue(string fieldName)
    {
        switch (fieldName)
        {
            case "Id": return id.ToString();
            case "Po�o": return poco.ToString();
            case "Atividade": return atividade.ToString();
            case "Sonda": return sonda.ToString();
            case "Data In�cio": return inicio.ToOADate().ToString();
            case "Dura��o": return duration.ToString();
            case "Data T�rmino": return termino.ToOADate().ToString();
        }
        return "";
    }
    public void SetFieldValue(string fieldName, string value)
    {
        switch (fieldName)
        {
            case "Id": id = value; break;
            case "Po�o": poco = value; break;
            case "Atividade": atividade.SetValueByString(value); break;
            case "Sonda": sonda = value; break;
            case "Data In�cio": inicio.SetValueByString(value); break;
            case "Dura��o": duration.SetValueByString(value); break;
            case "Data T�rmino": termino.SetValueByString(value); break;
        }
    }
    public void ResetFields()
    {

    }
    public void FinishImport()
    {
    }
    #endregion
}
