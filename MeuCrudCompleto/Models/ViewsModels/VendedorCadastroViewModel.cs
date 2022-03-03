
using System.Collections.Generic;


namespace MeuCrudCompleto.Models.ViewsModels
{
    public class VendedorCadastroViewModel
    {
        public Vendedor Vendedor { get; set; }
        public ICollection<Departamento> Departamentos { get; set; }
    }
}
