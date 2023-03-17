using Preparation.Controllers;
using Preparation.IService;
using Preparation.Models;
using Assert = Xunit.Assert;
using Microsoft.Extensions.DependencyInjection;
using Preparation.Service;
using Preparation.IRepos;
using Preparation.Repos;
using Microsoft.EntityFrameworkCore;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TestPreparation
{
    public class ServiceParentsTest
    {
        PreparationContext _pctxt;
        TestContext _testContext;
        public ServiceParentsTest() {
            var services = new ServiceCollection();
            services.AddScoped<DbContext,PreparationContext>();
            services.AddScoped<IReposParents, ReposParents>();
            services.AddScoped<IServiceParents, ServiceParents>();

            var bddProj = new DbContextOptionsBuilder<PreparationContext>().UseSqlServer("Server=localhost;Database=Preparation;Trusted_Connection=True;TrustServerCertificate = true;").Options;
            _pctxt = new PreparationContext(bddProj);

            //var bddTest = new DbContextOptionsBuilder<TestContext>().UseSqlServer("Server=localhost;Database=Preparation;Trusted_Connection=True;TrustServerCertificate = true;").Options;
            //_testContext = new TestContext(bddTest);

            var inMemoryDB = new DbContextOptionsBuilder<PreparationContext>()
                                .UseInMemoryDatabase(databaseName: "PreparationTest").Options;
            _testContext = new TestContext();
        }


        [Fact]
        public void CreateParents_and_GetListParentsTest()
        {
            //Arrange
            var IreposMock = new Mock<IReposParents>();
            //var Repos = new ReposParents(_testContext);
            var service = new ServiceParents(IreposMock.Object);

            //Action
            Parents p = new Parents() { Pere = "dada", Mere = "mama", Adresse = "Ankorondrano" };
            _testContext.Parents.Add(p);
            _testContext.SaveChanges();

            var listPers = _testContext.Parents.ToList();

            var addP = IreposMock.Setup(repo => repo.Create(p));
            //Repos.Create(p);//mandeha

            //Assert
            //var listParent = Assert.Single(_context.Parents.ToList());
            Assert.NotNull(null);
            //Assert.Equal(p, listParent);
            //Assert.Contains(p, _context.Parents);
        }


        [Fact]
        public void Verify_If_Index_Return_Views()
        {
            // Arrange
            var isp = GetServiceParents_FindAll().Object;
            ParentsController controller = new ParentsController(isp);
            // Act
            ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetDataXMl()
        {
            var iserviceMock = new Mock<IServiceParents>();
            var irp = new Mock<IReposParents>();
            var sp = new ServiceParents(irp.Object);

            var listXml = iserviceMock.Object.GetDataXMl();
            
            Assert.NotNull(listXml);
        }

        public Mock<IServiceParents> GetServiceParents_FindAll()
        {
            var serviceMock = new Mock<IServiceParents>();
            var irp = new Mock<IReposParents>();
            var sp = new ServiceParents(irp.Object);

            List<Parents> parents = new List<Parents>() {   new Parents { Pere="1",Mere="1",Adresse="a" },
                                                            new Parents { Pere = "1", Mere = "1", Adresse = "a" },
                                                            new Parents { Pere="1",Mere="1",Adresse="a" },
                                                            new Parents { Pere="1",Mere="1",Adresse="a" },
                                                            new Parents { Pere="1",Mere="1",Adresse="a" },
                                                            new Parents { Pere="1",Mere="1",Adresse="a" },
                                                            new Parents { Pere="1",Mere="1",Adresse="a" },
                                                            new Parents { Pere="1",Mere="1",Adresse="a" },
                                                            new Parents { Pere="1",Mere="1",Adresse="a" },
                                                            new Parents { Pere="1",Mere="1",Adresse="a" },
                                                            new Parents { Pere="1",Mere="1",Adresse="a" }};
            
            var queryable = parents.AsQueryable();
            serviceMock.Setup(s => s.FindAll()).Returns(queryable);
            return serviceMock;

        }

        [Fact]
        public void Verify_If_ParentsList_IsNotNull()
         {
            //Assign
            var serviceMock = new Mock<IServiceParents>();
            var Repos = new ReposParents(_pctxt);

            var irp = new Mock<IReposParents>();
            var sp = new ServiceParents(irp.Object);
            
            //Action
            var dataInBddTest = _testContext.Parents.ToList();
            var dataInBddProj = _pctxt.Parents.ToList();
            var ListInReposParents = Repos.FindAll().ToList();
            var findAll = sp.FindAll().ToList();

            var isp = GetServiceParents_FindAll().Object;

            ParentsController _controller = new ParentsController(serviceMock.Object);
            var itm = _controller.AllParents().ToList();

            var listParents = serviceMock.Setup(s => s.FindAll()).Returns(sp.FindAll());

            //Assert
            Assert.NotNull(isp);
        }

        [Fact]
        public void CreateParentsTest()
        {
            //Arrange
            var IreposMock = new Mock<IReposParents>();
            var Repos = new ReposParents(_pctxt);
            var service = new ServiceParents(IreposMock.Object);

            //Action
            Parents p = new Parents() { Pere = "dada", Mere = "mama", Adresse = "Ankorondrano" };
            var addP = IreposMock.Setup(repo => repo.Create(p));
            //Repos.Create(p);//mandeha
            service.Create(p);
            var res = _pctxt.Parents.ToList().Where(x => x == p).ToList();

            //Assert
            //var listParent = Assert.Single(_context.Parents.ToList());
            Assert.NotNull(res);
            //Assert.Equal(p, listParent);
            //Assert.Contains(p, _context.Parents);
        }


    }
}
