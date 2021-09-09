namespace CatalogoJogos.Domain.MetodosExtensao
{
    public static class ExtensaoValidacoes
    {
        public static void ValidarString(this string param)
        {
            if (string.IsNullOrWhiteSpace(param))
            {
                throw new System.Exception("Deu errado");
            }
        }
    }
}