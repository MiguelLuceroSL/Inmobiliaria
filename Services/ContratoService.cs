using System;
using Inmobiliaria.Models;

public class ContratoService
{
    public int CalcularMesesContrato(Contrato contrato)
    {
        return ((contrato.fechaHasta.Year - contrato.fechaDesde.Year) * 12) 
             + contrato.fechaHasta.Month - contrato.fechaDesde.Month;
    }

    public decimal CalcularMontoMensual(Contrato contrato)
    {
        int meses = CalcularMesesContrato(contrato);
        if (meses <= 0) return contrato.montoInicial; // contrato raro
        return contrato.montoInicial / meses;
    }

    public int CalcularMesesTranscurridos(Contrato contrato)
    {
        var hoy = DateTime.Today;
        if (hoy < contrato.fechaDesde) return 0;

        int meses = ((hoy.Year - contrato.fechaDesde.Year) * 12) 
                  + hoy.Month - contrato.fechaDesde.Month;

        // si ya pasó el día de vencimiento del mes actual, se suma
        if (hoy.Day >= contrato.fechaDesde.Day) meses++;

        return meses;
    }

    public int CalcularPagosEsperados(Contrato contrato)
    {
        int mesesTotales = CalcularMesesContrato(contrato);
        int mesesTranscurridos = CalcularMesesTranscurridos(contrato);
        return Math.Min(mesesTotales, mesesTranscurridos);
    }

    public decimal CalcularDeuda(Contrato contrato, int pagosRealizados, decimal interesPorcentaje = 0.05m)
{
    decimal cuotaMensual = CalcularMontoMensual(contrato);
    int pagosEsperados = CalcularPagosEsperados(contrato);

    if (pagosRealizados >= pagosEsperados) return 0; // al día

    int cuotasAtrasadas = pagosEsperados - pagosRealizados;

    // interés = 5% de la cuota
    decimal interes = cuotaMensual * interesPorcentaje;

    return cuotasAtrasadas * (cuotaMensual + interes);
}
}