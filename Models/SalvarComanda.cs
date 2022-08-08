namespace ProvaSuficienciaWebII.Models
{
    public class SalvarComanda
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string TelefoneUsuario { get; set; }
        public List<Produto> Produtos { get; set; }


        public List<Exceptions.Exception> EhValido()
        {
            var exceptions = new List<Exceptions.Exception>();
            if(Id <= 0)
            {
                exceptions.Add(new Exceptions.Exception("Id", "Id deve ser maior que 0."));
            } 
            if(IdUsuario <= 0)
            {
                exceptions.Add(new Exceptions.Exception("IdUsuario", "IdUsuario deve ser maior que 0."));
            }

            if (String.IsNullOrEmpty(NomeUsuario))
            {
                exceptions.Add(new Exceptions.Exception("NomeUsuario", "NomeUsuario não pode ser nulo ou vazio."));
            }

            if (String.IsNullOrEmpty(TelefoneUsuario))
            {
                exceptions.Add(new Exceptions.Exception("TelefoneUsuario", "TelefoneUsuario não pode ser nulo ou vazio."));
            } else
            {
                if(TelefoneUsuario.Length > 11)
                {
                    exceptions.Add(new Exceptions.Exception("TelefoneUsuario", "TelefoneUsuario deve ter no máximo 11 caracteres."));
                }
            }

            if(Produtos == null)
            {
                exceptions.Add(new Exceptions.Exception("Produtos", "Ao menos um produto deve ser adicionado."));
            } else
            {
                int i = 0;
                foreach (var produto in Produtos)
                {
                    
                    if(produto.Id <= 0)
                    {
                        exceptions.Add(new Exceptions.Exception($"Produtos[{i}]", "Id deve ser maior que 0."));
                    }

                    if (String.IsNullOrEmpty(produto.Nome))
                    {
                        exceptions.Add(new Exceptions.Exception($"Produtos[{i}]", "Nome não deve ser nulo ou vazio."));
                    }

                    if(produto.Preco <= 0)
                    {
                        exceptions.Add(new Exceptions.Exception($"Produtos[{i}]", "Preco deve ser maior que 0."));
                    }

                    i++;
                }
            }


            if(exceptions.Count > 0)
            {
                return exceptions;
            } else
            {
                return null;
            }
        }
    }
}
