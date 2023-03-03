using Microsoft.VisualStudio.TestTools.UnitTesting;
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

            var bddTest = new DbContextOptionsBuilder<TestContext>().UseSqlServer("Server=localhost;Database=Preparation;Trusted_Connection=True;TrustServerCertificate = true;").Options;
            _testContext = new TestContext(bddTest);
        } 


        [Fact]
        public void Verify_If_Parents_List_In_BddProj_IsNotNull()
         {
            //Assign
            var reposMock = new Mock<IServiceParents>();
            var Repos = new ReposParents(_pctxt);

            //Action
            var dataInBddTest = _testContext.Parents.ToList();
            var dataInBddProj = _pctxt.Parents.ToList();
            var ListInReposParents = Repos.FindAll().ToList();

            ParentsController _controller = new ParentsController(reposMock.Object);
            var itm = _controller.AllParents().ToList();
            var listP = reposMock.Setup(repo => repo.FindAll()).Returns(_pctxt.Parents);

            //Assert
            var r = Assert.IsType<ViewResult>(_controller.Index());
            //var parentsL = Assert.IsType<List<Parents>>(r.Model);
            Assert.Equal(dataInBddTest.Count, itm.Count);
            //var listParent = Assert.Single(data);
            Assert.NotNull(dataInBddProj);
        }


        //[Fact]
        //public void Get_ReturnsAllEntities()
        //{
        //    ParentsController _controller = new ParentsController(_isp);
        //    var result = _controller.Index();
        //    var okResult = Assert.IsType<OkObjectResult>(result.Result);
        //    var entities = Assert.IsAssignableFrom<IEnumerable<Parents>>(okResult.Value);
        //    Assert.Equal(3, entities.Count());
        //}



        //[Fact]
        //public void CreateParentsTest()
        //{
        //    //Arrange
        //    var reposMock = new Mock<IServiceParents>();

        //    //Action
        //    Parents p = new Parents() { Pere = "Marolahy", Mere = "Marovavy", Adresse = "Ankorondrano" };
        //    var addP = reposMock.Setup(repo => repo.Create(p));

        //    //Assert
        //    //var listParent = Assert.Single(_context.Parents.ToList());
        //    //Assert.NotNull(listParent);
        //    //Assert.Equal(p, listParent);
        //    //Assert.Contains(p, _context.Parents);
        //}


    }
}
