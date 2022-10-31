class ContaEspecial : Conta
{
    // atributos específicos da ContaEspecial
    public decimal limite;


    public ContaEspecial(string num, string tit, decimal sal, decimal lim) 
    : base(num,tit,sal)
    {
        this.limite = lim;
    }


    public override void retirar(decimal val, DateTime dat, string mot)
    {
        if (this.saldo+this.limite > val)
        {
            Transacao saque = new Transacao(-val,dat,mot);
            this.movimentacao.Add(saque);
        }
    }
}