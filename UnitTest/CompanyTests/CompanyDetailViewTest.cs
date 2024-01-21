using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TesteRistretto.Presenters;
using UnitTest.EmployeeTests;

namespace UnitTest.CompanyTests
{
    [TestClass]
    public class CompanyDetailViewTest
    {
        [TestMethod]
        public void CompanyNameValidation()
        {
            DummyCompanyRepository companyRepository = new DummyCompanyRepository();
            DummyEmployeeRepository employeeRepository = new DummyEmployeeRepository();
            DummyCompanyDetailView view = new DummyCompanyDetailView();

            new CompanyDetailPresenter(view, companyRepository, employeeRepository, new TesteRistretto.Models.Company());

            view.ContactNumber = "48988165118";

            view.SaveCompany();

            Assert.IsFalse(view.IsSuccessful, "Deve Apresentar Erro ao tentar salvar com o nome Vazio!");
            Assert.AreEqual("\nNome não deve ser vazio!", view.Message, "Deve apresentar a mensagem de erro corretamente");

            view.CompanyName = "Ristretto Sistemas";

            view.SaveCompany();

            Assert.IsTrue(view.IsSuccessful, "Deve validar com sucesso se preenchido corretamente!");
        }

        [TestMethod]
        public void ContactNumberValidation()
        {
            DummyCompanyRepository companyRepository = new DummyCompanyRepository();
            DummyEmployeeRepository employeeRepository = new DummyEmployeeRepository();
            DummyCompanyDetailView view = new DummyCompanyDetailView();

            new CompanyDetailPresenter(view, companyRepository, employeeRepository, new TesteRistretto.Models.Company());

            view.CompanyName = "Ristretto Sistemas";

            view.SaveCompany();

            Assert.IsFalse(view.IsSuccessful, "Deve Apresentar Erro ao tentar salvar com o telefone Vazio!");
            Assert.AreEqual("\nTelefone inválido!", view.Message, "Deve apresentar a mensagem de erro corretamente");

            view.ContactNumber = "asdasda -0 (";

            view.SaveCompany();

            Assert.IsFalse(view.IsSuccessful, "Deve Apresentar Erro ao tentar salvar caracteres não numéricos no telefone!");
            Assert.AreEqual("\nTelefone inválido!", view.Message, "Deve apresentar a mensagem de erro corretamente");

            view.ContactNumber = "4888165118";

            view.SaveCompany();

            Assert.IsFalse(view.IsSuccessful, "Deve Apresentar Erro ao tentar salvar um número de telefone com menos de 11 caracteres!");
            Assert.AreEqual("\nTelefone inválido!", view.Message, "Deve apresentar a mensagem de erro corretamente");

            view.ContactNumber = "00123456789";

            view.SaveCompany();

            Assert.IsTrue(view.IsSuccessful, "Deve validar com sucesso se preenchido corretamente!");
        }

        [TestMethod]
        public void ThrowErrorOnNullEdit()
        {
            DummyCompanyRepository companyRepository = new DummyCompanyRepository();
            DummyEmployeeRepository employeeRepository = new DummyEmployeeRepository();
            DummyCompanyDetailView view = new DummyCompanyDetailView();

            new CompanyDetailPresenter(view, companyRepository, employeeRepository, new TesteRistretto.Models.Company());

            view.DeleteEmployee();

            view.EditEmployee();

            Assert.IsFalse(view.IsSuccessful, "Deve apresentar Erro ao tentar editar sem registros!");
            Assert.AreEqual("Não há registros a serem editados!", view.Message, "Deve apresentar a mensagem de erro corretamente");
        }

        [TestMethod]
        public void ThrowErroOnFalseDelete()
        {
            DummyCompanyRepository companyRepository = new DummyCompanyRepository();
            DummyEmployeeRepository employeeRepository = new DummyEmployeeRepository();
            DummyCompanyDetailView view = new DummyCompanyDetailView();

            new CompanyDetailPresenter(view, companyRepository, employeeRepository, new TesteRistretto.Models.Company());

            view.DeleteEmployee();

            view.DeleteEmployee();

            Assert.IsFalse(view.IsSuccessful, "Deve apresentar Erro não deletar nenhum registro");
            Assert.AreEqual("Funcionário não foi deletado!", view.Message, "Deve apresentar a mensagem de erro corretamente");
        }
    }
}
