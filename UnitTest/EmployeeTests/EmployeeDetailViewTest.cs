using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TesteRistretto.Models;
using TesteRistretto.Presenters;
using TesteRistretto.Repositories;
using TesteRistretto.Views;
using UnitTest.CompanyTests;

namespace UnitTest.EmployeeTests
{
    [TestClass]
    public class EmployeeDetailViewTest
    {
        [TestMethod]
        public void NameCannotBeNullOrEmpty()
        {
            DummyCompanyRepository companyRepository = new DummyCompanyRepository();
            DummyEmployeeRepository employeeRepository = new DummyEmployeeRepository();

            DummyEmployeeDetailView view = new DummyEmployeeDetailView();

            new EmployeeDetailPresenter(view, employeeRepository, companyRepository, new Employee());

            view.CompanyId = 1;
            view.Email = "bla";
            view.Login = "bla";
            view.CompanyPosition = "bla";
            view.Password = "bla";
            view.ConfirmationPassword = "bla";
            view.Situation = Situation.Ativo;

            view.SaveCompany();

            Assert.IsFalse(view.IsSuccessful, "Não pode deixar salvar o funcionário com o nome nulo!");
            Assert.AreEqual("\nInforme o nome!", view.Message);
        }

        [TestMethod]
        public void EmailCannotBeNullOrEmpty()
        {
            DummyCompanyRepository companyRepository = new DummyCompanyRepository();
            DummyEmployeeRepository employeeRepository = new DummyEmployeeRepository();

            DummyEmployeeDetailView view = new DummyEmployeeDetailView();

            new EmployeeDetailPresenter(view, employeeRepository, companyRepository, new Employee());

            view.CompanyId = 1;
            view.EmployeeName = "bla";
            view.Login = "bla";
            view.CompanyPosition = "bla";
            view.Password = "bla";
            view.ConfirmationPassword = "bla";
            view.Situation = Situation.Ativo;

            view.SaveCompany();

            Assert.IsFalse(view.IsSuccessful, "Não pode deixar salvar o funcionário com o email nulo!");
            Assert.AreEqual("\nInforme o E-mail!", view.Message);
        }

        [TestMethod]
        public void CompanyPositionCannotBeNullOrEmpty()
        {
            DummyCompanyRepository companyRepository = new DummyCompanyRepository();
            DummyEmployeeRepository employeeRepository = new DummyEmployeeRepository();

            DummyEmployeeDetailView view = new DummyEmployeeDetailView();

            new EmployeeDetailPresenter(view, employeeRepository, companyRepository, new Employee());

            view.CompanyId = 1;
            view.EmployeeName = "bla";
            view.Login = "bla";
            view.Email = "bla";
            view.Password = "bla";
            view.ConfirmationPassword = "bla";
            view.Situation = Situation.Ativo;

            view.SaveCompany();

            Assert.IsFalse(view.IsSuccessful, "Não pode deixar salvar o funcionário com o cargo nulo!");
            Assert.AreEqual("\nInforme o Cargo!", view.Message);
        }

        [TestMethod]
        public void LoginCannotBeNullOrEmpty()
        {
            DummyCompanyRepository companyRepository = new DummyCompanyRepository();
            DummyEmployeeRepository employeeRepository = new DummyEmployeeRepository();

            DummyEmployeeDetailView view = new DummyEmployeeDetailView();

            new EmployeeDetailPresenter(view, employeeRepository, companyRepository, new Employee());

            view.CompanyId = 1;
            view.EmployeeName = "bla";
            view.Email = "bla";
            view.CompanyPosition = "bla";
            view.Password = "bla";
            view.ConfirmationPassword = "bla";
            view.Situation = Situation.Ativo;

            view.SaveCompany();

            Assert.IsFalse(view.IsSuccessful, "Não pode deixar salvar o funcionário com o login nulo!");
            Assert.AreEqual("\nInforme o Login!", view.Message);
        }

        [TestMethod]
        public void PasswordCannotBeNullOrEmpty()
        {
            DummyCompanyRepository companyRepository = new DummyCompanyRepository();
            DummyEmployeeRepository employeeRepository = new DummyEmployeeRepository();

            DummyEmployeeDetailView view = new DummyEmployeeDetailView();

            new EmployeeDetailPresenter(view, employeeRepository, companyRepository, new Employee());

            view.CompanyId = 1;
            view.EmployeeName = "bla";
            view.Email = "bla";
            view.CompanyPosition = "bla";
            view.Login = "bla";
            view.Situation = Situation.Ativo;

            view.SaveCompany();

            Assert.IsFalse(view.IsSuccessful, "Não pode deixar salvar o funcionário sem a senha!");
            Assert.AreEqual("\nInforme a Senha!", view.Message);
        }

        [TestMethod]
        public void PasswordHasToBeConfirmed()
        {
            DummyCompanyRepository companyRepository = new DummyCompanyRepository();
            DummyEmployeeRepository employeeRepository = new DummyEmployeeRepository();

            DummyEmployeeDetailView view = new DummyEmployeeDetailView();

            new EmployeeDetailPresenter(view, employeeRepository, companyRepository, new Employee());

            view.CompanyId = 1;
            view.EmployeeName = "bla";
            view.Email = "bla";
            view.CompanyPosition = "bla";
            view.Login = "bla";
            view.Password = "bla";
            view.ConfirmationPassword = "b";
            view.Situation = Situation.Ativo;

            view.SaveCompany();

            Assert.IsFalse(view.IsSuccessful, "A senha tem de ser igual a confirmação da senha!");
            Assert.AreEqual("\nA confirmação da senha está diferente da senha!", view.Message);
        }

        [TestMethod]
        public void CompanyHasToBeSelected()
        {
            DummyCompanyRepository companyRepository = new DummyCompanyRepository();
            DummyEmployeeRepository employeeRepository = new DummyEmployeeRepository();

            DummyEmployeeDetailView view = new DummyEmployeeDetailView();

            new EmployeeDetailPresenter(view, employeeRepository, companyRepository, new Employee());

            view.EmployeeName = "bla";
            view.Email = "bla";
            view.CompanyPosition = "bla";
            view.Login = "bla";
            view.Password = "bla";
            view.ConfirmationPassword = "bla";
            view.Situation = Situation.Ativo;

            view.SaveCompany();

            Assert.IsFalse(view.IsSuccessful, "Não pode deixar salvar o funcionário sem selecionar a empresa!");
            Assert.AreEqual("\nSelecione a empresa!", view.Message);
        }

        [TestMethod]
        public void PasswordValidationIsNotRequiredOnEditUnlessInformed()
        {
            DummyCompanyRepository companyRepository = new DummyCompanyRepository();
            DummyEmployeeRepository employeeRepository = new DummyEmployeeRepository();

            DummyEmployeeDetailView view = new DummyEmployeeDetailView();

            new EmployeeDetailPresenter(view, employeeRepository, companyRepository, new Employee());

            view.EmployeeId = 1;
            view.EmployeeName = "bla";
            view.Email = "bla";
            view.CompanyPosition = "bla";
            view.Login = "bla";
            view.CompanyId = 1;
            view.Situation = Situation.Ativo;

            view.SaveCompany();

            Assert.IsTrue(view.IsSuccessful, "Deve deixar passar sem a validação da senha quando está editando funcionário existente!");

            view.Password = "bla";

            view.SaveCompany();

            Assert.IsFalse(view.IsSuccessful, "A senha tem de ser igual a confirmação da senha!");
            Assert.AreEqual("\nA confirmação da senha está diferente da senha!", view.Message);
        }
    }
}
