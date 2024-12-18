using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public enum TipoInsumo
{
    Revestimento,
    Servi�o_Perfura��o,
    BAP,
    CI,
    Servi�o_Completa��o
}
//TODO
[System.Serializable]
public class EstoqueInsumo : BaseObject
{
    TipoInsumo tipo;
    List<InputInsumo> list;
    public override string ToString()
    {
        StringBuilder newText = new StringBuilder();
        newText.Append("nome ").Append(displayName).Append(" | ");
        newText.Append("id ").Append(id).Append(" | ");
        newText.Append("tipo ").Append(tipo).Append(" | ");
        return newText.ToString();
    }
}
