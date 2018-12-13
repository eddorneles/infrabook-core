using InfraBook.Business;
using InfraBook.Context;

namespace InfraBook.Business.Implementations
{
    public class ItemConfiguracaoBusiness : IItemConfiguracaoBusiness {
        
        public ItemConfiguracaoBusiness( MySqlContext context ){
            this.Contexto = context;
        }//END ItemConfiguracaoBusiness()

        public MySqlContext Contexto{get;set;}

    }//END class
}//END namespace