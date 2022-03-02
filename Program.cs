using DIO_Series;

SerieRepositorio repositorio = new SerieRepositorio();

string opcaoSelecionada = ObterOpcaoUsuario();
while (opcaoSelecionada.ToUpper() != "X")
{
    switch (opcaoSelecionada)
    {
        case "1":
            ListarSeries();
            break;
        case "2":
            InserirSerie();
            break;
        case "3":
            AtualizarSerie();
            break;
        case "4":
            ExcluirSerie();
            break;
        case "5":
            VisualizarSerie();
            break;
        case "C":
            Console.Clear();
            break;
        default:
            throw new ArgumentOutOfRangeException();
    }
    opcaoSelecionada = ObterOpcaoUsuario();

}
Console.WriteLine("Obrigado por utilizar nossos serviços.");
Console.ReadLine();

void VisualizarSerie()
{
    Console.Write("Digite o id da série: ");
    var retornoId = Console.ReadLine();
    int indiceSerie = int.MinValue;
    if (!string.IsNullOrEmpty(retornoId))
    {
        indiceSerie = int.Parse(retornoId);
    }

    var serie = repositorio.RetornaPorId(indiceSerie);
    Console.WriteLine(serie.ToString());
}

void ExcluirSerie()
{
    Console.Write("Digite o id da série que deseja excluir: ");
    var retornoId = Console.ReadLine();
    int indiceSerie = int.MinValue;
    if (!string.IsNullOrEmpty(retornoId))
    {
        indiceSerie = int.Parse(retornoId);
    };
    var serie = repositorio.RetornaPorId(indiceSerie);
    repositorio.Exclui(indiceSerie);
    Console.WriteLine("{0} excluída.", serie.retornaTitulo());
}

void AtualizarSerie()
{
    Console.Write("Digite o id da série: ");
    var retornoId = Console.ReadLine();
    int indiceSerie = int.MinValue;
    if (!string.IsNullOrEmpty(retornoId))
    {
        indiceSerie = int.Parse(retornoId);
    }

    foreach (int i in Enum.GetValues(typeof(Genero)))
    {
        Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
    }

    Console.Write("Digite o gênero entre as opções acima: ");
    var retornoGenero = Console.ReadLine();
    int? entradaGenero = null;
    if (!string.IsNullOrEmpty(retornoGenero))
    {
        entradaGenero = int.Parse(retornoGenero);
    }

    Console.Write("Digite o Título da série: ");
    string? entradaTitulo = Console.ReadLine();

    Console.Write("Digite o ano da série: ");
    var retornoAno = Console.ReadLine();
    int? entradaAno = null;
    if (!string.IsNullOrEmpty(retornoAno))
    {
        entradaAno = int.Parse(retornoAno);
    }

    Console.Write("Digite a descrição da série: ");
    string? entradaDescricao = Console.ReadLine();

    Serie atualizaSerie = new Serie(
            id: indiceSerie,
            genero: (Genero?)entradaGenero,
            titulo: entradaTitulo,
            ano: entradaAno,
            descricao: entradaDescricao
            );

    repositorio.Atualiza(indiceSerie, atualizaSerie);

}

void InserirSerie()
{
    Console.WriteLine("Inserir nova série:");

    foreach (int i in Enum.GetValues(typeof(Genero)))
    {
        Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
    }

    Console.Write("Digite o gênero entre as opções acima: ");
    var retornoGenero = Console.ReadLine();
    int? entradaGenero = null;
    if (!string.IsNullOrEmpty(retornoGenero))
    {
        entradaGenero = int.Parse(retornoGenero);
    }

    Console.Write("Digite o Título da série: ");
    string? entradaTitulo = Console.ReadLine();

    Console.Write("Digite o ano da série: ");
    var retornoAno = Console.ReadLine();
    int? entradaAno = null;
    if (!string.IsNullOrEmpty(retornoAno))
    {
        entradaAno = int.Parse(retornoAno);
    }

    Console.Write("Digite a descrição da série: ");
    string? entradaDescricao = Console.ReadLine();

    Serie novaSerie = new Serie(id: repositorio.ProximoId(),
    genero: (Genero?)entradaGenero,
    titulo: entradaTitulo,
    ano: entradaAno,
    descricao: entradaDescricao);

    repositorio.Insere(novaSerie);
}

void ListarSeries()
{
    Console.WriteLine("Listar séries");

    var lista = repositorio.Lista();
    if (lista.Count == 0)
    {
        Console.WriteLine("Nenhuma série cadastrada.");
        return;
    }

    foreach (var serie in lista)
    {
        if (!serie.isExcluida())
        {
            Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
        }
    }
}

string ObterOpcaoUsuario()
{
    Console.WriteLine("");
    Console.WriteLine("DIO-Séries a seu dispor!!!");
    Console.WriteLine("Informe a opção desejada:");
    Console.WriteLine("1- Listar séries;");
    Console.WriteLine("2- Inserir nova série;");
    Console.WriteLine("3- Atualizar séries;");
    Console.WriteLine("4- Excluir séries;");
    Console.WriteLine("5- Visualizar série;");
    Console.WriteLine("C- Limpar Tela;");
    Console.WriteLine("X- Sair;");
    Console.WriteLine("");

    var retornoGeral = Console.ReadLine();
    string? opcaoUsuario = null;
    if (!string.IsNullOrEmpty(retornoGeral))
    {
        opcaoUsuario = retornoGeral.ToUpper();
        return opcaoUsuario;
    }
    Console.WriteLine("");
    return "";
}
