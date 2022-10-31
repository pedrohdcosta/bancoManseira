class Conta
{
    // atributos estáticos
    public static int quantContas = 0;


    // atributos
    protected List<Transacao> movimentacao = new List<Transacao>();
    public string numero;
    public string titular;
    
    public decimal saldo
    {
        get
        {
            decimal valorFinal = 0;
            foreach(Transacao transacao in movimentacao)
            {
                valorFinal += transacao.valor;
            }
            return valorFinal;
        }
    }
    


    // construtor
    public Conta(string num, string tit, decimal sal)
    {
        this.numero = num;
        this.titular = tit;
        this.depositar(sal,DateTime.Now,"Deposito inicial");
        
        quantContas ++;
    }


    // métodos
    public string mostrarDados()
    {
        string texto="";

        texto += "Conta " + this.numero;
        texto += " do correntista " + this.titular;
        texto += " com saldo de " + this.saldo.ToString();

        return texto;
    }


    public void depositar(decimal val, DateTime dat, string mot)
    {
        Transacao deposito = new Transacao(val,dat,mot);
        this.movimentacao.Add(deposito);
    }

    public virtual void retirar(decimal val, DateTime dat, string mot)
    {
        if (this.saldo > val)
        {
            Transacao saque = new Transacao(-val,dat,mot);
            this.movimentacao.Add(saque);
        }
    }


    public string mostrarExtrato()
    {
        var extrato = new System.Text.StringBuilder();
        decimal saldo = 0;

        extrato.AppendLine( this.mostrarDados() );
        extrato.AppendLine( "Data\t\t\tValor\t\tSaldo\t\tMotivo" );

        foreach(var movimento in this.movimentacao)
        {
            saldo += movimento.valor;
            extrato.AppendLine(
                movimento.data.ToShortDateString()+"\t\t"+
                movimento.valor.ToString()+"\t\t"+
                saldo.ToString()+"\t\t"+
                movimento.motivo
            );
        }
        /*
        for(int x = 0; x < this.movimentacao.Count; x++)
        {
            saldo += this.movimentacao[x].valor;

            extrato.AppendLine(
                this.movimentacao[x].data.ToShortDateString()+"\t\t"+
                this.movimentacao[x].valor.ToString()+"\t\t"+
                saldo.ToString()+"\t\t"+
                this.movimentacao[x].motivo
            );

        }
        */

        extrato.AppendLine( saldo.ToString() );

        return extrato.ToString();
    }

}