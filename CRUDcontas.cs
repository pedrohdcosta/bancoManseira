class CRUDcontas
{
    // propriedades
    List<Conta> BDcontas = new List<Conta>();
    Tela tela;
    string numero;
    string titular;
    int posicao;

    // construtor
    public CRUDcontas(Tela t)
    {
        this.tela = t;

        // acrescenta duas contas para pesquisa
        // posteriormente este codigo será apagado
        this.BDcontas.Add( new Conta("1001","Ze Colmeia", 1000) );
        this.BDcontas.Add( new Conta("1002","Coelho Ricochete", 500) );
    }

    // outros métodos
    public void controlarCRUD()
    {
        while (true)
        {
            // monta a tela do cadastro de contas
            this.montarTela(10,5,70,15);

            // solicita a entrada do numero da conta
            Console.SetCursorPosition(21,8);
            this.numero = Console.ReadLine();
            if (this.numero == "") break;

            // procura a conta informada no banco de dados
            bool achou = false;
            int x;
            for (x=0; x<this.BDcontas.Count; x++)
            {
                if (this.BDcontas[x].numero == this.numero)
                {
                    achou = true;
                    this.posicao = x;
                    break;
                }
            }

            // se achou a conta, mostra os dados
            // caso contrário mostra a menasgem de não encontrado
            if (achou)
            {
                // mostra os dados da conta encontrada
                Console.SetCursorPosition(21,9);
                Console.Write(this.BDcontas[this.posicao].titular);
                Console.SetCursorPosition(21,10);
                Console.Write(this.BDcontas[this.posicao].saldo);
                Console.ReadKey();
            }
            else
            {
                // mostra a menagem de conta não encontrada
                Console.SetCursorPosition(21,9);
                Console.Write("Conta não encontrada");

                // pergunta se o usuário desejada cadastrar nova conta
                Console.SetCursorPosition(21,12);
                Console.Write("Deseja cadastrar (S/N) : ");
                string resp;
                resp = Console.ReadLine();

                // verfica a resposta do usuário
                if (resp == "S" || resp == "s") 
                {
                    // o usuário deseja realizar o cadastro da conta
                    this.tela.limparArea(21,9,69,9);

                    Console.SetCursorPosition(21,9);
                    this.titular = Console.ReadLine();

                    decimal depInicial;
                    Console.SetCursorPosition(21, 10);
                    depInicial = Convert.ToDecimal( Console.ReadLine() );

                    // solicita confirmação para cadastro
                    Console.SetCursorPosition(21,12);
                    Console.Write("Confirma o cadastro (S/N) : ");
                    resp = Console.ReadLine();

                    // se o usuário confirmou o cadastro
                    if (resp == "S" || resp == "s")
                    {
                        this.BDcontas.Add( 
                            new Conta(this.numero,
                                      this.titular,
                                      depInicial) );
                    }
                }
                
            }
        }
    }


    public void montarTela(int ci, int li, int cf, int lf)
    {
        this.tela.montarMoldura(ci,li,cf,lf);
        this.tela.montarLinhaHor(li+2,ci,cf);
        this.tela.centralizar(li+1,ci,cf,"Cadastro de contas");
        Console.SetCursorPosition(11,8);
        Console.Write("Numero  :");
        Console.SetCursorPosition(11,9);
        Console.Write("Titular :");
        Console.SetCursorPosition(11,10);
        Console.Write("Saldo   :");
    }


    public void mostrarExtrato()
    {
        // este codigo será alterado no futuro

        // limpa a area da tela para mostrar o extrato
        this.tela.limparArea(1,3,69,23);

        // pergunta o numero da conta
        Console.SetCursorPosition(1,4);
        Console.Write("Numero da conta : ");
        this.numero = Console.ReadLine();
        if (this.numero != "") 
        {
            // procura a conta informada no banco de dados
            bool achou = false;
            int x;
            for (x=0; x<this.BDcontas.Count; x++)
            {
                if (this.BDcontas[x].numero == this.numero)
                {
                    achou = true;
                    this.posicao = x;
                    break;
                }
            }
            if (achou)
            {
                string extrato = this.BDcontas[this.posicao].mostrarExtrato();
                Console.SetCursorPosition(2,4);
                Console.Write(extrato);
                Console.ReadKey();
            }
        }
   }
}