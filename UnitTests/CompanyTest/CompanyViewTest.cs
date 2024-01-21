using TesteRistretto.Presenters;
using TesteRistretto.Repositories;

namespace UnitTests.CompanyTest
{
    [TestClass]
    public class CompanyViewTest
    {
        [TestMethod]
        public void ApresentarErroAoEditarSemRegistros()
        {
            DummyCompanyView companyView = new DummyCompanyView();

            ICompanyRepository companyRepository = new DummyCompanyRepository();

            CompanyPresenter companyPresenter = new CompanyPresenter(companyView, companyRepository);

            //companyView.DeleteCompany();

            //companyView.EditCompany();

            Assert.IsFalse(companyView.IsSuccessful, "Ao clicar no botão Editar sem haver registros deve apresentar Erro!");
            Assert.AreEqual(companyView.Message, "Não há registros para serem Editados!");
        }

        [TestMethod]
        public void ApresentarErroQuandoNaoTiverRegistrosParaDeletar()
        {

        }
    }
}
