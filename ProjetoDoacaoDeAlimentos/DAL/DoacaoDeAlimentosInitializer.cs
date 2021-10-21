using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ProjetoDoacaoDeAlimentos.Models;
using ProjetoDoacaoDeAlimentos.DAL;

namespace ProjetoDoacaoDeAlimentos.DAL
{
    public class DoacaoDeAlimentosInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DoacaoDeAlimentosContext>
    {
        protected override void Seed(DoacaoDeAlimentosContext context)
        {
            var alimentos = new List<Alimento>
            {
                new Alimento{DoacaoID=1,Nome="Banana",Tipo="Fruta",Validade=DateTime.Parse("2022-09-01"),Observacoes="Banan eh bão"},
                new Alimento{DoacaoID=1,Nome="Arroz",Tipo="Cereal",Validade=DateTime.Parse("2021-09-03"),Observacoes="Delicinha"},
                new Alimento{DoacaoID=1,Nome="Borscht",Tipo="Sopa",Validade=DateTime.Parse("2021-09-03"),Observacoes="Russia!"},
                new Alimento{DoacaoID=2,Nome="Bolo",Tipo="Doce",Validade=DateTime.Parse("2021-09-05"),Observacoes="Engorda?"},
                new Alimento{DoacaoID=2,Nome="Chuchu",Tipo="Salada",Validade=DateTime.Parse("2021-09-06"),Observacoes="Bobinho"},
                new Alimento{DoacaoID=3,Nome="Lasanha",Tipo="Amor",Validade=DateTime.Parse("2021-09-06"),Observacoes="MAMAMIA"},
                new Alimento{DoacaoID=4,Nome="Pera",Tipo="Fruta",Validade=DateTime.Parse("2021-09-10"),Observacoes="Com mel ou sem?"},
                new Alimento{DoacaoID=5,Nome="Alfajor",Tipo="Doce",Validade=DateTime.Parse("2021-09-21"),Observacoes="Argentino"}


            };
            alimentos.ForEach(a => context.Alimentos.Add(a));
            context.SaveChanges();

            var distribuidors = new List<Distribuidor>
            {
                new Distribuidor{ID=1,Email="marcio@gmail.com",Cnpj="22. 456. 478/0001-20",Endereco="Carijos,345,Itabira"},
                new Distribuidor{ID=2,Email="RuanFood@gmail.com",Cnpj="33. 741. 562/0001-90",Endereco="Caetes,1885,Sabiá"},
                new Distribuidor{ID=3,Email="LurdesAlimentos@gmail.com",Cnpj="89. 365. 235/0001-30",Endereco="PedroJunior,85,Lourdes"},
                new Distribuidor{ID=4,Email="RafaGomesLTDA@gmail.com",Cnpj="55. 486. 132/0001-70",Endereco="SaoPaulo,71,Mares"}
            };
            distribuidors.ForEach(d => context.Distribuidors.Add(d));
            context.SaveChanges();

            var doadors = new List<Doador>
            {
                new Doador{ID=1, Email="carlosMaia@gmail.com",Cnpj="98. 888. 763/0001-10",Endereco="Treze,438,Vila Verde",TipoEstabelecimento="Restaurante",Pontuacao=5},
                new Doador{ID=2, Email="joaorenancauecampos-96@gmail.com",Cnpj="99. 454. 323/0001-50",Endereco="RuaO,847,Mário Andreazza",TipoEstabelecimento="Buteco",Pontuacao=8},
                new Doador{ID=3, Email="noahgabrielaparicio@gmail.com",Cnpj="44. 363. 555/0001-60",Endereco="Avenida Cláudio Manoel da Costa,435,Interlagos ",TipoEstabelecimento="Super Mercado",Pontuacao=10},
                new Doador{ID=4, Email="liviaemilycavalcanti@gmail.com",Cnpj="11. 531. 222/0001-90",Endereco="Rua Doutor Augusto Cardoso,551,Jatiúca",TipoEstabelecimento="Restaurante",Pontuacao=8}
            };
            doadors.ForEach(d => context.Doadors.Add(d));
            context.SaveChanges();

            var doacaos = new List<Doacao>
            {
                new Doacao{ID=1, DoadorID=1, DistribuidorID=2,Status=status.AGUARDANDO_DISTRIBUIDORA},
                new Doacao{ID=2, DoadorID=1, DistribuidorID=3,Status=status.DOACAO_REALIZADA},
                new Doacao{ID=3, DoadorID=2, DistribuidorID=4,Status=status.RESERVADO},
                new Doacao{ID=4, DoadorID=3, DistribuidorID=1,Status=status.AGUARDANDO_DISTRIBUIDORA},
                new Doacao{ID=5, DoadorID=4, DistribuidorID=1,Status=status.RESERVADO},
            };
            doacaos.ForEach(d => context.Doacaos.Add(d));
            context.SaveChanges();
        }
    }
}