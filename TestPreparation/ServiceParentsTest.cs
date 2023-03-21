using Preparation.IService;
using Preparation.Models;
using Assert = Xunit.Assert;
using Microsoft.Extensions.DependencyInjection;
using Preparation.Service;
using Preparation.IRepos;
using Preparation.Repos;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace TestPreparation
{
    public class ServiceParentsTest
    {
        TestContext _testContext;
        public ServiceParentsTest() {
            var services = new ServiceCollection();
            services.AddScoped<DbContext,Context>();
            services.AddScoped<IReposParents, ReposParents>();
            services.AddScoped<IServiceParents, ServiceParents>();

            var inMemoryDB = new DbContextOptionsBuilder<Context>()
                                .UseInMemoryDatabase(databaseName: "PreparationTest").Options;
            _testContext = new TestContext(inMemoryDB);
        }

        public void PopulateParents()
        {
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
            _testContext.AddRange(parents);
            _testContext.SaveChanges();
        }

        [Fact]
        public void CreateParents_and_GetListParentsTest()
        {
            Parents p = new Parents() { Pere = "dada", Mere = "mama", Adresse = "Ankorondrano" };
            var isp = new Mock<IServiceParents>();
            

            isp.Setup(x => x.Create(p));
            var list = isp.Object.FindAll().ToList();


            //PopulateParents();
            //var listPers = _testContext.Parents.ToList();
            Assert.NotNull(list);
        }


        //[Fact]
        //public void Verify_If_Index_Return_Views()
        //{
        //    // Arrange
        //    var isp = GetServiceParents_FindAll().Object;
        //    ParentsController controller = new ParentsController(isp);
        //    // Act
        //    ViewResult result = controller.Index() as ViewResult;
        //    // Assert
        //    Assert.NotNull(result);
        //}

        //[Fact]
        //public void GetDataXMl()
        //{
        //    var iserviceMock = new Mock<IServiceParents>();
        //    var irp = new Mock<IReposParents>();
        //    var sp = new ServiceParents(irp.Object);

        //    var listXml = iserviceMock.Object.GetDataXMl();
            
        //    Assert.NotNull(listXml);
        //}

        //public Mock<IServiceParents> GetServiceParents_FindAll()
        //{
        //    var serviceMock = new Mock<IServiceParents>();
        //    var irp = new Mock<IReposParents>();
        //    var sp = new ServiceParents(irp.Object);

           
            
        //    var queryable = _testContext.Parents;
        //    serviceMock.Setup(s => s.FindAll()).Returns(queryable);
        //    return serviceMock;

        //}

        //[Fact]
        //public void Verify_If_ParentsList_IsNotNull()
        // {
        //    //Assign
        //    var serviceMock = new Mock<IServiceParents>();
        //    var Repos = new ReposParents(_pctxt);

        //    var irp = new Mock<IReposParents>();
        //    var sp = new ServiceParents(irp.Object);
            
        //    //Action
        //    var dataInBddTest = _testContext.Parents.ToList();
        //    var dataInBddProj = _pctxt.Parents.ToList();
        //    var ListInReposParents = Repos.FindAll().ToList();
        //    var findAll = sp.FindAll().ToList();

        //    var isp = GetServiceParents_FindAll().Object;

        //    ParentsController _controller = new ParentsController(serviceMock.Object);
        //    var itm = _controller.AllParents().ToList();

        //    var listParents = serviceMock.Setup(s => s.FindAll()).Returns(sp.FindAll());

        //    //Assert
        //    Assert.NotNull(isp);
        //}



    }
}
