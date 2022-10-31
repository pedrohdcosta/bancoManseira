Tela tela = new Tela(ConsoleColor.Black, ConsoleColor.White);
CRUDcontas crudContas = new CRUDcontas(tela);

List<string> menu = new List<string>();
string opcao;

// menu do sistema
menu.Add("1 - Contas      ");
menu.Add("2 - Movimentacao");
menu.Add("3 - Extrato     ");
menu.Add("0 - Sair        ");

while (true)
{
    tela.montarTelaGeral();
    tela.montarLinhaHor(2,0,79);
    tela.centralizar(1,0,79,"Manseira Bank");
    opcao = tela.mostrarMenu(2,3,menu);

    if (opcao == "0") break;
    if (opcao == "1") crudContas.controlarCRUD();
    if (opcao == "3") crudContas.mostrarExtrato();

}
Console.Clear();

//tela.montarMoldura(5,5,40,12);
//tela.montarMoldura(10,7,70,18);
