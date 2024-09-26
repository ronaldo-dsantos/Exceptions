Console.Clear();

var array = new int[3];

// Bloco try catch para tratativa de erros (exceções)
try
{
  //for (int index = 0; index < 10; index++)
  //{
  //  Console.WriteLine(array[index]);
  //}

  Cadastrar("");
}
// Para cada try você pode ter mais de um catch para tratar as exceções, lembre de sempre ordenar os catch's do mais específico para o mais genérico
catch (IndexOutOfRangeException ex)
{
  Console.WriteLine(ex.InnerException);
  Console.WriteLine(ex.Message);
  Console.WriteLine("Não encontrei o índice na lista.");
}
catch (ArgumentNullException ex)
{
  Console.WriteLine(ex.InnerException);
  Console.WriteLine(ex.Message);
  Console.WriteLine("Falha ao cadastrar texto.");
}
catch (MinhaException ex)
{
  Console.WriteLine(ex.InnerException);
  Console.WriteLine(ex.Message);
  Console.WriteLine(ex.QuandoAconteceu);
  Console.WriteLine("Exceção customizada.");
}
catch (Exception ex)
{
  Console.WriteLine(ex.InnerException);
  Console.WriteLine(ex.Message);
  Console.WriteLine("Ops, algo deu errado!");
}
finally // Finally, sempre será executado independente do código ser executado no try ou ter uma exceção e passar pelo catch, o finally é muito útil para fechar arquivos e conexões com bd por exemplo
{
  Console.WriteLine("Chegou ao fim");
}

static void Cadastrar(string texto)
{
  if (string.IsNullOrEmpty(texto))
  {
    //throw new ArgumentNullException("O texto não pode ser nulo ou vazio.");
    throw new MinhaException(DateTime.Now);
  }
}

// Criando uma exceção customizada
public class MinhaException : Exception
{
  public MinhaException(DateTime date)
  {
    QuandoAconteceu = date;
  }

  public DateTime QuandoAconteceu { get; set; }
}

