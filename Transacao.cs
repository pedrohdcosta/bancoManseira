class Transacao
{
    public decimal valor;
    public DateTime data;
    public string motivo;


    public Transacao(decimal val, DateTime dat, string mot)
    {
        this.valor  = val;
        this.data   = dat;
        this.motivo = mot;
    }
}