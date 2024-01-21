using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TesteRistretto.Presenters;

namespace UnitTest.CompanyTests
{
    [TestClass]
    public class CompanyViewTest
    {
        [TestMethod]
        public void TheowErrorOnNullEdit()
        {
            DummyCompanyRepository repository = new DummyCompanyRepository();
            DummyCompanyView view = new DummyCompanyView();

            CompanyPresenter presenter = new CompanyPresenter(view, repository);

            view.DeleteCompany();

            view.EditCompany();

            Assert.IsFalse(view.IsSuccessful, "Deve apresentar Erro ao tentar editar sem registros!");
            Assert.AreEqual("Não há registros a serem editados!", view.Message, "Deve apresentar a mensagem de erro corretamente");
        }

        [TestMethod]
        public void ThrowErroOnFalseDelete()
        {
            DummyCompanyRepository repository = new DummyCompanyRepository();
            DummyCompanyView view = new DummyCompanyView();

            CompanyPresenter presenter = new CompanyPresenter(view, repository);

            view.DeleteCompany();

            view.DeleteCompany();

            Assert.IsFalse(view.IsSuccessful, "Deve apresentar Erro não deletar nenhum registro");
            Assert.AreEqual("Empresa não foi deletada!", view.Message, "Deve apresentar a mensagem de erro corretamente");
        }
    }
}
